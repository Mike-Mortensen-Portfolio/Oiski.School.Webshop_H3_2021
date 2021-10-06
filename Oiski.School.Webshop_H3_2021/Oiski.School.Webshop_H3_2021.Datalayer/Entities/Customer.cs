namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    public class Customer
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Foreign Key to attached <see cref="CustomerLogin"/>
        /// </summary>
        public int? CustomerLoginID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public int City { get; set; }

        public int ZipCode { get; set; }

        public string Addresse { get; set; }

        public string PhoneNumber { get; set; }

        public int PaymentMethod { get; set; }

        public int DeliveryType { get; set; }
    }
}