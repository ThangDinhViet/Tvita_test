using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.BAL.Interface;
using Tvita.DAL.Common;
using Tvita.Model.Table;
using Tvita.Model.Common;

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
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
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
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).FirstOrDefault();
            }
            return result;
        }
        public List<PostModel> GetRelatedPost(int idSubSubject, int idPost)
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == idSubSubject && x.Post_ID != idPost).OrderBy(x => Guid.NewGuid()).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).ToList();
            }
            return result;
        }
        public List<PostModel> GetHotNewPost()
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 1).OrderByDescending(x => x.Post_ID).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).ToList();
                
            }

            return result;
        }
        public List<PostModel> GetKitchenNews()
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 4).OrderByDescending(x => x.Post_ID).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).ToList();
            }

            return result;
        }
        public List<PostModel> GetCommunityNews()
        {
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 5).OrderBy(x => x.Post_DateCreated).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).ToList();
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

        public RespondResult GetKitchenItems(LoadMoreParam _param)
        {
            var res = new RespondResult();
            res.pageInfo = new LoadMoreParam();
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 4).OrderByDescending(x => x.Post_ID).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).Skip(_param.recordsDisplayed).Take(_param.recordsInPage).ToList();
                res.pageInfo.total = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 4).Count();
            }
            int displayed = _param.recordsDisplayed + result.Count();
            res.data = result;
            res.pageInfo.recordsDisplayed = displayed;
            res.pageInfo.recordsInPage = _param.recordsInPage;
            return res;
        }

        public RespondResult GetNewsItems(LoadMoreParam _param)
        {
            var res = new RespondResult();
            res.pageInfo = new LoadMoreParam();
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 1).OrderBy(x => x.Post_DateCreated).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).Skip(_param.recordsDisplayed).Take(_param.recordsInPage).ToList();
                res.pageInfo.total = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 1).Count();
            }
            int displayed = _param.recordsDisplayed + result.Count();
            res.data = result;
            res.pageInfo.recordsDisplayed = displayed;
            res.pageInfo.recordsInPage = _param.recordsInPage;
            return res;
        }

        public RespondResult GetCommunityItems(LoadMoreParam _param)
        {
            var res = new RespondResult();
            res.pageInfo = new LoadMoreParam();
            List<PostModel> result = new List<PostModel>();
            using (IUnitOfWork uOW = new UnitOfWork())
            {
                result = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 5).OrderBy(x => x.Post_DateCreated).Select(x => new PostModel
                {
                    Post_Content = x.Post_Content,
                    Post_Description = x.Post_Description,
                    Post_Keyword = x.Post_Keyword,
                    Post_Picture = x.Post_Picture,
                    Post_Url = x.Post_Url,
                    Post_Video = x.Post_Video,
                    Post_ID = x.Post_ID,
                    Post_Name = x.Post_Name,
                    IsDelete = x.IsDelete,
                    Post_Content_EN = x.Post_Content_EN,
                    Post_Description_EN = x.Post_Description_EN,
                    Post_Name_EN = x.Post_Name_EN,
                }).Skip(_param.recordsDisplayed).Take(_param.recordsInPage).ToList();
                res.pageInfo.total = uOW.PostRepository.GetWhere(x => x.ID_SubSubject == 5).Count();
            }
            int displayed = _param.recordsDisplayed + result.Count();
            res.data = result;
            res.pageInfo.recordsDisplayed = displayed;
            res.pageInfo.recordsInPage = _param.recordsInPage;
            return res;
        }
    }
}