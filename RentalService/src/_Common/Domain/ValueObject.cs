namespace Common.Domain;

public abstract class ValueObject<T> : DomainValidationBase where T : ValueObject<T>
{
    protected abstract IEnumerable<object> AttributesToEqualityCheck();
        
    public override bool Equals(object other)
    {
        var valueObject = other as T;

        if (ReferenceEquals(valueObject, null))
            return false;

        return Equals(valueObject);
    }

    public bool Equals(T other)
    {
        if (other == null)
        {
            return false;
        }

        return AttributesToEqualityCheck()
            .SequenceEqual(other.AttributesToEqualityCheck());
    }

    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var obj in AttributesToEqualityCheck())
        {
            hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());
        }

        return hash;
    }

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }
}