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
    public class FarmManager : IFarmManager
    {
        public List<FarmModel> GetAllFarm()
        {
            List<FarmModel> result = new List<FarmModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.FarmRepository.QueryAll().Select(x => new FarmModel
                {
                    Farm_Address = x.Farm_Address,
                    Farm_Code = x.Farm_Code,
                    Farm_Area = x.Farm_Area,
                    Farm_Distance = x.Farm_Distance,
                    Farm_ID = x.Farm_ID,
                    Farm_Info = x.Farm_Info,
                    Farm_Name = x.Farm_Name,
                    Farm_Territory = x.Farm_Territory,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public FarmModel GetFarmByCode(string code)
        {
            FarmModel result = new FarmModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.FarmRepository.GetWhere(x => x.Farm_Code == code).Select(x => new FarmModel
                {
                    Farm_Address = x.Farm_Address,
                    Farm_Code = x.Farm_Code,
                    Farm_Area = x.Farm_Area,
                    Farm_Distance = x.Farm_Distance,
                    Farm_ID = x.Farm_ID,
                    Farm_Info = x.Farm_Info,
                    Farm_Name = x.Farm_Name,
                    Farm_Territory = x.Farm_Territory,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public FarmModel GetFarmByID(int id)
        {
            FarmModel result = new FarmModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.FarmRepository.GetWhere(x => x.Farm_ID == id).Select(x => new FarmModel
                {
                    Farm_Address = x.Farm_Address,
                    Farm_Code = x.Farm_Code,
                    Farm_Area = x.Farm_Area,
                    Farm_Distance = x.Farm_Distance,
                    Farm_ID = x.Farm_ID,
                    Farm_Info = x.Farm_Info,
                    Farm_Name = x.Farm_Name,
                    Farm_Territory = x.Farm_Territory,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddFarm(FarmModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.FarmRepository.GetWhere(x => x.Farm_Code == model.Farm_Code).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IFarmRepository.AddFarm(model);
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
    }
}
