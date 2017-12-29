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
    public class PostRepository : Repository<tbl_Post, int>, IPostRepository
    {
        private Repository<tbl_Post, int> _PostRepository;
        private DbSet<tbl_Post> _dbSet;
        private readonly Tvita_TestEntities _dbContext;
        public PostRepository(Tvita_TestEntities dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _PostRepository = new Repository<tbl_Post, int>(_dbContext);
            this._dbSet = _dbContext.Set<tbl_Post>();
        }
        public bool AddPost(PostModel model)
        {
            tbl_Post post = new tbl_Post();
            try
            {
                post.ID_SubSubject = model.ID_SubSubject;
                post.IsDelete = false;
                post.Post_Content = model.Post_Content;
                post.Post_Description = model.Post_Description;
                post.Post_Keyword = model.Post_Keyword;
                post.Post_Name = model.Post_Name;
                post.Post_Picture = model.Post_Picture;
                post.Post_Url = model.Post_Url;
                post.Post_Video = model.Post_Video;
                post.Post_DateCreated = model.Post_DateCreated;
                _dbContext.tbl_Post.Add(post);
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
