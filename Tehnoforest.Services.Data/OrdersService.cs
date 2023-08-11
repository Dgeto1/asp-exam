namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Order;
    using static Tehnoforest.Common.GeneralApplicationConstants;
    public class OrdersService : IOrdersService
    {
        private readonly TehnoforestDbContext dbContext;
        public OrdersService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await this.dbContext.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Include(n => n.User).ToListAsync();

            if (userRole != AdminRoleName)
            {
                orders = orders.Where(n => n.UserId.ToString() == userId).ToList();
            }

            return orders;
        }

        public async Task<IEnumerable<OrderViewModel>> AllAsync()
        {
            List<OrderViewModel> allOrders = await this.dbContext
                .Orders
                .Select(u => new OrderViewModel()
                {
                  Email = u.Email,
                  UserName = u.User.FirstName + " " + u.User.LastName,
                  OrderItems = u.OrderItems
                })
                .ToListAsync();

            return allOrders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = new Guid(userId),
                Email = userEmailAddress
            };
            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };
                await this.dbContext.OrderItems.AddAsync(orderItem);
            }
            await this.dbContext.SaveChangesAsync();
        }
    }
}
