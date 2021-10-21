using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopService
    {
        public WebshopService(WebshopContext _context)
        {
            context = _context;
        }

        private readonly WebshopContext context;

        /// <summary>
        /// Adds <paramref name="_entity"/> of type <typeparamref name="T"/> to the tracker and saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param>
        public void Add<T>(T _entity)
        {
            context.Add(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Marks <paramref name="_entity"/> of type <typeparamref name="T"/> as <see cref="Microsoft.EntityFrameworkCore.EntityState.Modified"/> and adds it to the tracker, then saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param>
        public void Update<T>(T _entity)
        {
            context.Update(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Adds <paramref name="_entity"/> of type <typeparamref name="T"/> to the tracker as <see cref="Microsoft.EntityFrameworkCore.EntityState.Deleted"/> and saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param>
        public void Remove<T>(T _entity)
        {
            context.Remove(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Builds an <see cref="IQueryable{T}"/> object that targets the type of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>An extendable query expression that targets a sequence of type <typeparamref name="T"/></returns>
        internal IQueryable<T> GetQueryable<T>() where T : class
        {
            return context.Set<T>();
        }

        public IQueryable<ProductDTO> GetAllProducts()
        {
            return GetQueryable<Product>()
                .Include(p => p.Orders)
                .Include(p => p.ProductImages)
                .Include(p => p.Types)
                .AsNoTracking()
                .MapToBaseDTO();
        }

        public ProductDTO GetProductByID(int _productID)
        {
            return GetAllProducts()
                .SingleOrDefault(p => p.ProductID == _productID);
        }

        public OrderDTO GetOrderByID(int _orderID)
        {
            return GetQueryable<Order>()
                .Include(o => o.Customer)
                .Include(o => o.Products)
                .AsNoTracking()
                .MapToBaseDTO()
                .SingleOrDefault(o => o.OrderID == _orderID);
        }

        public IList<OrderProductDTO> GetOrderProductsByOrder(int _orderID)
        {
            var list = GetQueryable<OrderProduct>()
                .Include(op => op.Order)
                .Include(op => op.Product)
                .Where(op => op.Order.OrderID == _orderID)
                .AsNoTracking()
                .MapToBaseDTO()
                .ToList();

            return list;
        }

        public IList<OrderProductDTO> GetOrdersProductsByCustomer(int _customerID)
        {
            return GetQueryable<OrderProduct>()
                .Include(op => op.Product)
                .Include(op => op.Order)
                .Where(op => op.Order.CustomerID == _customerID)
                .AsNoTracking()
                .MapToBaseDTO()
                .ToList();
        }

        public IQueryable<UserDTO> GetAllCustomers()
        {
            return GetQueryable<Customer>()
            .Include(c => c.Orders)
            .Include(c => c.User)
            .AsNoTracking()
            .MapToBaseDTO();
        }

        public UserDTO GetUserByID(int _userID)
        {
            return GetQueryable<Customer>()
                .Include(u => u.User)
                .AsNoTracking()
                .MapToBaseDTO()
                .SingleOrDefault(u => u.UserID == _userID);
        }

        public UserDTO GetUserByEmail(string _email)
        {
            return GetQueryable<Customer>()
                .Include(u => u.User)
                .Include(c => c.Orders)
                .Where(u => u.UserID == null ? false : true)
                .AsNoTracking()
                .MapToBaseDTO()
                .SingleOrDefault(u => u.Email == _email);
        }

        public IQueryable<TypeDTO> GetAllypes()
        {
            return GetQueryable<Datalayer.Entities.Type>()
                .AsNoTracking()
                .Select(t => new TypeDTO
                {
                    Name = t.Name,
                    TypeID = t.TypeID
                });
        }

        public TypeDTO GetTypeByID(int _typeID)
        {
            return GetQueryable<Datalayer.Entities.Type>()
                .AsNoTracking()
                .Select(t => new TypeDTO
                {
                    Name = t.Name,
                    TypeID = t.TypeID
                })
                .SingleOrDefault(t => t.TypeID == _typeID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_options"></param>
        /// <returns>An <see cref="IQueryable{T}"/> <see langword="object"/> that contains a filtered page collection in order</returns>
        public IQueryable<ProductDisplayDTO> FilterPaging(FilterPagingOptions _options)
        {
            var query = context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Types)
                    .ThenInclude(pt => pt.Type)
                .AsNoTracking()
                .MapToDisplayDTO()
                .Order(_options.Order)
                .FilterByBrand(_options.BrandKey)
                .FilterByType(_options.TypeIDKey)
                .FreeSearchTitle(_options.SearchKey);

            _options.BuildPageData(query);

            return query.Paging(_options.CurrentPage, _options.PageSize);
        }
    }
}
