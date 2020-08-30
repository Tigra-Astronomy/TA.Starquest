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
// File: GenericFetchStrategy.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>A default Fetch Strategy that will be suitable for most simple situations.</summary>
    /// <typeparam name="TEntity">Tee type of the root entity being queried</typeparam>
    /// <remarks>
    ///     Borrowed from
    ///     http://blog.willbeattie.net/2011/02/specification-pattern-entity-framework.html
    /// </remarks>
    public class GenericFetchStrategy<TEntity> : IFetchStrategy<TEntity> where TEntity : class
        {
        protected readonly IList<string> properties;

        public GenericFetchStrategy()
            {
            properties = new List<string>();
            }

        #region IFetchStrategy<T> Members
        public IEnumerable<string> IncludePaths => properties;

        public IFetchStrategy<TEntity> Include(Expression<Func<TEntity, object>> path)
            {
            properties.Add(path.ToFetchPath());
            return this;
            }

        public IFetchStrategy<TEntity> Include(string path)
            {
            properties.Add(path);
            return this;
            }
        #endregion
        }
    }