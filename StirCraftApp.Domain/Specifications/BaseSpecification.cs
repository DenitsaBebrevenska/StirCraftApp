﻿using StirCraftApp.Domain.Contracts;
using System.Linq.Expressions;

namespace StirCraftApp.Domain.Specifications;
public abstract class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected BaseSpecification() : this(null) { }
    public Expression<Func<T, bool>>? Criteria => criteria;
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDesc { get; private set; }
    public List<Expression<Func<T, object>>> Includes { get; private set; } = [];
    public List<string> IncludeStrings { get; } = [];
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPaginationEnabled { get; private set; }
    public bool SplitQueryEnabled { get; private set; }
    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
        if (Criteria != null)
        {
            query = query.Where(Criteria);
        }

        return query;
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddIncludeStrings(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDesc = orderByDescExpression;
    }

    protected void AddPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPaginationEnabled = true;
    }

}