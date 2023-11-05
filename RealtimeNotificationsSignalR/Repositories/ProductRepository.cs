using RealtimeNotificationsSignalR.Data;
using RealtimeNotificationsSignalR.Models;

namespace RealtimeNotificationsSignalR.Repositories;

public class ProductRepository
{
    string connectionString;
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(string connectionString, ApplicationDbContext dbContext)
    {
        this.connectionString = connectionString;
        this._dbContext = dbContext;
    }

    public List<Product> GetProducts()
    {
        var prodList = _dbContext.Products.ToList();
        foreach (var product in prodList)
        {
            _dbContext.Entry(product).Reload();
        }

        return prodList;
    }
}