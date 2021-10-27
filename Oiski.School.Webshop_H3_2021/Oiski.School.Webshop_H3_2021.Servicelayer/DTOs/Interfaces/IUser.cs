namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface IUser
    {
        int UserID { get; }
        int CustomerID { get; }
        string Password { get; }

        bool IsAdmin { get; }
    }
}
