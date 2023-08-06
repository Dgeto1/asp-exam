using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Tehnoforest.Data.Models;
using Tehnoforest.Data;
using Microsoft.EntityFrameworkCore;

namespace Tehnoforest.Services.Data
{
    public class ShoppingCart
    {
        public TehnoforestDbContext dbContext { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
            //this.ShoppingCartItems = new List<ShoppingCartItem>();
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<TehnoforestDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Product product)
        {
            var shoppingCartItem = this.dbContext
                .ShoppingCartItems
                .FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                this.dbContext.
                    ShoppingCartItems.
                    Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            this.dbContext.SaveChanges();
        }

        public void RemoveItemFromCart(Product product)
        {
            var shoppingCartItem = this.dbContext
                .ShoppingCartItems
                .FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    this.dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            this.dbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = this.dbContext
                .ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(p => p.Product)
                .ToList());
        }

        public double GetShoppingCartTotal()
        {
            return (double)this.dbContext.
            ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(n => n.Product.Price * n.Amount).Sum();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await this.dbContext
                .ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .ToListAsync();

            this.dbContext.ShoppingCartItems.RemoveRange(items);
            await this.dbContext.SaveChangesAsync();
        }
    }
}

