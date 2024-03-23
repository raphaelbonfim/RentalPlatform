using Common.Messaging;

namespace Common.Domain;

public abstract class Entity: DomainValidationBase
{
    private Guid _id;
    private readonly List<IIntegrationMessage> _domainEvents = new ();

    public virtual Guid Id
    {
        get { return _id; }
        protected set { _id = (value == Guid.Empty ? Guid.NewGuid() : value); }
    }

    public virtual DateTime ModifiedAt { get; protected set; }

    public virtual IReadOnlyList<IIntegrationMessage> DomainEvents => _domainEvents;

    protected virtual void AddDomainEvent(IIntegrationMessage newEvent) {
        _domainEvents.Add(newEvent);
    }

    protected virtual void ClearEvents() {
        _domainEvents.Clear();
    }

    public override bool Equals(object obj)
    {
        var other = obj as Entity;

        if (ReferenceEquals(other, null))
            return false;

        if (Id == Guid.Empty || other.Id == Guid.Empty)
            return false;

        return ReferenceEquals(this, other) && Id == other.Id;
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        var hashCode = (GetType().ToString() + Id).GetHashCode();
        return hashCode;
    }
}