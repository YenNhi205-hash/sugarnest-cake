using Domain.Entities;
using Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories;

/// <summary>
/// Repository interface for managing <see cref="Category"/> entities,
/// extending the basic CRUD operations with additional category-specific queries.
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category, Guid>
{
    /// <summary>
    /// Asynchronously retrieves all categories that are considered valid (e.g., active and not deleted).
    /// </summary>
    /// <returns>A list of valid categories.</returns>
    Task<List<Category>> GetAllValid();

    /// <summary>
    /// Asynchronously retrieves a valid category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>The category if found and valid; otherwise, null.</returns>
    Task<Category?> GetValidById(Guid id);
}

