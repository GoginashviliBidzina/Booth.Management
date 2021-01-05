using System.Collections.Generic;

namespace Booth.Shared
{
    public interface IHasDomainEvents
    {
        IReadOnlyList<DomainEvent> UncommittedChanges();

        void MarkChangesAsCommitted();

        void Raise(DomainEvent @event);
    }
}