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
    public class GroupProductManager : IGroupProductManager
    {
        public List<GroupProductModel> GetGroupProductBranch()
        {
            List<GroupProductModel> result = new List<GroupProductModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.GroupProductRepository.QueryAll().Select(x => new GroupProductModel
                {
                    GroupProduct_Code = x.GroupProduct_Code,
                    GroupProduct_Description = x.GroupProduct_Description,
                    GroupProduct_ID = x.GroupProduct_ID,
                    GroupProduct_Name = x.GroupProduct_Name,
                    GroupProduct_Picture = x.GroupProduct_Picture,
                    ID_Branch = x.ID_Branch,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public GroupProductModel GetGroupProductByCode(string code)
        {
            GroupProductModel result = new GroupProductModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.GroupProductRepository.GetWhere(x => x.GroupProduct_Code == code).Select(x => new GroupProductModel
                {
                    GroupProduct_Code = x.GroupProduct_Code,
                    GroupProduct_Description = x.GroupProduct_Description,
                    GroupProduct_ID = x.GroupProduct_ID,
                    GroupProduct_Name = x.GroupProduct_Name,
                    GroupProduct_Picture = x.GroupProduct_Picture,
                    ID_Branch = x.ID_Branch,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddGroupProduct(GroupProductModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.GroupProductRepository.GetWhere(x => x.GroupProduct_Code == model.GroupProduct_Code).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IGroupProductRepository.AddGroupProduct(model);
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
