namespace Shared.BaseEntities;

/// <summary>
/// Represents an entity that tracks the last update metadata,
/// including when it was last modified and by whom.
/// </summary>
public interface ILastUpdatedTrackable
{
    /// <summary>
    /// The date and time the entity was last updated.
    /// </summary>
    DateTimeOffset LastUpdatedAt { get; set; }

    /// <summary>
    /// The identifier (e.g., username or user ID) of the user who last updated the entity.
    /// </summary>
    string? LastUpdatedBy { get; set; }
}