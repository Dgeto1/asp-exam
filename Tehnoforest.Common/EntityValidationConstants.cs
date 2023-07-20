using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Dynamic;

namespace Tehnoforest.Common
{
    public static class EntityValidationConstants
    {
        public static class Product
        {
            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 20;
            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 500;
            public const int ImageUrlMaxLength = 2048;
            public const string AvailabilityMin = "0";
            public const string AvailabilityMax = "200";
            public const string PriceMin = "0";
        }

        public static class Automower
        {
            public const string WorkingAreaCapacityMin = "250";
            public const string WorkingAreaCapacityMax = "5000";
            public const string MaximumSlopePerformanceMin = "25";
            public const string MaximumSlopePerformanceMax = "70";
            public const string PriceMax = "15000";
        }

        public static class Chainsaw
        {
            public const string PowerMin = "0";
            public const string PowerMax = "30";
            public const string CylinderDisplacementMin = "0";
            public const string CylinderDisplacementMax = "60";
            public const string BarMin = "10";
            public const string BarMax = "200";
            public const string PriceMax = "3000";
        }

        public static class GardenTractor
        {
            public const string CylinderDisplacementMin = "300";
            public const string CylinderDisplacementMax = "800";
            public const string NetPowerMin = "5";
            public const string NetPowerMax = "25";
            public const string CuttingWidthMin = "80";
            public const string CuttingWidthMax = "120";
            public const string CuttingHeightMinMin = "20";
            public const string CuttingHeightMinMax = "40";
            public const string CuttingHeightMaxMin = "80";
            public const string CuttingHeightMaxMax = "120";
            public const string PriceMax = "20000";
        }

        public static class GrassTrimmer
        {
            public const string PowerMin = "0";
            public const string PowerMax = "4";
            public const string CuttingWidthMin = "35";
            public const string CuttingWidthMax = "60";
            public const string PriceMax = "5000";
        }

        public static class LawnMower
        {
            public const string WorkingAreaCapacityMin = "400";
            public const string WorkingAreaCapacityMax = "1500";
            public const string CuttingWidthMin = "40";
            public const string CuttingWidthMax = "60";
            public const string PriceMax = "5000";
        }
    }
}