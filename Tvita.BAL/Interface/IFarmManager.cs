using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    interface IFarmManager
    {
        List<FarmModel> GetAllFarm();
        FarmModel GetFarmByCode(string code);
    }
}
