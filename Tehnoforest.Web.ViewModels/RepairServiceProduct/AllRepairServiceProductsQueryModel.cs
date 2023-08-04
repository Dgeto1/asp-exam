using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tehnoforest.Web.ViewModels.RepairServiceProduct
{
    public class AllRepairServiceProductsQueryModel
    {
        public AllRepairServiceProductsQueryModel()
        {
            this.RepairServiceProducts = new HashSet<RepairServiceProductAllViewModel>();
        }

        [Display(Name = "Търси по номер на сервизна карта")]
        public string? SearchString { get; set; }

        public IEnumerable<RepairServiceProductAllViewModel> RepairServiceProducts { get; set; }
    }
}
