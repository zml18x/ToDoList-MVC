using AppMVC.Application.Exceptions;
using AppMVC.Domain.Repositories;

namespace AppMVC.Application.Extensions;

public static class RepositoryExtensions
{
    public static async Task<T> GetOrThrowAsync<T>(this IRepository<T> repository, Func<Task<T?>> getEntityFunc) where T : class
    {
        var entity = await getEntityFunc();
        if (entity == null)
            throw new NotFoundException($"{typeof(T).Name} was not found.");

        return entity;
    }
}