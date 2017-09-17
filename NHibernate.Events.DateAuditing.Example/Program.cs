using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Events.DateAuditing.Example.Mapping;

namespace NHibernate.Events.DateAuditing.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var fluentConfig = Fluently.Configure()
                .Database(
                    MySQLConfiguration.Standard.Dialect<MySQL55InnoDBDialect>()
                        .ConnectionString(c => c.FromConnectionStringWithKey("DbConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RecordMap>());

            var cfg = fluentConfig.BuildConfiguration();

            // Assign the event listeners
            cfg.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[]
                    {
                        new DateAuditableEventListener()
                    };
            cfg.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[]
                {
                        new DateAuditableEventListener()
                };

            var sessionFactory = cfg.BuildSessionFactory();

            // Use sessionFactory
        }
    }
}
