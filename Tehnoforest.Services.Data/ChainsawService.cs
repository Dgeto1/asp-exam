namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Services.Data.Models.Chainsaw;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using Tehnoforest.Web.ViewModels.Enums;

    public class ChainsawService : IChainsawService
    {
        private readonly TehnoforestDbContext dbContext;

        public ChainsawService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllChainsawsFilteredAndPagedServiceModel> AllAsync(AllChainsawsQueryModel queryModel)
        {
            IQueryable<Product> chainsawsQuery = this.dbContext
                .Products
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                chainsawsQuery = chainsawsQuery
                    .Where(h => EF.Functions.Like(h.Model, wildCard) ||
                    EF.Functions.Like(h.Description, wildCard));
            }

            chainsawsQuery = queryModel.ChainsawSorting switch
            {
                ProductsSorting.NameAZ => chainsawsQuery
                .OrderBy(c => c.Model),
                ProductsSorting.NameZA => chainsawsQuery
                .OrderByDescending(h => h.Model),
                ProductsSorting.PriceAscending => chainsawsQuery
                .OrderBy(c => c.Price),
                ProductsSorting.PriceDescending => chainsawsQuery
                .OrderByDescending(c => c.Price)
            };

            IEnumerable<ChainsawAllViewModel> allChainsaws = await chainsawsQuery
                .Where(c => c.IsAvailable)
                .Where(c => c.CylinderDisplacement != null)
                .Where(c => c.Power != null)
                .Skip((queryModel.CurrentPage - 1) * queryModel.ChainsawPerPage)
                .Take(queryModel.ChainsawPerPage)
                .Select(c => new ChainsawAllViewModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    CylinderDisplacement = (decimal)c.CylinderDisplacement,
                    Power = (decimal)c.Power,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price
                })
                .ToArrayAsync();

            int totalChainsaws = chainsawsQuery.Count();

            return new AllChainsawsFilteredAndPagedServiceModel()
            {
                TotalChainsawsCount = totalChainsaws,
                Chainsaws = allChainsaws
            };
        }

        public async Task<string> CreateAndReturnIdAsync(ChainsawFormModel formModel)
        {
            Product newChainsaw = new Product()
            {
                Model = formModel.Model,
                Power = formModel.Power,
                CylinderDisplacement = formModel.CylinderDisplacement,
                BarLength = formModel.BarLength,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Availability = formModel.Availability
            };
            await this.dbContext.Products.AddAsync(newChainsaw);
            await this.dbContext.SaveChangesAsync();

            return newChainsaw.Id.ToString();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Products
                .Where(c => c.IsAvailable)
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<bool> ExistByModelAsync(string chainsawModel)
        {
            bool result = await this.dbContext
                .Products
                .AnyAsync(c => c.Model == chainsawModel);

            return result;
        }

        public async Task<ChainsawFormModel> GetChainsawForEditByIdAsync(int chainsawId)
        {
            Product chainsaw = await this.dbContext
               .Products
               .Where(c => c.IsAvailable)
               .FirstAsync(c => c.Id == chainsawId);

            return new ChainsawFormModel
            {
                Model = chainsaw.Model,
                CylinderDisplacement = (int)chainsaw.CylinderDisplacement,
                Power = (int)chainsaw.Power,
                BarLength = (int)chainsaw.BarLength,
                Description = chainsaw.Description,
                ImageUrl = chainsaw.ImageUrl,
                Price = chainsaw.Price,
                Availability = chainsaw.Availability
            };
        }

        public async Task<ChainsawDetailsViewModel> GetDetailsByIdAsync(int chainsawId)
        {
            Product chainsaw = await this.dbContext
                .Products
                .Where(c => c.IsAvailable)
                .FirstAsync(c => c.Id == chainsawId);

            return new ChainsawDetailsViewModel()
            {
                Id = chainsaw.Id,
                Model = chainsaw.Model,
                CylinderDisplacement = (int)chainsaw.CylinderDisplacement,
                Power = (int)chainsaw.Power,
                ImageUrl = chainsaw.ImageUrl,
                Description = chainsaw.Description,
                Price = chainsaw.Price,
            };
        }

        public async Task EditChainsawByIdAndFormModelAsync(int chainsawId, ChainsawFormModel formModel)
        {
            Product chainsaw = await this.dbContext
                .Products
                .Where(c => c.IsAvailable)
                .FirstAsync(c => c.Id == chainsawId);

            chainsaw.Model = formModel.Model;
            chainsaw.CylinderDisplacement = formModel.CylinderDisplacement;
            chainsaw.Power = formModel.Power;
            chainsaw.BarLength = formModel.BarLength;
            chainsaw.Description = formModel.Description;
            chainsaw.ImageUrl = formModel.ImageUrl;
            chainsaw.Price = formModel.Price;
            chainsaw.Availability = formModel.Availability;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ChainsawDeleteViewModel> GetChainsawForDeleteByIdAsync(int chainsawId)
        {
            Product chainsaw = await this.dbContext
                .Products
                .Where(c => c.IsAvailable)
                .FirstAsync(c => c.Id == chainsawId);

            return new ChainsawDeleteViewModel()
            {
                Model = chainsaw.Model,
                Availability = chainsaw.Availability,
                ImageUrl = chainsaw.ImageUrl
            };
        }

        public async Task DeleteChainsawByIdAsync(int chainsawId)
        {
            Product chainsawToDelete = await this.dbContext
                .Products
                .Where(c => c.IsAvailable)
                .FirstAsync(c => c.Id == chainsawId);

            chainsawToDelete.IsAvailable = false;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
