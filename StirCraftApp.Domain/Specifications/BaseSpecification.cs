using StirCraftApp.Domain.Contracts;
using System.Linq.Expressions;

namespace StirCraftApp.Domain.Specifications;

/// <summary>
/// Represents a base specification for querying and filtering entities of type <typeparamref name="T"/>.
/// Provides mechanisms to apply filtering, ordering, including related entities, and pagination.
/// </summary>
/// <typeparam name="T">The type of the entity being queried.</typeparam>
public abstract class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseSpecification{T}"/> class with optional filtering criteria.
    /// </summary>
    /// <param name="criteria">An optional expression used to filter entities.</param>
    protected BaseSpecification() : this(null) { }

    /// <summary>
    /// Gets the filtering criteria applied to the query.
    /// </summary>
    public Expression<Func<T, bool>>? Criteria => criteria;

    /// <summary>
    /// Gets the ordering criteria for ascending order.
    /// </summary>

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    /// <summary>
    /// Gets the ordering criteria for descending order.
    /// </summary>
    public Expression<Func<T, object>>? OrderByDesc { get; private set; }

    /// <summary>
    /// Gets the list of expressions specifying related entities to include in the query.
    /// </summary>
    public List<Expression<Func<T, object>>> Includes { get; private set; } = [];

    /// <summary>
    /// Gets the list of navigation property paths as strings to include in the query.
    /// Useful for string-based includes.
    /// </summary>
    public List<string> IncludeStrings { get; } = [];

    /// <summary>
    /// Gets the number of records to retrieve (pagination).
    /// </summary>
    public int Take { get; private set; }

    /// <summary>
    /// Gets the number of records to skip (pagination).
    /// </summary>
    public int Skip { get; private set; }

    /// <summary>
    /// Indicates whether pagination is enabled for the query.
    /// </summary>
    public bool IsPaginationEnabled { get; private set; }

    /// <summary>
    /// Indicates whether the query should be split to improve performance in certain scenarios.
    /// </summary>
    public bool SplitQueryEnabled { get; private set; }

    /// <summary>
    /// Applies the filtering criteria to the given query.
    /// </summary>
    /// <param name="query">The query to which the filtering criteria is applied.</param>
    /// <returns>The modified query with the filtering criteria applied.</returns>
    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
        if (Criteria != null)
        {
            query = query.Where(Criteria);
        }

        return query;
    }

    /// <summary>
    /// Adds an expression to include related entities in the query.
    /// </summary>
    /// <param name="includeExpression">The expression specifying the related entity to include.</param>
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    /// <summary>
    /// Adds a navigation property path as a string to include related entities in the query.
    /// </summary>
    /// <param name="includeString">The string specifying the related entity to include.</param>
    protected void AddIncludeStrings(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    /// <summary>
    /// Specifies an expression to order the query in ascending order.
    /// </summary>
    /// <param name="orderByExpression">The expression specifying the property to order by.</param>
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    /// <summary>
    /// Specifies an expression to order the query in descending order.
    /// </summary>
    /// <param name="orderByDescExpression">The expression specifying the property to order by.</param>
    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDesc = orderByDescExpression;
    }

    /// <summary>
    /// Enables pagination for the query by specifying the number of records to skip and take.
    /// </summary>
    /// <param name="skip">The number of records to skip.</param>
    /// <param name="take">The number of records to retrieve.</param>
    protected void AddPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPaginationEnabled = true;
    }

}