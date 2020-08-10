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
// File: IQuerySpecification.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System.Linq;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    ///     Represents a query that filters a set of input entities and projects the results onto a set of
    ///     output entities.
    /// </summary>
    /// <typeparam name="TIn">The type of the input entities to be filtered.</typeparam>
    /// <typeparam name="TOut">The type of the projected output entities.</typeparam>
    public interface IQuerySpecification<TIn, out TOut> where TIn : class //where TOut : class
        {
        /// <summary>
        ///     Gets the fetch strategy, which specifies which entities are to be retrieved from storage. Many
        ///     ORMs use "lazy loading" which can lead to the "N+1 Query Problem" if related entities are
        ///     enumerated. The fetch strategy is a hint to whatever ORM is used as to which related entities
        ///     should be loaded eagerly. The ORM or storage engine is free to ignore the hint.
        /// </summary>
        /// <value>The fetch strategy.</value>
        IFetchStrategy<TIn> FetchStrategy { get; }

        /// <summary>Gets the LINQ expression tree (<see cref="IQueryable{T}" /> representing the filter.</summary>
        /// <param name="items">The items to be filtered.</param>
        /// <returns>IQueryable{TOut}, a LINQ query expression with deferred execution.</returns>
        IQueryable<TOut> GetQuery(IQueryable<TIn> items);
        }

    public interface IQuerySpecification<T> : IQuerySpecification<T, T> where T : class { }
    }