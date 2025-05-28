namespace Shared.BaseEntities;

/// <summary>
/// Represents an entity that supports soft deletion tracking.
/// Contains metadata about when and by whom the entity was deleted,
/// as well as a flag indicating whether the entity is considered deleted.
/// </summary>
public interface IDeletedTrackable
{
    /// <summary>
    /// The date and time the entity was deleted.
    /// </summary>
    DateTimeOffset DeletedAt { get; set; }

    /// <summary>
    /// The identifier (e.g., username or user ID) of the user who deleted the entity.
    /// </summary>
    string? DeletedBy { get; set; }

    /// <summary>
    /// Indicates whether the entity is marked as deleted.
    /// </summary>
    bool IsDeleted { get; set; }
}
