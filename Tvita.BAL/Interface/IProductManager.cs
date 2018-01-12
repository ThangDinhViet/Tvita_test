using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    public interface IProductManager
    {
        List<ProductModel> GetAllProduct();
        ProductModel GetProductByCode(string code);
        ProductModel GetProductByID(int id);
        List<ProductModel> GetRelatedProducts(int idGroup, int idProduct);
        List<ProductModel> GetProductByBranch(int branchID);
    }
}
