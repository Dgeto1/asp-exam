namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Web.ViewModels.Chainsaw;
    using Tehnoforest.Web.ViewModels.GardenTractor;

    public  interface IGardenTractorService
    {
        Task<bool> ExistByModelAsync(string gardenTractorModel);

        Task<string> CreateAndReturnIdAsync(GardenTractorFormModel formModel);

        Task<AllGardenTractorsFilteredAndPagedServiceModel> AllAsync(AllGardenTractorsQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int id);

        Task<GardenTractorDetailsViewModel> GetDetailsByIdAsync(int gardenTractorId);

        Task<GardenTractorFormModel> GetGardenTractorForEditByIdAsync(int gardenTractorId);

        Task EditGardenTractorByIdAndFormModelAsync(int gardenTractorId, GardenTractorFormModel formModel);
    }
}
