using System;

namespace NHibernate.Events.DateAuditing
{
    public interface IDateCreatedAuditable
    {
        DateTime Created { get; set; }
    }
}
