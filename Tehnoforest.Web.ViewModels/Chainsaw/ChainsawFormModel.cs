﻿namespace Tehnoforest.Web.ViewModels.Chainsaw
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Product;
    using static Common.EntityValidationConstants.Chainsaw;

    public class ChainsawFormModel
    {
        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [Display(Name = "Модел")]
        public string Model { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PowerMin, PowerMax)]
        [Display(Name = "Мощност")]
        public decimal Power { get; set; }

        [Required]
        [Range(typeof(decimal), CylinderDisplacementMin, CylinderDisplacementMax)]
        [Display(Name = "Обем на цилиндъра")]
        public decimal CylinderDisplacement { get; set; }

        [Required]
        [Range(typeof(int), BarMin, BarMax)]
        [Display(Name = "Дължина на шина")]
        public int BarLength { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Линк на изображение")]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(int), AvailabilityMin, AvailabilityMax)]
        [Display(Name = "Наличност")]
        public int Availability { get; set; }
    }
}
