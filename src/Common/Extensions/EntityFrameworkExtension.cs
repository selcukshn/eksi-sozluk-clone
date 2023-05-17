using Common.Models.Page;
using Microsoft.EntityFrameworkCore;

namespace Common.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static async Task<PagedViewModel<T>> ToPagedAsync<T>(this IQueryable<T> queryable, int take, int current)
        where T : class, new()
        {
            var page = new Page(await queryable.CountAsync(), take, current);
            var entity = await queryable.Skip(page.Skip).Take(page.Take).AsNoTracking().ToListAsync();
            return new PagedViewModel<T>(page, entity);
        }
    }
}