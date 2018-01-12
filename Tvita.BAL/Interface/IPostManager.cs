using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvita.Model.Table;

namespace Tvita.BAL.Interface
{
    interface IPostManager
    {
        List<PostModel> GetAllPost();
        PostModel GetPostByID(int id);
        List<PostModel> GetRelatedPost(int idSubSubject, int idPost);
        List<PostModel> GetKitchenNews();
        List<PostModel> GetHotNewPost();
    }
}
