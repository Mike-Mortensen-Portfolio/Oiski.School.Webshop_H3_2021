namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface IOrderProduct
    {
        int ProductID { get; }
        int OrderID { get; }
        int Quantity { get; }
    }
}
