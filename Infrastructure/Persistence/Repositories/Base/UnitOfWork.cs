using Domain.IRepositories.Base;

namespace Infrastructure.Persistence.Repositories.Base;

/// <summary>
/// Implements the unit of work pattern using Entity Framework Core.
/// Coordinates the writing of changes to the database across multiple repositories.
/// </summary>
public class UnitOfWork(SugarNestDbContext context) : IUnitOfWork
{
    /// <summary>
    /// Saves all changes made in the current context to the database.
    /// Returns null if successful; otherwise, returns the exception message.
    /// </summary>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// Returns null if the operation succeeds, or the exception message if it fails.
    /// </returns>
    public async Task<string?> SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await context.SaveChangesAsync(cancellationToken);
            return null;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
