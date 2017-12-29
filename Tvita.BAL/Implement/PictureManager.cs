using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.BAL.Implement
{
    public class PictureManager
    {
        public List<PictureModel> GetAllPicture()
        {
            List<PictureModel> result = new List<PictureModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PictureRepository.QueryAll().Select(x => new PictureModel
                {
                    Picture_ID = x.Picture_ID,
                    IsDelete = x.IsDelete,
                    Picture_Description = x.Picture_Description,
                    Picture_Name = x.Picture_Name,
                    Picture_Url = x.Picture_Url
                }).ToList();
            }
            return result;
        }
        public PictureModel GetPictureById(int id)
        {
            PictureModel result = new PictureModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PictureRepository.GetWhere(x => x.Picture_ID == id).Select(x => new PictureModel
                {
                    Picture_Description = x.Picture_Description,
                    IsDelete = x.IsDelete,
                    Picture_ID = x.Picture_ID,
                    Picture_Name = x.Picture_Name,
                    Picture_Url = x.Picture_Url
                }).FirstOrDefault();
            }
            return result;
        }
    }
}
