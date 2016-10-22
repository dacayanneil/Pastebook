using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PastebookEFModel;
using PastebookDataAccessLayer;
using PastebookBusinessLogicLayer;

namespace PastebookUILayer.Controllers
{
    public class AppController : Controller
    {  
        // GET: App
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            int id = (int)Session["currentID"];
            return View(id);
        }
        
        public ActionResult UserHomeDetails()
        {
            return View();
        }

        public ActionResult Timeline(int id)
        {
            return View(id);
        }

        public ActionResult TimeLineProfile(int id)
        {
            var genericDataAccess = new GenericDataAccess<PB_USER>();
            var appBusinessLogic = new AppBusinessLogic();
            var userFriendModel = new UserFriendModel();
            userFriendModel.User = genericDataAccess.RetrieveByID(id);
            userFriendModel.Friends = appBusinessLogic.RetrieveUserFriends((int)Session["currentID"]);


            var currentID = (int)Session["currentID"];

            return PartialView("TimelineProfilePartial", userFriendModel);
        }

        public ActionResult NewsFeedPost(int id)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var newsFeedPostList = new List<PB_POST>();
            newsFeedPostList = appBusinessLogic.RetrieveNewsFeedPost(id);
            return PartialView("ShowPostPartial", newsFeedPostList);
        }

        public ActionResult TimelinePost(int id)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var timelinePostList = new List<PB_POST>();
            timelinePostList = appBusinessLogic.RetrieveTimeLinePost(id);
            return PartialView("ShowPostPartial", timelinePostList);
        }

        public JsonResult CreatePost(PB_POST post)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.CreatePost(post);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LikePost(PB_LIKE like)
        {
            var genericDataAccess = new GenericDataAccess<PB_LIKE>();
            var process = genericDataAccess.Create(like);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LikeNotification(PB_NOTIFICATION notification)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.CreateNotifForLike(notification);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UnlikePost(PB_LIKE like)
        {
            var genericDataAccess = new GenericDataAccess<PB_LIKE>();
            var process = genericDataAccess.Delete(like);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateComment(PB_COMMENT comment)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.CreateComment(comment);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCommentID(PB_COMMENT comment)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var commentID = appBusinessLogic.GetCommentID(comment);
            return Json( commentID, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CommentNotification(PB_NOTIFICATION notification)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.CreateNotifForComment(notification);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendFriendRequest(PB_FRIEND friend)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.CreateFriendRequest(friend);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AcceptFriendRequest(int id)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.AcceptFriendRequest(id);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeclineFriendRequest(int id)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.DeclineFriendRequest(id);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FriendRequestNotification(PB_NOTIFICATION notification)
        {
            var appBusinessLogic = new AppBusinessLogic();
            var process = appBusinessLogic.CreateNotifForFriendRequest(notification);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }
    }
}