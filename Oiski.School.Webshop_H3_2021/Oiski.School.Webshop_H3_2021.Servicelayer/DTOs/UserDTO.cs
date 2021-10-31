namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class UserDTO : IUser
    {
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
