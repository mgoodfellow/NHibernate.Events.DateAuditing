# NHibernate.Events.DateAuditing

A small example on using EventListeners in NHibernate to make automated auditing for standard DB table features.

This example focuses directly on Created and LastModified fields. Updating these fields in code is prone to errors and mistakes, and should be handled by the ORM.

This can be expanded to add a whole range of event listeners as required.

## Explanation

The NHibernate.Events.DateAuditing project contains 3 files:

* `DateAuditableEventListener` - This will capture certain events from NHibernate, and perform actions on entities before they are flushed
* `IDateCreatedAuditable` & `IDateModifiedAuditable` - These interfaces are put onto DTOs and are used to tag the entities which need to be processed by the event handlers

Check out `NHibernate.Events.DateAuditing.Example` project for a simple demonstration of setting up a `SessionFactory` with the required event listeners linked in.

## Dependencies

* `NHibernate`
* `Fluent.NHibernate`

