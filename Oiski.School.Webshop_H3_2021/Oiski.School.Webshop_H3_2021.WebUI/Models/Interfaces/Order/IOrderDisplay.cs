using System.Collections.Generic;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IOrderDisplay : IOrderBase
    {
        IList<CartProductBase> Products { get; }
    }
}