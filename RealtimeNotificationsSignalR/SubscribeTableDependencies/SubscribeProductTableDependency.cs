using RealtimeNotificationsSignalR.Hubs;
using RealtimeNotificationsSignalR.Models;
using TableDependency.SqlClient;

namespace RealtimeNotificationsSignalR.SubscribeTableDependencies;

public class SubscribeProductTableDependency : ISubscribeTableDependency
{
    SqlTableDependency<Product> tableDependency;
    DashboardHub dashboardHub;

    public SubscribeProductTableDependency(DashboardHub dashboardHub)
    {
        this.dashboardHub = dashboardHub;
    }

    public void SubscribeTableDependency(string connectionString)
    {
        tableDependency = new SqlTableDependency<Product>(connectionString);
        tableDependency.OnChanged += TableDependency_OnChanged;
        tableDependency.OnError += TableDependency_OnError;
        tableDependency.Start();
    }

    public async void TableDependency_OnChanged(object sender,
        TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
    {
        if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
        {
            await dashboardHub.SendProducts();
        }
    }

    public void TableDependency_OnError(object sender,
        TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
    {
        Console.WriteLine($"{nameof(Product)} SqlTableDependency error: {e.Error.Message}");
    }
}