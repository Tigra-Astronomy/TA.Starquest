// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: StarquestDbDesignTimeContextFactory.cs  Last modified: 2024-3-20@21:21 by Tim

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TA.Starquest.DataAccess.EFCore;

namespace TA.Starquest.DataAccess.Migrations;

public class StarquestDbDesignTimeContextFactory : IDesignTimeDbContextFactory<StarquestDbContext>
{
    #region Implementation of IDesignTimeDbContextFactory<out StarquestDbContext>

    /// <inheritdoc />
    public StarquestDbContext CreateDbContext(string[] args)
    {
        var dbFile = @".\Starquest.db";
        var connectionBuilder = new SqliteConnectionStringBuilder { Mode = SqliteOpenMode.ReadWriteCreate, DataSource = dbFile };
        var builder = new DbContextOptionsBuilder<StarquestDbContext>();
        builder.UseSqlite(connectionBuilder.ToString(),
                          o => o.MigrationsAssembly("TA.Starquest.DataAccess.Migrations"));
        return new StarquestDbContext(builder.Options);
    }

    #endregion
}