namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Web.ViewModels.GardenTractor;

    public  interface IGardenTractorService
    {
        Task<bool> ExistByModelAsync(string gardenTractorModel);

        Task<string> CreateAndReturnIdAsync(GardenTractorFormModel formModel);

        Task<AllGardenTractorsFilteredAndPagedServiceModel> AllAsync(AllGardenTractorsQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int id);
    }
}
