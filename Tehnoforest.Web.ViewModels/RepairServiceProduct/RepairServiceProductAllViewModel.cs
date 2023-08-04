using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehnoforest.Web.ViewModels.RepairServiceProduct
{
    public class RepairServiceProductAllViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Име на клиент")]
        public string ClientName { get; set; } = null!;

        [Display(Name = "Марка на машина")]
        public string BrandMachine { get; set; } = null!;

        [Display(Name = "Модел на машина")]
        public string ModelMachine { get; set; } = null!;

        [Display(Name = "Дата на връщане")]
        public DateTime DateReturned { get; set; }


    }
}
