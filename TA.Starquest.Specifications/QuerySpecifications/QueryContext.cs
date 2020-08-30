using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Sqlite;
using TA.Starquest.DataAccess.EFCore;

namespace TA.Starquest.Specifications.QuerySpecifications
{
    class QueryContext : IDisposable
    {
    public EntityFrameworkCoreUnitOfWork UnitOfWork { get; set; }
    public ApplicationDbContext DbContext { get; set; }
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
