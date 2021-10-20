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

        public IList<ProductDTO> GetAllProducts()
        {
            return GetQueryable<Product>()
                .Include(p => p.Orders)
                .Include(p => p.ProductImages)
                .Include(p => p.Types)
                .AsNoTracking()
                .MapToBaseDTO()
                .ToList();
        }

        public ProductDTO GetProductByID(int _id)
        {
            return GetAllProducts()
                .SingleOrDefault(p => p.ProductID == _id);
        }

        public OrderDTO GetOrderByID(int _id)
        {
            return GetQueryable<Order>()
                .Include(o => o.Customer)
                .Include(o => o.Products)
                .AsNoTracking()
                .MapToBaseDTO()
                .SingleOrDefault(o => o.OrderID == _id);
        }

        public IList<OrderProductDTO> GetOrdersProductsByOrder(int _orderID)
        {
            return GetQueryable<OrderProduct>()
                .Include(op => op.Product)
                .Include(op => op.Order)
                .MapToBaseDTO()
                .Where(op => op.Order.OrderID == _orderID)
                .ToList();
        }

        public IList<OrderProductDTO> GetOrdersProductsByCustomer(int _customerID)
        {
            return GetQueryable<OrderProduct>()
                .Include(op => op.Product)
                .Include(op => op.Order)
                .MapToBaseDTO()
                .Where(op => op.Order.CustomerID == _customerID)
                .ToList();
        }

        public UserDTO GetUserByID(int _id)
        {
            return GetQueryable<User>()
                .Include(u => u.Customer)
                .ThenInclude(c => c.Orders)
                .MapToBaseDTO()
                .SingleOrDefault(u => u.UserID == _id);
        }

        public UserDTO GetUserByEmail(string _email)
        {
            return GetQueryable<User>()
                .Include(u => u.Customer)
                .ThenInclude(c => c.Orders)
                .MapToBaseDTO()
                .SingleOrDefault(u => u.Email == _email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_options"></param>
        /// <returns>An <see cref="IQueryable{T}"/> <see langword="object"/> that contains a filtered page collection in order</returns>
        public IQueryable<ProductDisplayDTO> FilterPaging(FilterPagingOptions _options)
        {
            var query = context.Products
                .AsNoTracking()
                .MapToDisplayDTO()
                .Order(_options.Order)
                .FilterByBrand(_options.BrandKey)
                .FilterByType(_options.TypeIDKey)
                .FreeSearchTitle(_options.SearchKey);

            _options.BuildPageData(query);

            return query.Paging(_options.CurrentPage - 1, _options.PageSize);
        }
    }
}
