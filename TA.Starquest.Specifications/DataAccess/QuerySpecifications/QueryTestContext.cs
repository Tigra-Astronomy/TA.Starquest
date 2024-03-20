using System;
using Microsoft.Data.Sqlite;
using TA.Starquest.DataAccess.EFCore;

namespace TA.Starquest.Specifications.DataAccess.QuerySpecifications
{
    class QueryTestContext : IDisposable
    {
    public EntityFrameworkCoreUnitOfWork UnitOfWork { get; set; }
    public StarquestDbContext DbContext { get; set; }
    public SqliteConnection DbConnection { get; set; }

    public void Dispose()
        {
        UnitOfWork?.Dispose();
        DbConnection?.Close();
        DbConnection?.Dispose();
        DbContext?.Dispose();
        }
    }
}
