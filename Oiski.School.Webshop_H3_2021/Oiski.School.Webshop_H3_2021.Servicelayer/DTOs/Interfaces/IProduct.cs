namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface IProduct
    {
        int ProductID { get; }
        string Title { get; }
        string Description { get; }

        int BrandID { get; set; }
        decimal Price { get; }
        int InStock { get; }
    }
}
