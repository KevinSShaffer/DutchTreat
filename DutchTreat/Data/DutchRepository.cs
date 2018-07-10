using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext context;
        private readonly ILogger<DutchRepository> logger;

        public DutchRepository(DutchContext context, ILogger<DutchRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders
                .Include(order => order.Items)
                .ThenInclude(item => item.Product)
                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            logger.LogInformation("Getting all products!~");

            return context.Products
                .OrderBy(product => product.Title)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders
                .Include(order => order.Items)
                .ThenInclude(item => item.Product)
                .Where(order => order.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return context.Products
                .Where(product => product.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
