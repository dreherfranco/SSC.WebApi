using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SSC.Repositorio.Helpers
{
    public static class IQueryManagerExtensions
    {
       
        public static IQueryable<T> Include<T, TProperty>(this IQueryManager<T> manager, Expression<Func<T, TProperty>> includeExpression) where T : class
        {
            return manager.Where(null).Include(includeExpression);
        }

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> manager, Expression<Func<T, TProperty>> includeExpression) where T : class
        {
            return manager.Include(includeExpression);
        }
    }
}
