using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookBL;

namespace Pastebook
{
    public class ContentManager
    {
        ContentBL contentBL = new ContentBL();
        Mapper mapper = new Mapper();

        public List<PostModel> RetrievePost()
        {
            var postList = new List<PostModel>();

            var result = contentBL.RetrievePosts();
            foreach(var item in result)
            {
                postList.Add(mapper.PostEntityToModel(item));
            }

            return postList;
        }

        public int AddPost(PostModel inputPost)
        {
            int status = 0;
            status = contentBL.AddPost(mapper.PostModelToEntity(inputPost));
            return status;
        }

        public List<LikeModel> RetrieveLikes(int id)
        {
            var likeList = new List<LikeModel>();
            var result = contentBL.RetrieveLikes(id);
            foreach(var item in result)
            {
                likeList.Add(mapper.LikeEntityToModel(item));
            }
            return likeList;
        }

        public List<CommentModel> RetrieveComment(int id)
        {
            var commentList = new List<CommentModel>();
            var result = contentBL.RetrieveComment(id);
            foreach(var item in result)
            {
                commentList.Add(mapper.CommentEntityToModel(item));
            }
            return commentList;
        }

    }
}