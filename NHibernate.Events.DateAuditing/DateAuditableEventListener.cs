using System;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace NHibernate.Events.DateAuditing
{
    public class DateAuditableEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as IDateModifiedAuditable;
            if (audit == null)
                return false;

            var time = DateTime.UtcNow;

            Set(@event.Persister, @event.State, nameof(IDateModifiedAuditable.LastModified), time);

            audit.LastModified = time;
            return false;
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var time = DateTime.UtcNow;

            var createdAuditable = @event.Entity as IDateCreatedAuditable;
            if (createdAuditable != null)
            {
                Set(@event.Persister, @event.State, nameof(IDateCreatedAuditable.Created), time);
                createdAuditable.Created = time;
            }

            var modifiedAuditable = @event.Entity as IDateModifiedAuditable;
            if (modifiedAuditable != null)
            {
                Set(@event.Persister, @event.State, nameof(IDateModifiedAuditable.LastModified), time);
                modifiedAuditable.LastModified = time;
            }

            return false;
        }

        private static void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);

            if (index == -1)
            {
                return;
            }

            state[index] = value;
        }
    }
}
