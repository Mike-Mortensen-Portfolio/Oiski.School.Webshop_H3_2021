using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public interface IWebshopService
    {
        public void Add<T>(T _entity);

        public void Update<T>(T _entity);

        public void Remove<T>(T _entity);

        public IQueryable<ProductDTO> GetAllProducts();

        public ProductDTO GetProductByID(int _productID);

        public OrderDTO GetOrderByID(int _orderID);

        public IList<OrderProductDTO> GetOrderProductsByOrder(int _orderID);

        public IList<OrderProductDTO> GetOrdersProductsByCustomer(int _customerID);

        public IQueryable<UserDTO> GetAllCustomers();

        public UserDTO GetUserByID(int _userID);

        public UserDTO GetUserByEmail(string _email);

        public IQueryable<TypeDTO> GetAllypes();

        public TypeDTO GetTypeByID(int _typeID);

        public IQueryable<ProductDisplayDTO> FilterPaging(FilterPagingOptions _options);
    }
}
