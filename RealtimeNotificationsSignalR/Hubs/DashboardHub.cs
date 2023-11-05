using Microsoft.AspNetCore.SignalR;
using RealtimeNotificationsSignalR.Data;
using RealtimeNotificationsSignalR.Repositories;

namespace RealtimeNotificationsSignalR.Hubs;

public class DashboardHub : Hub
{
    private ProductRepository productRepository;
    private readonly ApplicationDbContext _dbContext;

    public DashboardHub(IConfiguration configuration, ApplicationDbContext dbContext)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _dbContext = dbContext;
        productRepository = new ProductRepository(connectionString, _dbContext);
    }

    public async Task SendProducts()
    {
        var products = productRepository.GetProducts();
        await Clients.All.SendAsync("ReceivedProducts", products);
    }
}