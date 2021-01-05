using Booth.Shared;
using Booth.Infrastructure.DataBase;

namespace Booth.Infrastructure.EventDispatching
{
    public interface IHandleEvent<in TEvent> where TEvent : DomainEvent
    {
        void Handle(TEvent @event, DatabaseContext db);
    }
}
