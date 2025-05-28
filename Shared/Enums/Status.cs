namespace Shared.Enums;

/// <summary>
/// Represents the status of an item.
/// </summary>
public enum Status
{
    /// <summary>
    /// The item is active and available.
    /// </summary>
    InActive = 0,

    /// <summary>
    /// The item is inactive and not available.
    /// </summary>
    Active = 1,

    /// <summary>
    /// The item is sold out.
    /// </summary>
    SoldOut = 2
}
