using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductDisplayDTO : ProductDTO
    {
        public byte[] DisplayImage { get; set; }
    }
}
