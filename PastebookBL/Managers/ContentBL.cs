using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;
using System.Data.Entity;

namespace PastebookBL
{
    public class ContentBL
    {
        MapperBL mapper = new MapperBL();

        public int AddPost(PostEntity inputPost)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    inputPost.CreatedDate = DateTime.Now;
                    context.PB_POST.Add(mapper.PostEntityToDb(inputPost));
                    status = context.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

            return status;
        }

        public List<PostEntity> RetrievePosts()
        {
            List<PostEntity> postList = new List<PostEntity>();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_POST.ToList();
                    foreach(var item in result)
                    {
                        postList.Add(mapper.PostDbToEntity(item));
                    }
                }
            }
            catch(Exception e)
            {

            }
            return postList;
        }

        public int AddComment(CommentEntity inputComment)
        {
            int status = 0;

            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    inputComment.CreatedDate = DateTime.Now;
                    context.PB_COMMENT.Add(mapper.CommentEntityToDb(inputComment));
                    status = context.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }

            return status;
        }


        public int AddLike(LikeEntity inputLike)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    context.PB_LIKE.Add(mapper.LikeEntityToDb(inputLike));
                    status = context.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }
            return status;
        }

        public List<LikeEntity> RetrieveLikes(int id)
        {
            var likeList = new List<LikeEntity>();

            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_LIKE.Where(x=>x.POST_ID == id).ToList();
                    foreach(var item in result)
                    {
                        likeList.Add(mapper.LikeDbToEntity(item));
                    }
                }
            }
            catch(Exception e)
            {

            }
            return likeList;
        }

        public List<CommentEntity> RetrieveComment(int id)
        {
            var commentList = new List<CommentEntity>();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_COMMENT.Where(x => x.ID == id).ToList();
                    foreach(var item in result)
                    {
                        commentList.Add(mapper.CommentDbToEntity(item));
                    }
                }
            }
            catch(Exception e)
            {

            }
            return commentList;
        }

    }
}
