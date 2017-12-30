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
    public class SubSubjectManager : ISubSubjectManager
    {
        public List<SubSubjectModel> GetAllSubSubject()
        {
            List<SubSubjectModel> result = new List<SubSubjectModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.SubSubjectRepository.QueryAll().Select(x => new SubSubjectModel
                {
                    Sub_ID = x.Sub_ID,
                    ID_Subject = x.ID_Subject,
                    IsDelete = x.IsDelete,
                    Sub_Description = x.Sub_Description,
                    Sub_Keyword = x.Sub_Keyword,
                    Sub_Picture = x.Sub_Picture,
                    Sub_SubjectName = x.Sub_SubjectName,
                    Sub_Url = x.Sub_Url
                }).ToList();
            }
            return result;
        }
        public SubSubjectModel GetSubSubjectByID(int id)
        {
            SubSubjectModel result = new SubSubjectModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.SubSubjectRepository.GetWhere(x => x.Sub_ID == id).Select(x => new SubSubjectModel
                {
                    Sub_ID = x.Sub_ID,
                    ID_Subject = x.ID_Subject,
                    IsDelete = x.IsDelete,
                    Sub_Description = x.Sub_Description,
                    Sub_Keyword = x.Sub_Keyword,
                    Sub_Picture = x.Sub_Picture,
                    Sub_SubjectName = x.Sub_SubjectName,
                    Sub_Url = x.Sub_Url
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddSubSubject(SubSubjectModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.SubSubjectRepository.GetWhere(x => x.Sub_ID == model.Sub_ID).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.ISubSubjectRepository.AddSubSubject(model);
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
