namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class CustomerDTO : ICustomer
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneAddress { get; set; }
    }
}
