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
    }
}
