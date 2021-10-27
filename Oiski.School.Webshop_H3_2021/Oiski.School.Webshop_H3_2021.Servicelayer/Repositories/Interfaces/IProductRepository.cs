using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<IProduct>> GetAll();
        Task<IProduct> GetByIDAsync(int _id);
        Task<IReadOnlyList<IProduct>> GetByBrandAsync(int _brandID);
        Task<IReadOnlyList<IProduct>> GetByCategoryAsync(int _orderID);

        Task<bool> AddAsync(IProduct _product);
        Task<bool> UpdateAsync(IProduct _product);
        Task<bool> RemoveAsync(IProduct _product);
    }
}
