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
        }

        public static class Automower
        {
            public const string WorkingAreaCapacityMin = "250";
            public const string WorkingAreaCapacityMax = "5000";
            public const string MaximumSlopePerformanceMin = "25";
            public const string MaximumSlopePerformanceMax = "70";
            public const string PriceMin = "0";
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
            public const string PriceMin = "0";
            public const string PriceMax = "3000";
        }
    }
}
