using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    interface IProductsInFarmManager
    {
        List<ProductsInFarmModel> GetAllProductsInFarm();
        bool UpdateAverageById(int idPif, double average);
        double GetAveragePrice(int idPr, int idPu);
    }
}
