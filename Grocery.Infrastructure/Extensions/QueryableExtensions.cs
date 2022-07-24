using System.Linq.Expressions;
using System.Reflection;

namespace Grocery.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        private static readonly MethodInfo OrderByMethod = typeof(Queryable) //work on this type...
            .GetMethods() //..give all methods...
            .Where(method => method.Name == "OrderBy") // ..with this name..
            .Where(method => method.GetParameters().Length == 2) //..that has 2 params..
            .Single();// ... give me the one

        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable) //work on this type...
            .GetMethods() //..give all methods...
            .Where(method => method.Name == "OrderByDescending") // ..with this name..
            .Where(method => method.GetParameters().Length == 2) //..that has 2 params..
            .Single();// ... give me the one

        public static IQueryable<TSource> OrderByProperty<TSource>(this IQueryable<TSource> source, string propertyName)
        {

            // we wanto to do... : x => x.<proprietà> (es. x => x.Date)

            // x
            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "x");

            // x.<propertyName>
            Expression orderByProperty = Expression.Property(parameter, propertyName);

            // x => x.<propertyName>
            LambdaExpression lambda = Expression.Lambda(orderByProperty, new[] { parameter });


            MethodInfo genericMethod = OrderByMethod.MakeGenericMethod
                (new[] { typeof(TSource), orderByProperty.Type });

            object? ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return ret != null ? (IQueryable<TSource>)ret : throw new Exception("Invoke failed!!!");

        }

        public static IQueryable<TSource> OrderByDescendingProperty<TSource>(this IQueryable<TSource> source, string propertyName)
        {

            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "x");

            Expression orderByProperty = Expression.Property(parameter, propertyName);

            LambdaExpression lambda = Expression.Lambda(orderByProperty, new[] { parameter });

            MethodInfo genericMethod = OrderByDescendingMethod.MakeGenericMethod
                (new[] { typeof(TSource), orderByProperty.Type });

            object? ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return ret != null ? (IQueryable<TSource>)ret : throw new Exception("Invoke failed!!!");

        }

    }
}
