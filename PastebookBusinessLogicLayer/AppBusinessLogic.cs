using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;
using PastebookDataAccessLayer;

namespace PastebookBusinessLogicLayer
{
    public class AppBusinessLogic
    {
        public List<PB_POST> RetrieveTimeLinePost(int id)
        {
            var pastebookDataAccess = new PastebookDataAccess();
            var postList = new List<PB_POST>();

            try
            {
                var result = pastebookDataAccess.RetrievePost();
                postList = result
                            .Where(x=>x.PROFILE_OWNER_ID==id||x.POSTER_ID==id)
                            .OrderByDescending(x=>x.CREATED_DATE)
                            .ToList();
            }
            catch(Exception e)
            {
                throw;
            }
            return postList;
        }

        public List<PB_POST> RetrieveNewsFeedPost(int id)
        {
            var pastebookDataAccess = new PastebookDataAccess();
            var genericDataAccess = new GenericDataAccess<PB_FRIEND>();
            var postList = new List<PB_POST>();

            try
            {
                var retrieveFriends = genericDataAccess.Retrieve();
                var retrievePosts = pastebookDataAccess.RetrievePost();
                var result = (from friends in retrieveFriends
                              from posts in retrievePosts
                              where posts.POSTER_ID == friends.USER_ID || posts.POSTER_ID == friends.FRIEND_ID
                              where friends.REQUEST == "N" && friends.BLOCKED == "N"
                              where friends.USER_ID == id || friends.FRIEND_ID == id
                              select posts).Distinct()
                            .Union
                           (from posts in retrievePosts
                            where posts.POSTER_ID == id || posts.PROFILE_OWNER_ID == id
                            select posts);
                postList = result.OrderByDescending(x => x.CREATED_DATE).ToList();
            }
            catch(Exception e)
            {
                throw;
            }

            return postList;
        }

        public int CreatePost(PB_POST post)
        {
            var genericDataAccess = new GenericDataAccess<PB_POST>();
            post.CREATED_DATE = DateTime.Now;
            return genericDataAccess.Create(post);
        }

        public int GetCommentID(PB_COMMENT comment)
        {
            var genericDataAccess = new GenericDataAccess<PB_COMMENT>();
            var getComment = genericDataAccess.Retrieve()
                            .Where(x => x.POSTER_ID == comment.POSTER_ID)
                            .Where(x => x.POST_ID == comment.POST_ID)
                            .OrderByDescending(x => x.DATE_CREATED)
                            .FirstOrDefault();
            var id = getComment.ID;
            return id;   
        }

        public int CreateComment(PB_COMMENT comment)
        {
            var genericDataAccess = new GenericDataAccess<PB_COMMENT>();
            comment.DATE_CREATED = DateTime.Now;
            return genericDataAccess.Create(comment);
        }

        public int CreateNotifForLike(PB_NOTIFICATION notification)
        {
            var genericDataAccess = new GenericDataAccess<PB_NOTIFICATION>();
            int status = 0;
            notification.CREATED_DATE = DateTime.Now;
            notification.NOTIF_TYPE = "L";
            notification.SEEN = "N";
            status = genericDataAccess.Create(notification);
            return status;
        }

        public int CreateNotifForComment(PB_NOTIFICATION notification)
        {
            var genericDataAccess = new GenericDataAccess<PB_NOTIFICATION>();
            int status = 0;
            notification.CREATED_DATE = DateTime.Now;
            notification.NOTIF_TYPE = "C";
            notification.SEEN = "N";
            status = genericDataAccess.Create(notification);
            return status;
        }

        public int CreateNotifForFriendRequest(PB_NOTIFICATION notification)
        {
            var genericDataAccess = new GenericDataAccess<PB_NOTIFICATION>();
            int status = 0;
            notification.CREATED_DATE = DateTime.Now;
            notification.NOTIF_TYPE = "F";
            notification.SEEN = "N";
            status = genericDataAccess.Create(notification);
            return status;
        }

        public List<PB_FRIEND> RetrieveUserFriends(int id)
        {
            var genericDataAccess = new GenericDataAccess<PB_FRIEND>();
            return genericDataAccess.Retrieve().Where(x => x.USER_ID == id || x.FRIEND_ID == id).ToList();
        }

        public int CreateFriendRequest(PB_FRIEND friend)
        {
            var genericDataAccess = new GenericDataAccess<PB_FRIEND>();
            friend.REQUEST = "Y";
            friend.BLOCKED = "N";
            friend.CREATED_DATE = DateTime.Now;
            var status = genericDataAccess.Create(friend);
            return status;
        }

        public int AcceptFriendRequest(int id)
        {
            var genericDataAccess = new GenericDataAccess<PB_FRIEND>();
            var friend = genericDataAccess.RetrieveByID(id);
            friend.REQUEST = "N";
            var status = genericDataAccess.Update(friend);
            return status;
        }

        public int DeclineFriendRequest(int id)
        {
            var genericDataAccess = new GenericDataAccess<PB_FRIEND>();
            var friend = genericDataAccess.RetrieveByID(id);
            var status = genericDataAccess.Delete(friend);
            return status;
        }

    }
}
