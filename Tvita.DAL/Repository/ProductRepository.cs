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

                _dbContext.tbl_Product.Add(product);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
