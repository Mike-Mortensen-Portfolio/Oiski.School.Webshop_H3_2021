namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductDTO : IProduct
    {
        public int ProductID { get; }
        public string Title { get; }
        public string Description { get; }
        public string BrandName { get; set; }
        public decimal Price { get; }
        public int InStock { get; }
    }
}
