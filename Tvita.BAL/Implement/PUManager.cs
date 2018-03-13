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
    public class PUManager : IPUManager
    {
        public PUModel GetPUByID(int id)
        {
            PUModel result = new PUModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PURepository.GetWhere(x => x.PU_ID == id).Select(x => new PUModel
                {
                   PU_ID = x.PU_ID,
                   PU_Address = x.PU_Address,
                   PU_Areas = x.PU_Areas,
                   PU_CodeVietGap = x.PU_CodeVietGap,
                   PU_Content = x.PU_Content,
                   PU_Image = x.PU_Image,
                   PU_Name = x.PU_Name,
                   PU_Og = x.PU_Og
                }).FirstOrDefault();
            }
            return result;
        }
    }
}
