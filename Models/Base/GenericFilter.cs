using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using X.PagedList.Extensions;

namespace MyApp.Models.Base
{
    public static class GenericFilter
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> source, Dictionary<string, string> filters)
        {
            foreach (var filter in filters)
            {
                if (!string.IsNullOrEmpty(filter.Value))
                {
                    var parameter = Expression.Parameter(typeof(T), "item");
                    var property = Expression.Property(parameter, filter.Key);

                    // Convert the property to string and to lowercase
                    var toStringCall = Expression.Call(property, "ToString", null);
                    var toLowerCall = Expression.Call(toStringCall, nameof(string.ToLower), null);

                    // Convert the filter value to lowercase
                    var filterValue = Expression.Constant(filter.Value.ToLower(), typeof(string));

                    // Call Contains on the lowercase property and filter value
                    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                    var containsExpression = Expression.Call(toLowerCall, containsMethod, filterValue);

                    // Create the lambda expression
                    var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);

                    // Apply the filter
                    source = source.Where(lambda);
                }
            }

            return source;
        }
    }
}
