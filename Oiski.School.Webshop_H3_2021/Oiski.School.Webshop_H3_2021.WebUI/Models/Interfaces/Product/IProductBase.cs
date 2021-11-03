using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IProductBase
    {
        public int ProductID { get; }
        public int CategoryID { get; }
        public string Title { get; }
        public string Description { get; }
        public int BrandId { get; }
        public decimal Price { get; }
        public int InStock { get; }
    }
}
