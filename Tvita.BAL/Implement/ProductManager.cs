using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.BAL.Interface;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.BAL.Implement
{
    public class ProductManager : IProductManager
    {
        public List<ProductModel> GetAllProduct()
        {
            List<ProductModel> result = new List<ProductModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductRepository.QueryAll().Select(x => new ProductModel
                {
                    ID = x.ID,
                    ID_ProductList = x.ID_ProductList,
                    Product_Description = x.Product_Description,
                    IsDelete = x.IsDelete,
                    Product_Name = x.Product_Name,
                    Product_Picture = x.Product_Picture,
                    Product_Price = x.Product_Price,
                    Product_Price_Saleoff = x.Product_Price_Saleoff,
                    Product_Quantity = x.Product_Quantity,
                    Product_Code = x.Product_Code,
                    Product_Type = x.Product_Type
                }).ToList();
            }
            return result;
        }
    }
}
