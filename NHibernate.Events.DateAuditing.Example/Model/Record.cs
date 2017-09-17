using System;

namespace NHibernate.Events.DateAuditing.Example.Model
{
    public class Record : IDateCreatedAuditable, IDateModifiedAuditable
    {
        public virtual int Id { get; set; }

        public virtual DateTime Created { get; set; }
        public virtual DateTime LastModified { get; set; }

        public virtual string Data { get; set; }
    }
}
