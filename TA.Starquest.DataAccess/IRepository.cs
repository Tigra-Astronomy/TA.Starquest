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
// File: IRepository.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.QuerySpecifications;
using TA.Utils.Core;

namespace TA.Starquest.DataAccess
    {
    /// <summary>
    ///     Generic repository interface which must be implemented by all repositories that participate in
    ///     a Unit of Work.
    /// </summary>
    /// <remarks>
    ///     This generic interface is database and application independent and is one of the key
    ///     articulation points in the application architecture. The interface defines behaviours that are
    ///     common to all repositories and provide the foundation for entity repositories to specialise
    ///     into a selection of queries and operations required by the business logic.
    /// </remarks>
    /// <typeparam name="TEntity">The type of entity contained in the repository.</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public interface IRepository<TEntity, TKey> where TEntity : class, IDomainEntity<TKey>
        {
        /// <summary>Gets the pick list (a collection of key-value pairs).</summary>
        /// <value>The pick list.</value>
        IEnumerable<PickListItem<TKey>> PickList { get; }

        /// <summary>Gets the specified entity.</summary>
        /// <param name="id">The entity ID.</param>
        TEntity Get(TKey id);

        /// <summary>Gets an enumerable collection of all entities in the entity set.</summary>
        /// <returns><see cref="System.Collections.Generic.IEnumerable{T}" />.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>Gets all entities that satisfy a <paramref name="predicate" />.</summary>
        /// <param name="predicate">A predicate expression tree.</param>
        /// <returns>
        ///     An <see cref="System.Collections.Generic.IEnumerable{T}" /> containing all entities that
        ///     satisfy the predicate.
        /// </returns>
        [Obsolete("Define a Query Specification and use AllSatisfying(specification)")]
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>Adds one entity to the entity set.</summary>
        /// <param name="entity">The entity to add.</param>
        void Add(TEntity entity);

        /// <summary>Adds entities to the entity set.</summary>
        /// <param name="entities">The entities.</param>
        void Add(IEnumerable<TEntity> entities);

        /// <summary>Removes one entity from the entity set.</summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(TEntity entity);

        /// <summary>Removes entities from the entity set.</summary>
        /// <param name="entities">The entities.</param>
        void Remove(IEnumerable<TEntity> entities);

        /// <summary>Gets a single entity by ID, if it exists.</summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>
        ///     A <see cref="TA.Utils.Core.Maybe{T}" /> that either contains the matched entity, or is
        ///     empty.
        /// </returns>
        Maybe<TEntity> GetMaybe(TKey id);

        /// <summary>
        ///     Gets at most one item that matches a query specification. Throws an exception if there is more
        ///     than one one matching item.
        /// </summary>
        /// <param name="specification">A query specification for the desired entity</param>
        /// <returns>Zero or one items in a <see cref="TA.Utils.Core.Maybe{T}" />.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if there is not exactly one match.</exception>
        Maybe<TOut> GetMaybe<TOut>(IQuerySpecification<TEntity, TOut> specification) where TOut : class;

        /// <summary>Gets all entities that satisfy the supplied specification.</summary>
        /// <param name="specification">A specification that determines which entities should be returned.</param>
        /// <returns>A collection of all entities satisfying the specification.</returns>
        IEnumerable<TOut> AllSatisfying<TOut>(IQuerySpecification<TEntity, TOut> specification) where TOut : class;
        }
    }