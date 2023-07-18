namespace Tehnoforest.Web.ViewModels.Automower
{
    using System.ComponentModel.DataAnnotations;

    using Tehnoforest.Web.ViewModels.Enums;

    using static Tehnoforest.Common.GeneralApplicationConstants;
    public  class AllAutomowersQueryModel
    {
        public AllAutomowersQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.AutomowerPerPage = EntitiesPerPage;

            this.Automowers = new HashSet<AutomowerAllViewModel>();
        }

        [Display(Name = "Търси по дума")]
        public string? SearchString { get; set; }

        [Display(Name = "Сортирай по")]
        public ProductsSorting AutomowerSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Покажи копсачки роботи на страницата")]
        public int AutomowerPerPage { get; set; }

        public int TotalAutomowers { get; set; }

        public IEnumerable<AutomowerAllViewModel> Automowers { get; set; }
    }
}
