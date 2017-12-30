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
    public class SubSubjectRepository : Repository<tbl_SubSubject, int>, ISubSubjectRepository
    {
        private Repository<tbl_SubSubject, int> _SubSubjectRepository;
        private DbSet<tbl_SubSubject> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public SubSubjectRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _SubSubjectRepository = new Repository<tbl_SubSubject, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_SubSubject>();
        }
        public bool AddSubSubject(SubSubjectModel model)
        {
            tbl_SubSubject subSubject = new tbl_SubSubject();
            try
            {
                subSubject.ID_Subject = model.ID_Subject;
                subSubject.IsDelete = false;
                subSubject.Sub_Description = model.Sub_Description;
                subSubject.Sub_Keyword = model.Sub_Keyword;
                subSubject.Sub_Picture = model.Sub_Picture;
                subSubject.Sub_SubjectName = model.Sub_SubjectName;
                subSubject.Sub_Url = model.Sub_Url;
                _dbContext.tbl_SubSubject.Add(subSubject);
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
