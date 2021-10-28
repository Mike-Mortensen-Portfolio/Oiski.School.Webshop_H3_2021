using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IProductRepository : ICrudRepository<IProduct>
    {
        Task<IReadOnlyList<IProduct>> GetAllAsync();
        Task<IReadOnlyList<IProduct>> GetByBrandAsync(int _brandID);
        Task<IReadOnlyList<IProduct>> GetByCategoryAsync(int _orderID);
        Task<IProduct> GetByIDAsync(int _id);
    }
}
