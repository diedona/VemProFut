namespace VemProFut.Domain.Entities.Bases
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        protected BaseEntity() { }
    }
}
