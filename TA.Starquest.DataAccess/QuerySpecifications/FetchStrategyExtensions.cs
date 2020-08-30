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
// File: FetchStrategyExtensions.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System;
using System.Linq.Expressions;
using System.Text;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>Extension methods used by <see cref="GenericFetchStrategy{TEntity}" /></summary>
    /// <remarks>
    ///     Borrowed from
    ///     http://blog.willbeattie.net/2011/02/specification-pattern-entity-framework.html
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

        /// <summary>Visits MemberExpression nodes in an expression tree and extracts the member names.</summary>
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