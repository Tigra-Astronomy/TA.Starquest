// This file is part of the TA.Starquest project
// 
// Copyright © 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: XmlDocumentAttribute.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using TA.Utils.Core;
using TA.Utils.Core.Diagnostics;
using TA.Utils.Logging.NLog;

namespace TA.Starquest.DataAccess.Validation;

[AttributeUsage(AttributeTargets.Property)]
internal class XmlDocumentAttribute : ValidationAttribute
{
    private static readonly ILog Log = new LoggingService();
    private readonly Maybe<string> maybeXsdResourceName = Maybe<string>.Empty;

    /// <summary>
    ///     Initializes a new instance of the <see cref="XmlDocumentAttribute" /> class with no schema. No
    ///     schema validation will take place, but the validated object must still consist of well-formed
    ///     XML.
    /// </summary>
    public XmlDocumentAttribute() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="XmlDocumentAttribute" /> class with a resource
    ///     identifier that can be used to load an XML Schema Document (XSD). The validated object must be
    ///     well-formed XML and must also conform to the supplied schema. Note that failure to load the
    ///     schema will result in the validated object being considered invalid.
    /// </summary>
    /// <param name="schemaResourceName">Name of the schema resource.</param>
    /// <param name="schemaResourceType"><see cref="Type" /> of the schema resource.</param>
    public XmlDocumentAttribute([NotNull] string schemaResourceName)
    {
        maybeXsdResourceName = schemaResourceName.AsMaybe();
    }

    /// <summary>
    ///     Validates the specified <paramref name="value" /> with respect to the current validation
    ///     attribute.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="validationContext">The context information about the validation operation.</param>
    /// <returns>An instance of the <see cref="ValidationResult" /> class.</returns>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // An empty or null object should pass validation. 
        // [Required] attribute can be used to ensure a non-empty item.
        if (string.IsNullOrEmpty(value as string)) return ValidationResult.Success;
        var xmlString = (string)value;
        try
        {
            var xmlDocument = XDocument.Parse(xmlString);
        }
        catch (XmlException e)
        {
            Log.Error()
                .Message("Failing XML validation due to invalid markup")
                .Property("xml", xmlString)
                .Exception(e)
                .Write();
            return FailureResult(validationContext, "Invalid XML markup");
        }

        var schemaSet = new XmlSchemaSet();
        try
        {
            var maybeSchema = GetSchema();
            if (maybeSchema.None)
                return ValidationResult.Success; // No schema validation
            schemaSet.Add(maybeSchema.Single());
        }
        catch (XmlException e)
        {
            Log.Error()
                .Exception(e)
                .Message("Failing validation due to an error loading XML schema")
                .Write();
            return FailureResult(validationContext,
                                 "Unable to load the XML schema for validation (please report this as a bug)");
        }

        var xmlReaderSettings = new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Prohibit,
            CheckCharacters = true,
            ValidationType = ValidationType.Schema,
            Schemas = schemaSet,
            ConformanceLevel = ConformanceLevel.Document,
            ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings,
            CloseInput = true
        };
        xmlReaderSettings.ValidationEventHandler += ValidationEventHandler;

        using (var stream = GenerateStreamFromString(xmlString))
        using (var xmlReader = XmlReader.Create(stream, xmlReaderSettings))
        {
            try
            {
                while (xmlReader.Read()) { }

                return ValidationResult.Success;
            }
            catch (XmlSchemaException e)
            {
                Log.Warn()
                    .Exception(e)
                    .Message("Failing XML validation due to schema validation error")
                    .Property("xml", xmlString)
                    .Write();
                return FailureResult(validationContext, e.Message);
            }
        }
    }

    private async Task<string> SchemaFromEmbeddedResource(string resourceName)
    {
        var asm = Assembly.GetExecutingAssembly();
        var asmName = asm.GetName().Name;
        var resourceRoot = $"{asmName}.BusinessLogic.Preconditions.Rules"; //ToDo - brittle hard-coded path
        var resource = $"{resourceRoot}.{resourceName}.xsd";
        await using var stream = asm.GetManifestResourceStream(resource);
        var reader = new StreamReader(stream);
        var schema = await reader.ReadToEndAsync();
        return schema;
    }

    private void ValidationEventHandler(object sender, ValidationEventArgs validationEventArgs)
    {
        throw validationEventArgs.Exception ?? new XmlSchemaException(validationEventArgs.Message);
    }

    private ValidationResult FailureResult(ValidationContext validationContext, string message = null)
    {
        // If the user specified an error message in the attribute use, always use that.
        if (!string.IsNullOrWhiteSpace(ErrorMessage))
            return new ValidationResult(ErrorMessage, new List<string> { validationContext.MemberName });
        // Otherwise, use an internally generated message
        var resultMessage = string.IsNullOrWhiteSpace(message) ? "Invalid XML" : message;
        return new ValidationResult(resultMessage, new List<string> { validationContext.MemberName });
    }

    private Maybe<XmlSchema> GetSchema()
    {
        if (maybeXsdResourceName.None)
            return Maybe<XmlSchema>.Empty;
        var xsdString = SchemaFromEmbeddedResource(maybeXsdResourceName.Single()).Result; // awaitable
        using (var textReader = new StringReader(xsdString))
        using (var xmlReader = XmlReader.Create(textReader))
        {
            var xsd = XmlSchema.Read(xmlReader,
                                     (o, e) => throw new XmlException("Unable to load the schema"));
            return xsd.AsMaybe();
        }
    }

    private Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}