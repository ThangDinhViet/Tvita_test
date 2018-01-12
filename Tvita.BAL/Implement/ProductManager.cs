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
                    Product_ID = x.Product_ID,
                    ID_GroupProduct = x.ID_GroupProduct,
                    Product_Description = x.Product_Description,
                    IsDelete = x.IsDelete,
                    Product_Name = x.Product_Name,
                    Product_Picture = x.Product_Picture,
                    Product_Price = x.Product_Price,
                    Product_Price_Saleoff = x.Product_Price_Saleoff,
                    Product_Quantity = x.Product_Quantity,
                    Product_Code = x.Product_Code,
                    Product_Type = x.Product_Type,
                    Product_Guide = x.Product_Guide,
                    Product_Original = x.Product_Original,
                    Product_PakageStandard = x.Product_PakageStandard,
                    Product_Preserve = x.Product_Preserve
                }).ToList();
            }
            return result;
        }
        public ProductModel GetProductByCode(string code)
        {
            ProductModel result = new ProductModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductRepository.GetWhere(x => x.Product_Code == code).Select(x => new ProductModel
                {
                    Product_ID = x.Product_ID,
                    ID_GroupProduct = x.ID_GroupProduct,
                    Product_Description = x.Product_Description,
                    IsDelete = x.IsDelete,
                    Product_Name = x.Product_Name,
                    Product_Picture = x.Product_Picture,
                    Product_Price = x.Product_Price,
                    Product_Price_Saleoff = x.Product_Price_Saleoff,
                    Product_Quantity = x.Product_Quantity,
                    Product_Code = x.Product_Code,
                    Product_Type = x.Product_Type,
                    Product_Guide = x.Product_Guide,
                    Product_Original = x.Product_Original,
                    Product_PakageStandard = x.Product_PakageStandard,
                    Product_Preserve = x.Product_Preserve
                }).FirstOrDefault();
            }
            return result;
        }
        public ProductModel GetProductByID(int id)
        {
            ProductModel result = new ProductModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductRepository.GetWhere(x => x.Product_ID == id).Select(x => new ProductModel
                {
                    Product_ID = x.Product_ID,
                    ID_GroupProduct = x.ID_GroupProduct,
                    Product_Description = x.Product_Description,
                    IsDelete = x.IsDelete,
                    Product_Name = x.Product_Name,
                    Product_Picture = x.Product_Picture,
                    Product_Price = x.Product_Price,
                    Product_Price_Saleoff = x.Product_Price_Saleoff,
                    Product_Quantity = x.Product_Quantity,
                    Product_Code = x.Product_Code,
                    Product_Type = x.Product_Type,
                    Product_Guide = x.Product_Guide,
                    Product_Original = x.Product_Original,
                    Product_PakageStandard = x.Product_PakageStandard,
                    Product_Preserve = x.Product_Preserve
                }).FirstOrDefault();
            }
            return result;
        }
        public List<ProductModel> GetRelatedProducts(int idGroup, int idProduct)
        {
            List<ProductModel> result = new List<ProductModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.ProductRepository.GetWhere(x => x.ID_GroupProduct == idGroup && x.Product_ID != idProduct).Select(x => new ProductModel
                {
                    Product_ID = x.Product_ID,
                    ID_GroupProduct = x.ID_GroupProduct,
                    Product_Description = x.Product_Description,
                    IsDelete = x.IsDelete,
                    Product_Name = x.Product_Name,
                    Product_Picture = x.Product_Picture,
                    Product_Price = x.Product_Price,
                    Product_Price_Saleoff = x.Product_Price_Saleoff,
                    Product_Quantity = x.Product_Quantity,
                    Product_Code = x.Product_Code,
                    Product_Type = x.Product_Type,
                    Product_Guide = x.Product_Guide,
                    Product_Original = x.Product_Original,
                    Product_PakageStandard = x.Product_PakageStandard,
                    Product_Preserve = x.Product_Preserve
                }).ToList();
            }
            return result;
        }
        public bool AddProduct(ProductModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.ProductRepository.GetWhere(x => x.Product_Code == model.Product_Code).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IProductRepository.AddProduct(model);
                        return true;
                    }
                    else return false; 
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductModel> GetProductByBranch(int branchID)
        {
            List<ProductModel> result = new List<ProductModel>();
            
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.IProductRepository.GetProductByBranch(branchID);
            }
            return result;
        }
    }
}
