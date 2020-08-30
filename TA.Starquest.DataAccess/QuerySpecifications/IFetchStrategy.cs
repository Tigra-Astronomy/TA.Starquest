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
// File: IFetchStrategy.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    ///     Defines an abstraction that enables a query to specify eager loading of related entities.
    ///     Entity Framework normally uses lazy loading by default and this can lead to inefficient
    ///     queries, notably the "N+1" problem (see
    ///     http://stackoverflow.com/questions/97197/what-is-the-n1-selects-issue).
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <remarks>
    ///     Borrowed from
    ///     http://blog.willbeattie.net/2011/02/specification-pattern-entity-framework.html
    /// </remarks>
    public interface IFetchStrategy<TEntity> where TEntity : class
        {
        IEnumerable<string> IncludePaths { get; }

        IFetchStrategy<TEntity> Include(Expression<Func<TEntity, object>> path);

        IFetchStrategy<TEntity> Include(string path);
        }
    }