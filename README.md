# RealtimeNotificationsSignalR
Realtime Notifications in .NET using SignalR and SQL TableDependency


```sql
USE realtime;
SELECT * FROM Products;

SELECT is_broker_enabled FROM sys.databases WHERE name='realtime';
ALTER DATABASE realtime SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;
```