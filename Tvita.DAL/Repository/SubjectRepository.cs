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
    class SubjectRepository : Repository<tbl_Subject, int>, ISubjectRepository
    {
        private Repository<tbl_Subject, int> _SubjectRepository;
        private DbSet<tbl_Subject> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public SubjectRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _SubjectRepository = new Repository<tbl_Subject, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Subject>();
        }
        public bool AddSubject(SubjectModel model)
        {
            tbl_Subject subject = new tbl_Subject();
            try
            {
                subject.IsDelete = false;
                subject.Subject_Description = model.Subject_Description;
                subject.Subject_Keyword = model.Subject_Keyword;
                subject.Subject_Name = model.Subject_Name;
                subject.Subject_NumberPosts = model.Subject_NumberPosts;
                subject.Subject_Picture = model.Subject_Picture;
                subject.Subject_Url = model.Subject_Url;
                _dbContext.tbl_Subject.Add(subject);
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
