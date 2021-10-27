using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Servicelayer.Repositories;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopService : IWebshopService
    {
        public WebshopService()
        {
            var context = new WebshopContext();
            Brand = new BrandRepository(context);
            Category = new CategoryRepository(context);
            Customer = new CustomerRepository(context);
            Product = new ProductRepository(context);
            Order = new OrderRepository(context);
        }

        public IBrandRepository Brand { get; }
        public ICategoryRepository Category { get; }
        public ICustomerRepository Customer { get; }
        public IProductRepository Product { get; }
        public IOrderRepository Order { get; }
    }
}
