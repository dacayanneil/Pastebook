using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class ViewManager
    {
        UserManager userManager = new UserManager();
        ContentManager contentManager = new ContentManager();

        public List<PostModel> FillPostList()
        {
            var postModelList = new List<PostModel>();
            var postList = contentManager.RetrievePost();
            foreach(var item in postList)
            {
                //postModel.ID = item.ID;
                //postModel.CreatedDate = item.CreatedDate;
                //postModel.Content = item.Content;
                //postModel.Profile_Owner_ID = item.Profile_Owner_ID;
                //postModel.Poster_ID = item.Poster_ID;
                postModelList.Add(new PostModel {
                    ID = item.ID,
                    CreatedDate = item.CreatedDate,
                    Content = item.Content,
                    Profile_Owner_ID = item.Profile_Owner_ID,
                    Poster_ID = item.Poster_ID,
                    Poster = userManager.RetrieveSpecificUser(item.Poster_ID),
                    LikeList = contentManager.RetrieveLikes(item.Poster_ID),
                    CommentList = contentManager.RetrieveComment(item.Poster_ID)
                });
            }
            return postModelList;
        }
    }
}