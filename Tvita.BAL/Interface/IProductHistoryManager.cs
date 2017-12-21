using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    interface IProductHistoryManager
    {
        List<ProductHistoryModel> GetAllProductHistory();
        ProductHistoryModel GetProductHistoryByID(int id);
        List<ProductHistoryModel> GetProductHistoryByPIF(int idPr, int idPu);
        ProductHistoryModel GetProductHistoryByDate(DateTime date, int idPr, int idPu);
    }
}
