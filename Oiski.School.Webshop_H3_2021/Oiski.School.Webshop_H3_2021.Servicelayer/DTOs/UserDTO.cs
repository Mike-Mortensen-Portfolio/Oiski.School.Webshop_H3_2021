namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class UserDTO : IUser
    {
        public int UserID { get; }
        public int CustomerID { get; }
        public string Password { get; }
        public bool IsAdmin { get; }
    }
}
