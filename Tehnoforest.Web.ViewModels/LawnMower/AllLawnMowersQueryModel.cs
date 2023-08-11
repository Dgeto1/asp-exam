namespace Tehnoforest.Web.ViewModels.LawnMower
{
    using System.ComponentModel.DataAnnotations;

    using Tehnoforest.Web.ViewModels.Enums;

    using static Tehnoforest.Common.GeneralApplicationConstants;


    public class AllLawnMowersQueryModel
    {
        public AllLawnMowersQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.LawnMowerPerPage = EntitiesPerPage;

            this.LawnMowers = new HashSet<LawnMowerAllViewModel>();
        }

        [Display(Name = "Търси по дума")]
        public string? SearchString { get; set; }

        [Display(Name = "Сортирай по")]
        public ProductsSorting LawnMowerSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Покажи по")]
        public int LawnMowerPerPage { get; set; }

        public int TotalLawnMowers { get; set; }

        public IEnumerable<LawnMowerAllViewModel> LawnMowers { get; set; }
    }
}
