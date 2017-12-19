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
    public class BranchManager : IBranchManager
    {
        public List<BranchModel> GetAllBranch()
        {
            List<BranchModel> result = new List<BranchModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.BranchRepository.QueryAll().Select(x => new BranchModel
                {
                    Branch_Code = x.Branch_Code,
                    Branch_ID = x.Branch_ID,
                    Branch_Name = x.Branch_Name,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public BranchModel GetBranchByCode(string code)
        {
            BranchModel result = new BranchModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.BranchRepository.GetWhere(x => x.Branch_Code == code).Select(x => new BranchModel
                {
                    Branch_Code = x.Branch_Code,
                    Branch_ID = x.Branch_ID,
                    Branch_Name = x.Branch_Name,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddBranch(BranchModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.BranchRepository.GetWhere(x => x.Branch_Code == model.Branch_Code).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IBranchRepository.AddBranch(model);
                        return true;
                    }
                    else
                        return false;
                       
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
