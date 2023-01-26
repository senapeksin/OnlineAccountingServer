﻿using OnlineAccountingServer.Domain.Abstractions;
using System.Linq.Expressions;

namespace OnlineAccountingServer.Domain.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetById(string Id, bool isTracking = true);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetFirst(bool isTracking = true);
    }
}
