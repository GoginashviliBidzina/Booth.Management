using System.Collections.Generic;
using Booth.Infrastructure.DataBase;

namespace Booth.Infrastructure.EventDispatching
{
    public interface IInternalEventDispatcher<TDomainEvent>
    {
        void Dispatch(IReadOnlyList<TDomainEvent> domainEvents, DatabaseContext dbContext);
    }
}
