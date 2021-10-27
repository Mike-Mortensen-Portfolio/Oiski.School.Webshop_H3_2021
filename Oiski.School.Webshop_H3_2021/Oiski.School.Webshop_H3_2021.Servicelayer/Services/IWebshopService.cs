using Oiski.School.Webshop_H3_2021.Servicelayer.Repositories;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public interface IWebshopService
    {
        IBrandRepository Brand { get; }
        ICategoryRepository Category { get; }
        ICustomerRepository Customer { get; }
        IProductRepository Product { get; }
    }
}
