using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tehnoforest.Web.ViewModels.GrassTrimmer;

namespace Tehnoforest.Services.Data.Models.GrassTrimmer
{
    public class AllGrassTrimmersFilteredAndPagedServiceModel
    {
        public AllGrassTrimmersFilteredAndPagedServiceModel()
        {
            this.GrassTrimmers = new HashSet<GrassTrimmerAllViewModel>();
        }
        public int TotalGrassTrimmersCount { get; set; }

        public IEnumerable<GrassTrimmerAllViewModel> GrassTrimmers { get; set; }
    }
}
