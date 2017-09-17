using System;

namespace NHibernate.Events.DateAuditing
{
    public interface IDateModifiedAuditable
    {
        DateTime LastModified { get; set; }
    }
}