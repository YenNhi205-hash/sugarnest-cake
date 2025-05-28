namespace Domain.IRepositories.Base;

/// <summary>
/// Defines a unit of work contract that manages changes across multiple repositories,
/// ensuring that all operations are committed as a single transaction.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves all pending changes to the database in a single transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous save operation.
    /// Returns a string identifier or null depending on the implementation.
    /// </returns>
    Task<string?> SaveChangesAsync(CancellationToken cancellationToken); 
}
