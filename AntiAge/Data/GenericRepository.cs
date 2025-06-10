using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace AntiAge.Api.Data
{
    public class GenericRepository
    {
        private DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        protected async Task<List<TResult>> GetPagedAsync<T, TResult>(
            int page,
            int pageSize,
            Expression<Func<T, bool>> filter,
            Expression<Func<T, object>> ordering,
            Expression<Func<T, TResult>> selector
        ) where T : class
        {
            int pagesToSkip = (page - 1) * pageSize;

            var pagedResult = await context.Set<T>()
                //.Where(filter)
                //.OrderBy(ordering)
                .Skip(pagesToSkip)
                .Take(pageSize)
                .Select(selector)
                .ToListAsync();

            if (pagedResult.Count == 0)
            {
                throw new InvalidOperationException("Pagination retrieved invalid count.");
            }

            return pagedResult;

        }
    }
}