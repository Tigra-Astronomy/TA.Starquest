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
// File: TestData.cs  Last modified: 2020-09-02@14:44 by Tim Long

using System.IO;
using System.Reflection;

namespace TA.Starquest.Specifications.TestHelpers
    {
    static class TestData
        {
        private static string FromEmbeddedResource(string resourceName, string rootPath)
            {
            var asm = Assembly.GetExecutingAssembly();
            var asmName = asm.GetName().Name;
            var resourceRoot = $"{asmName}.{rootPath}.TestData";
            var resource = $"{resourceRoot}.{resourceName}";
            using (var stream = asm.GetManifestResourceStream(resource))
                {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
                }
            }

        internal static string PreconditionXml(string resourceName) =>
            FromEmbeddedResource(resourceName, "BusinessLogic.PreconditionsEngine");
        }
    }