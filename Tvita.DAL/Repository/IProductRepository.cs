using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.DAL.Repository
{
    public interface IProductRepository
    {
        bool AddProduct(ProductModel model);
        List<ProductModel> GetProductByBranch(int branchID);
    }
}

