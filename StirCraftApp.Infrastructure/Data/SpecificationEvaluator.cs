using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Infrastructure.Data;

/// <summary>
/// A static class responsible for evaluating specifications and applying them to an IQueryable query.
/// This class applies filtering, ordering, pagination, eager loading, and split queries based on the provided specification.
/// </summary>
/// <typeparam name="T">The type of entity that the specification applies to.</typeparam>
public static class SpecificationEvaluator<T> where T : class
{
    /// <summary>
    /// Applies the criteria defined in the specification to the given query and returns the modified query.
    /// The method supports filtering, ordering, pagination, eager loading, and split queries.
    /// </summary>
    /// <param name="query">The base query to apply the specification to.</param>
    /// <param name="spec">The specification that defines the query modifications.</param>
    /// <returns>A modified <see cref="IQueryable{T}"/> with the specification applied.</returns>
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }

        if (spec.OrderByDesc != null)
        {
            query = query.OrderByDescending(spec.OrderByDesc);
        }

        if (spec.IsPaginationEnabled)
        {
            query = query.Skip(spec.Skip)
                .Take(spec.Take);
        }

        if (spec.SplitQueryEnabled)
        {
            query = query.AsSplitQuery();
        }

        //Eager loading
        query = spec.Includes
            .Aggregate(query, (current, include)
                => current.Include(include));

        query = spec.IncludeStrings
            .Aggregate(query, (current, include)
                => current.Include(include));

        return query;
    }

}

