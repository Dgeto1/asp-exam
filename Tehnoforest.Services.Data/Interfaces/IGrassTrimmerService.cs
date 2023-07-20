namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Services.Data.Models.GardenTractor;
    using Tehnoforest.Services.Data.Models.GrassTrimmer;
    using Tehnoforest.Web.ViewModels.Automower;
    using Tehnoforest.Web.ViewModels.GrassTrimer;
    using Tehnoforest.Web.ViewModels.GrassTrimmer;

    public interface IGrassTrimmerService
    {
        Task<bool> ExistByModelAsync(string automowerModel);

        Task<string> CreateAndReturnIdAsync(GrassTrimmerFormModel formModel);

        Task<AllGrassTrimmersFilteredAndPagedServiceModel> AllAsync(AllGrassTrimmersQueryModel queryModel);

        Task<GrassTrimmerDetailsViewModel> GetDetailsByIdAsync(int grassTrimmerId);

        Task<GrassTrimmerFormModel> GetGrassTrimmerForEditByIdAsync(int grassTrimmerId);

        Task EditGrassTrimmerByIdAndFormModelAsync(int grassTrimmerId, GrassTrimmerFormModel formModel);

        Task<GrassTrimmerDeleteViewModel> GetGrassTrimmerForDeleteByIdAsync(int grassTrimmerId);

        Task DeleteGrassTrimmerByIdAsync(int grassTrimmerId);

        Task<bool> ExistsByIdAsync(int id);
    }
}
