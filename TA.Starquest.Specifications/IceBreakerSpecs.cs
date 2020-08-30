  using System.Data;
using System.Linq;
using Machine.Specifications;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;
  using TA.Starquest.DataAccess.Entities.QueueWorkItems;
  using TA.Starquest.Specifications.QuerySpecifications;
using TA.Utils.Core;

internal class when_creating_a_picklist_item
    {
    Because of = () => result = new PickListItem<int>(1,"Test Item");
    It should_set_the_display_name = () => result.DisplayName.ShouldEqual("Test Item");
    It should_set_the_key = () => result.Id.ShouldEqual(1);
    private static PickListItem<int> result;
    }

internal class when_querying_the_database
    {
    private static QueryContext Context;
    static TrivialDatabaseContextBuilder Builder = new TrivialDatabaseContextBuilder();
    Establish context = () => Context = Builder.Build();
    It should_have_an_open_database_connection = () => Context.DbConnection.State.ShouldEqual( ConnectionState.Open);
    private It should_have_category_99 =
        () => Context.UnitOfWork.CategoriesRepository.Get(99).Name.ShouldEqual("Test Category");
    private Cleanup after = () => Context.Dispose();
    }

class TrivialDatabaseContextBuilder : QueryContextBuilder
    {
    /// <inheritdoc />
    public override void CreateDatabase(ModelBuilder modelBuilder)
        {
        base.CreateDatabase(modelBuilder);
        modelBuilder
            .Entity<Category>()
                .HasData(new Category{Id=99, Name="Test Category"});

        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(k => k.UserId);
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(k => k.UserId);
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(k => k.UserId);
        // Table-per-hierarchy polymorphism
        modelBuilder.Entity<ObservingSessionReminder>();
        }
    }