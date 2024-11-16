namespace AppMVC.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(Guid entityId);
    public Task CreateAsync(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public Task SaveChangesAsync();
}