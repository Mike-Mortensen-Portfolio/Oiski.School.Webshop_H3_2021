namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductImageDTO : IProductImage
    {
        public int ProductImageID { get; }
        public int ProductID { get; }
        public string ImageURL { get; }
    }
}
