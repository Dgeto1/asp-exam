namespace Tehnoforest.Web.ViewModels.Chainsaw
{
    using System.ComponentModel.DataAnnotations;
    using Tehnoforest.Web.ViewModels.Enums;
    using static Tehnoforest.Common.GeneralApplicationConstants;

    public class AllChainsawsQueryModel
    {
        public AllChainsawsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ChainsawPerPage = EntitiesPerPage;

            this.Chainsaws = new HashSet<ChainsawAllViewModel>();
        }

        [Display(Name = "Търси по дума")]
        public string? SearchString { get; set; }

        [Display(Name = "Сортирай по")]
        public ProductsSorting  ChainsawSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Покажи верижни триони на страницата")]
        public int ChainsawPerPage { get; set; }

        public int TotalChainsaws { get; set; }

        public IEnumerable<ChainsawAllViewModel> Chainsaws { get; set; }
    }
}
