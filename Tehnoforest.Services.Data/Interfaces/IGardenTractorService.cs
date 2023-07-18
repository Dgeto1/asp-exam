using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tehnoforest.Services.Data.Models.Chainsaw;
using Tehnoforest.Services.Data.Models.GardenTractor;
using Tehnoforest.Web.ViewModels.Automower;
using Tehnoforest.Web.ViewModels.Chainsaw;
using Tehnoforest.Web.ViewModels.GardenTractor;

namespace Tehnoforest.Services.Data.Interfaces
{
    public  interface IGardenTractorService
    {
        Task<bool> ExistByModelAsync(string gardenTractorModel);

        Task<string> CreateAndReturnIdAsync(Web.ViewModels.GardenTractor.GardenTractorFormModel formModel);

        Task<AllGardenTractorFilteredAndPagedServiceModel> AllAsync(AllGardenTractorsQueryModel queryModel);

        Task<bool> ExistsByIdAsync(int id);
    }
}
