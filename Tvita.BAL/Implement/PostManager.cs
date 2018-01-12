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
    public class PostManager : IPostManager
    {
        public List<PostModel> GetAllPost()
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.QueryAll().Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete
                }).ToList();
            }
            return result;
        }
        public PostModel GetPostByID(int id)
        {
            PostModel result = new PostModel();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.Post_ID == id).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete
                }).FirstOrDefault();
            }
            return result;
        }
        public List<PostModel> GetRelatedPost(int idSubSubject, int idPost)
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                var res = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == idSubSubject && x.Post_ID != idPost).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete
                }).ToList();
                if (res.Any())
                {
                    result = res.Take(3).ToList();
                }
            }
            return result;
        }
        public List<PostModel> GetHotNewPost()
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                var res = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 1).OrderBy(x => x.Post_DateCreated).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete
                }).ToList();
                if (res.Any())
                {
                    result = res.Take(5).ToList();
                }
            }

            return result;
        }
        public List<PostModel> GetKitchenNews()
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                var res = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 4).OrderBy(x => x.Post_DateCreated).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete
                }).ToList();
                if (res.Any())
                {
                    result = res.Take(3).ToList();
                }
            }

            return result;
        }
        public bool AddPost(PostModel model)
        {
            try
            {
                using (IUnitOfWork uOW = new UnitOfWork())
                {
                    var exist = uOW.PostRepository.GetWhere(x => x.Post_ID == model.Post_ID).FirstOrDefault();
                    if (exist == null)
                    {
                        uOW.IPostRepository.AddPost(model);
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
