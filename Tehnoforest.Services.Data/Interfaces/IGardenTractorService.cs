using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tehnoforest.Web.ViewModels.Automower;

namespace Tehnoforest.Services.Data.Interfaces
{
    public  interface IGardenTractorService
    {
        Task<bool> ExistByModelAsync(string gardenTractorModel);

        Task CreateAsync(AutomowerFormModel formModel);
    }
}
