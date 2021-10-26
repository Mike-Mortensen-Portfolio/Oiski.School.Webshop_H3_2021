namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductDTO : IProduct
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}
