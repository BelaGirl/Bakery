using Bakery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.BL
{
    public interface IBakeryService
    {
        IEnumerable<CategoryViewModel> GetAllCategories();

        IEnumerable<ProductViewModel> GetAllProducts();

        IEnumerable<ProductViewModel> GetAllProductByCategory(int id);

        ProductViewModel GetProduct(int id);

        IEnumerable<IGrouping<string, ProductViewModel>> SearchProductByName(string name);



        void CreateProduct(ProductViewModel productView);

        void EditProduct(ProductViewModel productView);

        void DeleteProduct(int id);


        // для работы с Аутентификацией
        bool CreateUser(RegisterViewModel userView);

        UserViewModel SearchUser(LoginViewModel userView);

        void EditUser(RegisterViewModel userView);




    }
}
