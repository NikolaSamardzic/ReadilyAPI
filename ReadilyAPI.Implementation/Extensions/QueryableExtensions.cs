using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResponse<TResult> AsPagedReponse<TEntity, TResult>
            (this IEnumerable<TEntity> query, PagedSearch search, IMapper mapper)
            where TEntity : class
            where TResult : class
        {

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            var result = query.ToList();

            return new PagedResponse<TResult>
            {
                CurrentPage = page,
                Items = mapper.Map<IEnumerable<TResult>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IEnumerable<TSource> IncludeIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IEnumerable<TSource> IncludeIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public static IQueryable<T> IncludeIf<T, TProperty>(
        this IQueryable<T> query,
        bool condition,
        Expression<Func<T, TProperty>> includeExpression)
        where T : class
        {
            if (condition)
            {
                return query.Include(includeExpression);
            }
            return query;
        }
    }
}
