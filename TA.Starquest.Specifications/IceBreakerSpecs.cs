﻿  using System.Data;
using System.Linq;
using Machine.Specifications;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;
  using TA.Starquest.DataAccess.Entities.QueueWorkItems;
  using TA.Utils.Core;

internal class when_creating_a_picklist_item
    {
    Because of = () => result = new PickListItem<int>(1,"Test Item");
    It should_set_the_display_name = () => result.DisplayName.ShouldEqual("Test Item");
    It should_set_the_key = () => result.Id.ShouldEqual(1);
    private static PickListItem<int> result;
    }
