using System.ComponentModel.DataAnnotations;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public class OrderOptions
    {
        public bool Ascending { get; set; } = true;
    }

    public enum OrderBy
    {
        Title,
        Brand,
        Price,
        InStock
    }
}