namespace ArtShop.Data.Common
{
    public static class GlobalConstants
    {
        public static class ArtworkValidationConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const int SummaryMinLength = 20;
            public const int SummaryMaxLength = 250;

            public const int DescriptionMinLength = 40;
            public const int DescriptionMaxLength = 500;

            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 1000000;
        }

        public static class AddressValidationConstants
        {
            public const int StreetNameMinLength = 3;
            public const int StreetNameMaxLength = 100;

            public const int ZipCodeMinLength = 3;
            public const int ZipCodeMaxLength = 10;
        }

        public static class CategoryValidationConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;
        }

        public static class CityValidationConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class CountryValidationConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class ReviewValidationConstants
        {
            public const int CommentMaxLength = 500;

            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 5;
        }
    }
}
