using System.ComponentModel.DataAnnotations;
using Tehnoforest.Web.ViewModels.Enums;
using static Tehnoforest.Common.GeneralApplicationConstants;

namespace Tehnoforest.Web.ViewModels.GrassTrimmer
{
    public class AllGrassTrimmersQueryModel
    {
        public AllGrassTrimmersQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.GrassTrimmerPerPage = EntitiesPerPage;

            this.GrassTrimmers = new HashSet<GrassTrimmerAllViewModel>();
        }

        [Display(Name = "Търси по дума")]
        public string? SearchString { get; set; }

        [Display(Name = "Сортирай по")]
        public ProductsSorting GrassTrimmerSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Покажи по")]
        public int GrassTrimmerPerPage { get; set; }

        public int TotalGrassTrimmers { get; set; }

        public IEnumerable<GrassTrimmerAllViewModel> GrassTrimmers { get; set; }
    }
}
