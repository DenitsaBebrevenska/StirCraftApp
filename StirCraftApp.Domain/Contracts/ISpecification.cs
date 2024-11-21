using System.Linq.Expressions;

namespace StirCraftApp.Domain.Contracts;
public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }

    Expression<Func<T, object>>? OrderBy { get; }

    Expression<Func<T, object>>? OrderByDesc { get; }

    List<Expression<Func<T, object>>> Includes { get; }

    List<string> IncludeStrings { get; } //for ThenInclude

    int Take { get; }

    int Skip { get; }

    bool IsPaginationEnabled { get; }

    bool SplitQueryEnabled { get; }

    IQueryable<T> ApplyCriteria(IQueryable<T> query);
}

public interface ISpecification<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>>? Select { get; }
}