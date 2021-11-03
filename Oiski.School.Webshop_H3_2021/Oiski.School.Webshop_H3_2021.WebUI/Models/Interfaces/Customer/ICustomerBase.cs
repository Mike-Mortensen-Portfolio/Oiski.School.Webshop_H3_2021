namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface ICustomerBase
    {
        public int CustomerID { get; }
        public int UserID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Country { get; }
        public int ZipCode { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
    }
}