using RubberWeb.Entity;
using RubberWeb.Models;
using System;
using System.Linq;

namespace RubberWeb.Services
{
    public class AppDbRepository : IDisposable
    {
        private AppDbContext Context { get; }

        public AppDbRepository(AppDbContext context)
        {
            Context = context;
        }

        public IQueryable<KarmaItem> GetKarma(PageSort sort)
        {
            var query = Context.Karma.AsQueryable();

            if (sort == PageSort.Asc)
                return query.OrderBy(o => o.Karma);

            return query.OrderByDescending(o => o.Karma);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
