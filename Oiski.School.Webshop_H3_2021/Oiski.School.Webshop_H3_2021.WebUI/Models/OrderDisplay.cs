using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public class OrderDisplay : OrderBase, IOrderDisplay, IEditableOrder
    {
        public IList<CartProductBase> Products { get; set; }
    }
}
