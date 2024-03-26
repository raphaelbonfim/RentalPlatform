using Domain.Repositories;
using NHibernate;

public class UnitOfWorkImpl : UnitOfWork, IUnitOfWorkDomain
{
    public UnitOfWorkImpl(ISession session) : base(session) {}
}