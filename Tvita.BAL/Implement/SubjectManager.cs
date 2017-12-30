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
    public class SubjectManager : ISubjectManager
    {
        public List<SubjectModel> GetAllSubject()
        {
            List<SubjectModel> result = new List<SubjectModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.SubjectRepository.QueryAll().Select(x => new SubjectModel
                {
                    Subject_ID = x.Subject_ID,
                    IsDelete = x.IsDelete,
                    Subject_Description = x.Subject_Description,
                    Subject_Keyword = x.Subject_Keyword,
                    Subject_Name = x.Subject_Name,
                    Subject_NumberPosts = x.Subject_NumberPosts,
                    Subject_Picture = x.Subject_Picture,
                    Subject_Url = x.Subject_Url
                }).ToList();
            }
            return result;
        }
        public SubjectModel GetSubjectByID(int id)
        {
            SubjectModel result = new SubjectModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.SubjectRepository.GetWhere(x => x.Subject_ID == id).Select(x => new SubjectModel
                {
                    Subject_ID = x.Subject_ID,
                    IsDelete = x.IsDelete,
                    Subject_Description = x.Subject_Description,
                    Subject_Keyword = x.Subject_Keyword,
                    Subject_Name = x.Subject_Name,
                    Subject_NumberPosts = x.Subject_NumberPosts,
                    Subject_Picture = x.Subject_Picture,
                    Subject_Url = x.Subject_Url
                }).FirstOrDefault();
            }
            return result;
        }
        public bool AddSubject(SubjectModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.SubjectRepository.GetWhere(x => x.Subject_ID == model.Subject_ID).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.ISubjectRepository.AddSubject(model);
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
