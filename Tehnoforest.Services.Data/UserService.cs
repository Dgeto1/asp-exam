using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tehnoforest.Data;
using Tehnoforest.Data.Models;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Services.Data.Models.Automower;
using Tehnoforest.Web.ViewModels.ShoppingCartItem;
using static Tehnoforest.Common.EntityValidationConstants;

namespace Tehnoforest.Services.Data
{
        public class UserService : IUserService 
        {                                                                                                                                                                                              
        private readonly TehnoforestDbContext dbContext;

        public UserService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddShoppingCartItem(int productId, string userEmail)
        {
            if (await ShoppingCartItemExists(productId, userEmail))
            {
                var quantity = (await dbContext.ShoppingCartItems.FirstAsync(sci => sci.ShoppingCartId == userEmail && sci.ProductId == productId)).Quantity;

                return await ChangeShoppingCartItemQuantity(productId, userEmail, quantity + 1);
            }

            var shoppingCartItemForDb = new ShoppingCartItem
            {
                ShoppingCartId = userEmail,
                ProductId = productId,
                Quantity = 1,
                DateCreated = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            await dbContext.ShoppingCartItems.AddAsync(shoppingCartItemForDb);

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> ChangeShoppingCartItemQuantity(int productId, string userEmail, int quantity)
        {
            if (!await ShoppingCartItemExists(productId, userEmail))
            {
                return false;
            }
            if (quantity <= 0)
            {
                return await RemoveShoppingCartItem(productId, userEmail);
            }

            var shoppingCartItemFromDb = await dbContext.ShoppingCartItems.FirstAsync(sci => sci.ShoppingCartId == userEmail && sci.ProductId == productId);
            shoppingCartItemFromDb.Quantity = quantity;

            dbContext.Update(shoppingCartItemFromDb);

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> ClearUserShoppingCart(string userEmail)
        {
            var userItems = dbContext.ShoppingCartItems.Where(sci => sci.ShoppingCartId == userEmail);

            if (await userItems.AnyAsync())
            {
                dbContext.ShoppingCartItems.RemoveRange(userItems);
            }

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IEnumerable<ShoppingCartItemViewModel>> GetUserShoppingCartItems(string userId)
        {
            IEnumerable<ShoppingCartItemViewModel> products = await dbContext
                .ShoppingCartItems
                .Where(h => h.ShoppingCartId == userId)
                .Select(h => new ShoppingCartItemViewModel
                {
                    ShoppingCartItemId = h.ShoppingCartItemId,
                    ShoppingCartId = userId,
                    ProductId = h.ProductId,
                    ProductModel = h.Product.Model,
                    ProductPrice = h.Product.Price,
                    Quantity = h.Quantity,
                    ProductImageUrl = h.Product.ImageUrl
                })
                .ToArrayAsync();

            return products;

			/*var shoppingCartitems = (from item in dbContext.ShoppingCartItems
                where item.ShoppingCartId == userId
                join product in dbContext.Products on item.ProductId equals product.Id
                select new ShoppingCartItemViewModel
                {
                    ShoppingCartItemId = item.ShoppingCartItemId,
                    ShoppingCartId = userId,
                    ProductId = item.ProductId,
                    ProductModel = product.Model,
                    ProductPrice = product.Price,
                    Quantity = item.Quantity,
                    ProductImageUrl = product.ImageUrl
                });*/

            //int totalShoppingCartItems = shoppingCartitems.Count();

           // return shoppingCartitems;
        }

        public async Task<int> GetUserShoppingCartItemsCount(string userEmail)
        {
            return await dbContext.ShoppingCartItems.Where(sci => sci.ShoppingCartId == userEmail).Select(sci => sci.Quantity).SumAsync();
        }

        public async Task<bool> RemoveShoppingCartItem(int productId, string userEmail)
        {
            if (!await ShoppingCartItemExists(productId, userEmail))
            {
                return false;
            }

            var shoppingCartItemFromDb = await dbContext.ShoppingCartItems.FirstAsync(sci => sci.ShoppingCartId == userEmail && sci.ProductId == productId);

            dbContext.ShoppingCartItems.Remove(shoppingCartItemFromDb);

            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }

		IQueryable<ShoppingCartItemViewModel> IUserService.GetUserShoppingCartItems(string userEmail)
		{
			throw new NotImplementedException();
		}

		private async Task<bool> ShoppingCartItemExists(int productId, string userEmail)
        {
            return await dbContext.ShoppingCartItems.AnyAsync(sci => sci.ShoppingCartId == userEmail && sci.ProductId == productId);
        }
    }
}
