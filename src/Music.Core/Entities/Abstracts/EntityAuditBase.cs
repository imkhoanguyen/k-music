namespace Music.Core.Entities.Abstracts
{
    public abstract class EntityAuditBase<T> : EntityBase<T>
    {
        public DateTimeOffset? LastModifiedDate { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
