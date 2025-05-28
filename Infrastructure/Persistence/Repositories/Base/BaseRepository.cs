using Domain.IRepositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Base;

/// <summary>
/// Provides a base implementation of the generic repository pattern.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="K">The type of the entity's identifier.</typeparam>
public class BaseRepository<T, K> : IBaseRepository<T, K> where T : class
{
    protected SugarNestDbContext context;

    public BaseRepository(SugarNestDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Creates a new entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains the created entity.</returns>
    public async Task<T> Create(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        return entity;
    }

    /// <summary>
    /// Deletes an existing entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains true if the entity was deleted successfully; otherwise, false.</returns>
    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    /// <summary>
    /// Retrieves all entities from the repository.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains a list of all entities.</returns>
    public async Task<List<T>> GetAll() => await context.Set<T>().ToListAsync();

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains the entity if found; otherwise, null.</returns>
    public async Task<T?> GetById(K id) => await context.Set<T>().FindAsync(id);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity with updated information.</param>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains the updated entity.</returns>
    public T Update(T entity)
    {
        context.Set<T>().Update(entity);
        return entity;
    }
}

