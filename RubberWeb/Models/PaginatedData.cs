using RubberWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RubberWeb.Models
{
    public class PaginatedData<TModel>
    {
        public List<TModel> Data { get; set; }
        public int Page { get; set; }
        public long TotalItemsCount { get; set; }
        public bool CanNext { get; set; }
        public bool CanPrev { get; set; }

        public static PaginatedData<TModel> Create<TEntity>(IQueryable<TEntity> query, PaginatedRequest request, Func<TEntity, TModel> mapper)
        {
            if (request.Page <= 1)
                request.Page = 0;

            var data = new PaginatedData<TModel>()
            {
                Page = request.Page == 0 ? 1 : request.Page,
                TotalItemsCount = query.Count(),
            };

            var skip = PaginationHelper.CountSkipValue(request);
            
            data.CanNext = skip + request.Limit < data.TotalItemsCount;
            data.CanPrev = skip > 0;

            query = query.Skip(skip).Take(request.Limit);
            data.Data = query.AsEnumerable().Select(mapper).ToList();

            return data;
        }
    }
}
