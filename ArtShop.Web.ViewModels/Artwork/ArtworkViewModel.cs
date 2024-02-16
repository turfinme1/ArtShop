namespace ArtShop.Web.ViewModels.Artwork
{
    public class ArtworkViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Summary { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int YearMade { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double? Depth { get; set; }

        public bool IsFramed { get; set; }

        public required string Style { get; set; }

        public required string Subject { get; set; }

        public required string CreatorName { get; set; }

        // TODO: list of categories model, orders model, reviews model
    }
}
