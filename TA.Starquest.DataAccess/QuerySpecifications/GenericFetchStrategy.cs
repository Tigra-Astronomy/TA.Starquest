// This file is part of the MS.Gamification project
// 
// File: GenericFetchStrategy.cs  Created: 2016-07-09@20:14
// Last modified: 2016-08-11@05:40

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    ///     A default Fetch Strategy that will be suitable for most simple situations.
    /// </summary>
    /// <typeparam name="TEntity">Tee type of the root entity being queried</typeparam>
    /// <remarks>
    ///     Borrowed from http://blog.willbeattie.net/2011/02/specification-pattern-entity-framework.html
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