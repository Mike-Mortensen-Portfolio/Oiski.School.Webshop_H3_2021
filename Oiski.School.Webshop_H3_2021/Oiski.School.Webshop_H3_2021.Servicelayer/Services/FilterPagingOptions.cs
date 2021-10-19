using Oiski.School.Webshop_H3_2021.Servicelayer.Extensions;
using System;
using System.Linq;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class FilterPagingOptions
    {
        public OrderOptions SearchOptions { get; set; } = new OrderOptions();

        public OrderBy Order { get; set; } = OrderBy.Brand;
        public string BrandKey { get; set; } = null;
        public int TypeIDKey { get; set; } = -1;
        public string SearchKey { get; set; } = null;

        public int PageSize { get; set; } = 10;
        public int PageNum { get; set; } = 0;
        public int NumPages { get; private set; }

        public void BuildPageData<T>(IQueryable<T> _filterPages)
        {
            NumPages = ( int )Math.Ceiling(( double )_filterPages.Count() / PageSize);
            PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
        }
    }
}