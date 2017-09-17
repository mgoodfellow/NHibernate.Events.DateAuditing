using FluentNHibernate.Mapping;
using NHibernate.Events.DateAuditing.Example.Model;

namespace NHibernate.Events.DateAuditing.Example.Mapping
{
    public class RecordMap : ClassMap<Record>
    {
        public RecordMap()
        {
            Table("record");

            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Identity();

            // NOTE: Property names must be Created and LastModified, but they can be remapped to different DB columns
            Map(x => x.Created).Column("Created").Not.Nullable();
            Map(x => x.LastModified).Column("LastModified").Not.Nullable();

            Map(x => x.Data).Column("Data").Length(1024).Nullable();
        }
    }
}
