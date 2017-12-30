using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.DAL.Common;
using Tvita.Model.Table;

namespace Tvita.DAL.Repository
{
    public class PictureRepository : Repository<tbl_Picture, int>, IPictureRepository
    {
        private Repository<tbl_Picture, int> _pictureRepository;
        private DbSet<tbl_Picture> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public PictureRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _pictureRepository = new Repository<tbl_Picture, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Picture>();
        }
        public bool AddPicture(PictureModel model)
        {
            tbl_Picture picture = new tbl_Picture();
            try
            {
                picture.Picture_Description = model.Picture_Description;
                picture.Picture_Name = model.Picture_Name;
                picture.Picture_Url = model.Picture_Url;
                picture.IsDelete = false;
                _dbContext.tbl_Picture.Add(picture);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
