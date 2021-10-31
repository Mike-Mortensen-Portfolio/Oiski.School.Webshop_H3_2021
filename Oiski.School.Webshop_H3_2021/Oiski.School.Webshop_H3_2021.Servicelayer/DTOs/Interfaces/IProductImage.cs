namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface IProductImage
    {
        int ProductImageID { get; }
        int ProductID { get; }
        string Title { get; }
        string ImageURL { get; }
    }
}
