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
// File: QueryableExtensions.cs  Last modified: 2020-08-09@21:29 by Tim Long

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

/*
 * Projection extension method and supporting code was borrowed from
 * http://www.devtrends.co.uk/blog/stop-using-automapper-in-your-data-access-code
 */

namespace TA.Starquest.Core
    {
    public static class QueryableExtensions
        {
        public static ProjectionExpression<TSource> Project<TSource>(this IQueryable<TSource> source)
            {
            return new ProjectionExpression<TSource>(source);
            }
        }

    public class ProjectionExpression<TSource>
        {
        private static readonly Dictionary<string, Expression> ExpressionCache = new Dictionary<string, Expression>();

        private readonly IQueryable<TSource> _source;

        public ProjectionExpression(IQueryable<TSource> source)
            {
            _source = source;
            }

        public IQueryable<TDest> To<TDest>()
            {
            var queryExpression = GetCachedExpression<TDest>() ?? BuildExpression<TDest>();

            return _source.Select(queryExpression);
            }

        private static Expression<Func<TSource, TDest>> GetCachedExpression<TDest>()
            {
            var key = GetCacheKey<TDest>();

            return ExpressionCache.ContainsKey(key) ? ExpressionCache[key] as Expression<Func<TSource, TDest>> : null;
            }

        private static Expression<Func<TSource, TDest>> BuildExpression<TDest>()
            {
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDest).GetProperties().Where(dest => dest.CanWrite);
            var parameterExpression = Expression.Parameter(typeof(TSource), "src");

            var bindings = destinationProperties
                .Select(destinationProperty => BuildBinding(parameterExpression, destinationProperty, sourceProperties))
                .Where(binding => binding != null);

            var expression =
                Expression.Lambda<Func<TSource, TDest>>(Expression.MemberInit(Expression.New(typeof(TDest)), bindings),
                    parameterExpression);

            var key = GetCacheKey<TDest>();

            ExpressionCache.Add(key, expression);

            return expression;
            }

        private static MemberAssignment BuildBinding(Expression parameterExpression, MemberInfo destinationProperty,
            IEnumerable<PropertyInfo> sourceProperties)
            {
            var sourceProperty = sourceProperties.FirstOrDefault(src => src.Name == destinationProperty.Name);

            if (sourceProperty != null)
                {
                return Expression.Bind(destinationProperty, Expression.Property(parameterExpression, sourceProperty));
                }

            var propertyNames = SplitCamelCase(destinationProperty.Name);

            if (propertyNames.Length == 2)
                {
                sourceProperty = sourceProperties.FirstOrDefault(src => src.Name == propertyNames[0]);

                if (sourceProperty != null)
                    {
                    var sourceChildProperty =
                        sourceProperty.PropertyType.GetProperties().FirstOrDefault(src => src.Name == propertyNames[1]);

                    if (sourceChildProperty != null)
                        {
                        return Expression.Bind(destinationProperty,
                            Expression.Property(Expression.Property(parameterExpression, sourceProperty),
                                sourceChildProperty));
                        }
                    }
                }

            return null;
            }

        private static string GetCacheKey<TDest>()
            {
            return string.Concat(typeof(TSource).FullName, typeof(TDest).FullName);
            }

        private static string[] SplitCamelCase(string input)
            {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim().Split(' ');
            }
        }
    }