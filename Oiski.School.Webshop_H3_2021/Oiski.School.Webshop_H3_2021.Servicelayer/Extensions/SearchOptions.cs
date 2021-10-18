using System.ComponentModel.DataAnnotations;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public class SearchOptions
    {
        public bool Ascending { get; set; } = false;
    }

    public enum FilterBy
    {
        Brand,
        Type
    }
}