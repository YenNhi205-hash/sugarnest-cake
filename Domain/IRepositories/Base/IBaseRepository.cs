namespace Domain.IRepositories.Base;

/// <summary>
/// Defines basic CRUD operations for an entity of type <typeparamref name="T"/>
/// with an identifier of type <typeparamref name="K"/>.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
/// <typeparam name="K">The type of the entity's primary key.</typeparam>
public interface IBaseRepository<T, K>
{
    /// <summary>
    /// Asynchronously retrieves all entities.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.
    /// The task result contains a list of all entities.</returns>
    Task<List<T>> GetAll();

    /// <summary>
    /// Asynchronously retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation.
    /// The task result contains the entity if found; otherwise, null.</returns>
    Task<T?> GetById(K id);

    /// <summary>
    /// Asynchronously creates a new entity.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <returns>A task representing the asynchronous operation.
    /// The task result contains the created entity.</returns>
    Task<T> Create(T entity);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity with updated values.</param>
    /// <returns>The updated entity.</returns>
    T Update(T entity);

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);
}
