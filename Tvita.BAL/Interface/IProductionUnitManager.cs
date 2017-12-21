﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    interface IProductionUnitManager
    {
        List<ProductionUnitModel> GetAllProductionUnit();
        ProductionUnitModel GetProductionUnitByCode(string code);
        ProductionUnitModel GetProductionUnitByID(int id);
    }
}
