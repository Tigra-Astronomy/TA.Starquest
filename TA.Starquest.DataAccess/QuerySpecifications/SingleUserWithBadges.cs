﻿// This file is part of the TA.Starquest project
// 
// Copyright © 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: SingleUserWithBadges.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
        /// <summary>
        ///     Queries a single user and eagerly loads the user's badges.
        /// </summary>
        public class SingleUserWithBadges : QuerySpecification<ApplicationUser>
        {
        private readonly string userId;

        public SingleUserWithBadges(string userId)
            {
            this.userId = userId;
            FetchStrategy.Include(p => p.UserBadges);
            }

        public override IQueryable<ApplicationUser> GetQuery(IQueryable<ApplicationUser> items)
            {
            var query = from user in items
                        where user.Id == userId
                        select user;
            return query;
            }
        }
    }