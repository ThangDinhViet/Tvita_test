﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.DAL.Repository
{
    public interface IProductionUnitRepository
    {
        bool AddProductionUnit(ProductionUnitModel model);
    }
}