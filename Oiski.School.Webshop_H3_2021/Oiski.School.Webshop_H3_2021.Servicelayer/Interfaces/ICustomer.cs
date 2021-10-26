namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface ICustomer
    {
        int CustomerID { get; }
        int? UserID { get; }

        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Country { get; }
        int ZipCode { get; }
        string Address { get; }
        string PhoneNumber { get; }
    }
}
