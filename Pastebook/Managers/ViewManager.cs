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

        public List<PostModel> FillNewsFeedPostList()
        { 
            var postModelList = new List<PostModel>();
            var postList = contentManager.RetrievePost();
            foreach(var item in postList)
            {
                var postModel = new PostModel();
                postModel.ID = item.ID;
                postModel.CreatedDate = item.CreatedDate;
                postModel.Content = item.Content;
                postModel.Profile_Owner_ID = item.Profile_Owner_ID;
                postModel.Poster_ID = item.Poster_ID;
                postModel.Poster = userManager.RetrieveSpecificUser(item.Poster_ID);
                postModel.LikeList = contentManager.RetrieveLikes(item.ID);
                postModel.CommentList = contentManager.RetrieveComment(item.ID);
                postModelList.Add(postModel);
            }
            return postModelList;
        }

        public List<PostModel> FillTimeLinePostList(int id)
        {
            var postModelList = new List<PostModel>();
            var postList = contentManager.RetrieveUserPost(id);
            foreach (var item in postList)
            {
                var postModel = new PostModel();
                postModel.ID = item.ID;
                postModel.CreatedDate = item.CreatedDate;
                postModel.Content = item.Content;
                postModel.Profile_Owner_ID = item.Profile_Owner_ID;
                postModel.Poster_ID = item.Poster_ID;
                postModel.Poster = userManager.RetrieveSpecificUser(item.Poster_ID);
                postModel.LikeList = contentManager.RetrieveLikes(item.ID);
                postModel.CommentList = contentManager.RetrieveComment(item.ID);
                postModelList.Add(postModel);
            }
            return postModelList;
        }
    }
}