namespace Shared.BaseEntities;

public abstract class CreatedTimeTrackableEntity
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
