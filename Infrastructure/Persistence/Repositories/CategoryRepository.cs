using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository implementation for handling <see cref="Category"/> entities.
/// Provides additional methods to retrieve only valid categories (i.e., not deleted and not inactive).
/// </summary>
public class CategoryRepository(SugarNestDbContext context)
    : BaseRepository<Category, Guid>(context), ICategoryRepository
{
    /// <summary>
    /// Asynchronously retrieves all valid categories.
    /// A valid category is one that is not marked as deleted and does not have a status of <see cref="Status.InActive"/>.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of valid <see cref="Category"/> entities.
    /// </returns>
    public async Task<List<Category>> GetAllValid()
    {
        return await context.Categories
            .Where(c => !c.IsDeleted && c.Status != Status.InActive)
            .ToListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves a valid category by its unique identifier.
    /// A valid category is one that exists, is not marked as deleted, and does not have a status of <see cref="Status.InActive"/>.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the valid <see cref="Category"/> if found; otherwise, null.
    /// </returns>
    public async Task<Category?> GetValidById(Guid id)
    {
        var existedEntity = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (existedEntity == null || existedEntity.IsDeleted || existedEntity.Status == Status.InActive)
            return null;

        return existedEntity;
    }
}

