using Bakery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using Bakery.ViewModel;
using AutoMapper;
using Bakery.DAL;
using Bakery.DAL.Repositories;
using System.Linq;
using Bakery.DAL.Models;
using System.Web.Helpers;

namespace Bakery.BL
{
    public class BakeryService:IBakeryService
    {
        //  IUnitOfWork Database = new UnitOfWork();

        IUnitOfWork _Database;
        IMapper _mapper;

        public BakeryService(IUnitOfWork uow, IBakeryMapper getMapper)
        {
            _Database = uow;
            _mapper = getMapper.GetMapper();
        }


        #region ProductMethod
        // Список категорий для меню
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var category = _Database.Categories.GetAll();

            var categoryView = _mapper.Map<IEnumerable<CategoryViewModel>>(category);

            return categoryView;
        }

        // по отображаем Id Category соответствующие товары
        public IEnumerable<ProductViewModel> GetAllProductByCategory(int id)
        {
            var products = _Database.Products.Find(p => p.CatId == id);

            var productView = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return productView;
        }


        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var product = _Database.Products.GetAll();

            var productView = _mapper.Map<IEnumerable<ProductViewModel>>(product);

            return productView;
        }


        public ProductViewModel GetProduct(int id)
        {
            var prodDb = _Database.Products.Get(id);
            return _mapper.Map<ProductViewModel>(prodDb);
        }

     


        public void CreateProduct(ProductViewModel productView)
        {
            var product = _mapper.Map<Product>(productView);
            _Database.Products.Create(product);
            _Database.Save();
        }


        public void EditProduct(ProductViewModel productView)
        {
            var product = _mapper.Map<Product>(productView);
            _Database.Products.Update(product);
            _Database.Save();
        }

        public void DeleteProduct(int id)
        {
            _Database.Products.Delete(id);
            _Database.Save();
        }




        // поиск продукта по названию, сгруппированные по категории
       public IEnumerable<IGrouping<string, ProductViewModel>> SearchProductByName(string name)
        {
            string nameToLower = name.ToLower();

            var prodDb = _Database.Products.Find(n => n.Name.ToLower().Contains(nameToLower));      
            var prod = _mapper.Map<IEnumerable<ProductViewModel>>(prodDb);
            var foundProducts = prod.GroupBy(p => p.Category.Name);

            return foundProducts;
        }
        #endregion

        #region AuthMethods

        public bool CreateUser(RegisterViewModel userView)
        {
            User user = _mapper.Map<User>(userView);
            user.Password = Crypto.HashPassword(user.Password);
            user.RoleId = 2;                          // простой user

            bool result= _Database.User.Create(user);
            if (result)
                _Database.Save();
            return result;                             
        }


        public UserViewModel SearchUser(LoginViewModel userView)
        {
            
            User user = _mapper.Map<User>(userView);
            user = _Database.User.Find(u=>u.Email==user.Email && Crypto.VerifyHashedPassword(u.Password, user.Password));

            return _mapper.Map<UserViewModel>(user);

        }

        public void EditUser(RegisterViewModel userView)
        {
            var user = _mapper.Map<User>(userView);
            _Database.User.Update(user);
            _Database.Save();
        }

        #endregion
    }
}
