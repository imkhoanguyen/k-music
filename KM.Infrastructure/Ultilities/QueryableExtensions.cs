﻿using KM.Application.Utilities;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.Ultilities
{
    public static class QueryableExtensions
    {
        public static async Task<PagedList<T>> ApplyPaginationAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var totalItems = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, totalItems, page, pageSize);
        }
    }
}