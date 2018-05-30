using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.DAL.Repository
{
    public class ProductRepository : Repository<tbl_Product, int>, IProductRepository
    {
        private Repository<tbl_Product, int> _productRepository;
        private DbSet<tbl_Product> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public ProductRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productRepository = new Repository<tbl_Product, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Product>();
        }
        public bool AddProduct(ProductModel model)
        {
            tbl_Product product = new tbl_Product();
            try
            {
                product.ID_GroupProduct = model.ID_GroupProduct;
                product.IsDelete = false;
                product.Product_Code = model.Product_Code;
                product.Product_Description = model.Product_Description;
                product.Product_Name = model.Product_Name;
                product.Product_Picture = model.Product_Picture;
                product.Product_Price = model.Product_Price;
                product.Product_Price_Saleoff = model.Product_Price_Saleoff;
                product.Product_Quantity = model.Product_Quantity;
                product.Product_Type = model.Product_Type;
                product.Product_Original = model.Product_Original;
                product.Product_PakageStandard = model.Product_PakageStandard;
                product.Product_Preserve = model.Product_Preserve;
                product.Product_Guide = model.Product_Guide;

                _dbContext.tbl_Product.Add(product);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductModel> GetProductByBranch(int branchID, int? groupID)
        {
            var result = new List<ProductModel>();
            var query = from p in _dbContext.tbl_Product
                        join gr in _dbContext.tbl_GroupProduct on p.ID_GroupProduct equals gr.GroupProduct_ID
                        where gr.ID_Branch == branchID && (p.ID_GroupProduct == groupID || groupID == 0)
                        select new ProductModel
                        {
                            Product_ID = p.Product_ID,
                            ID_GroupProduct = p.ID_GroupProduct,
                            Product_Description = p.Product_Description,
                            IsDelete = p.IsDelete,
                            Product_Name = p.Product_Name,
                            Product_Picture = p.Product_Picture,
                            Product_Price = p.Product_Price,
                            Product_Price_Saleoff = p.Product_Price_Saleoff,
                            Product_Quantity = p.Product_Quantity,
                            Product_Code = p.Product_Code,
                            Product_Type = p.Product_Type,
                            Product_Guide = p.Product_Guide,
                            Product_Original = p.Product_Original,
                            Product_PakageStandard = p.Product_PakageStandard,
                            Product_Preserve = p.Product_Preserve,
                            Product_Description_EN = p.Product_Description_EN,
                            Product_Guide_EN = p.Product_Guide_EN,
                            Product_Name_EN = p.Product_Name_EN,
                            Product_Original_EN = p.Product_Original_EN,
                            Product_PakageStandard_EN = p.Product_PakageStandard_EN,
                            Product_Preserve_EN = p.Product_Preserve_EN,
                        };

            result = query.OrderByDescending(x => x.Product_ID).ToList();
            return result;
        }
    }
}
