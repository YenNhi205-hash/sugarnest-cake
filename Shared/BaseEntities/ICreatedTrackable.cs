namespace Shared.BaseEntities;

/// <summary>
/// Represents an entity that tracks creation metadata,
/// including when it was created and by whom.
/// </summary>
public interface ICreatedTrackable
{
    /// <summary>
    /// The date and time when the entity was created.
    /// </summary>
    DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The identifier (e.g., username or user ID) of the user who created the entity.
    /// </summary>
    string? CreatedBy { get; set; }
}

