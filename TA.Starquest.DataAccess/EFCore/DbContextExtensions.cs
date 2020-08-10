using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
{
    internal static class DbContextExtensions
    {
    public static DataBuilder<TEntity> HasJsonSeedData<TEntity>(this EntityTypeBuilder<TEntity> builder, string sourceFile)
    where TEntity : class, IDomainEntity<int>
        {
        var json = GetJson(sourceFile);
        var entities = JsonSerializer.Deserialize<List<TEntity>>(json);
        return builder.HasData(entities);
        }

    private static string GetJson(string sourceFile)
        {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceRoot = assembly.GetName().Name;
        var resource = $"{resourceRoot}.SeedData.{sourceFile}";
        using var stream = assembly.GetManifestResourceStream(resource);
        var reader = new StreamReader(stream);
        return reader.ReadToEnd();
        }
    }
}
