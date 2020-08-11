// This file is part of the MS.Gamification project
// 
// File: FetchStrategyExtensions.cs  Created: 2016-07-09@20:14
// Last modified: 2016-08-11@07:18

using System;
using System.Linq.Expressions;
using System.Text;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    ///     Extension methods used by <see cref="GenericFetchStrategy{TEntity}" />
    /// </summary>
    /// <remarks>
    ///     Borrowed from http://blog.willbeattie.net/2011/02/specification-pattern-entity-framework.html
    /// </remarks>
    public static class FetchStrategyExtensions
        {
        [Obsolete("Use ToFetchPath<T> instead", true)]
        public static string ToPropertyName<T>(this Expression<Func<T, object>> selector)
            {
            var me = selector.Body as MemberExpression;
            if (me == null)
                {
                throw new ArgumentException("MemberException expected.");
                }

            var propertyName = me.ToString().Remove(0, 2);
            return propertyName;
            }

        public static string ToFetchPath<T>(this Expression<Func<T, object>> selector)
            {
            var visitor = new FetchPathExpressionVisitor();
            visitor.Visit(selector);
            return visitor.FetchPath;
            }

        /// <summary>
        ///     Visits MemberExpression nodes in an expression tree and extracts the member names.
        /// </summary>
        /// <seealso cref="System.Linq.Expressions.ExpressionVisitor" />
        private class FetchPathExpressionVisitor : ExpressionVisitor
            {
            private readonly StringBuilder path = new StringBuilder();

            public string FetchPath
                {
                get
                    {
                    if (path.Length <= 0)
                        return string.Empty;
                    --path.Length; // discard the trailing dot
                    return path.ToString();
                    }
                }

            protected override Expression VisitMember(MemberExpression node)
                {
                Visit(node.Expression);
                path.Append(node.Member.Name);
                path.Append('.');
                return node;
                }
            }
        }
    }