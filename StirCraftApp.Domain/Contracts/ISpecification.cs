﻿using System.Linq.Expressions;

namespace StirCraftApp.Domain.Contracts;
public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }

    Expression<Func<T, object>>? OrderBy { get; }

    Expression<Func<T, object>>? OrderByDesc { get; }
}

public interface ISpecification<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>>? Select { get; }
}