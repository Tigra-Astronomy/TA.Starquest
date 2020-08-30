using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.DataAccess.EFCore;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.Specifications.QuerySpecifications
{
    class QueryContextBuilder
    {
    private SqliteConnection CreateInMemoryDatabase()
        {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        return connection;
        }
    
    public QueryContext Build()
        {
        SqliteConnection connection = CreateInMemoryDatabase();
        var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        dbOptionsBuilder.UseSqlite(connection);
        var dbContext = new ApplicationDbContext(dbOptionsBuilder.Options, CreateDatabase);
        dbContext.Database.EnsureCreated();
        var uow = new EntityFrameworkCoreUnitOfWork(dbContext);
        var context = new QueryContext
            {
            UnitOfWork = uow,
            DbContext = dbContext,
            DbConnection = connection
            };
        return context;
        }

    public virtual void CreateDatabase(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StarquestUser>();
        //modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => p.UserId);
        //modelBuilder.Entity<IdentityUserRole<string>>().HasKey("UserId", "RoleId");
        }
    }
}
