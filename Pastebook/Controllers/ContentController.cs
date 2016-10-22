using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastebook.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager();
        UserManager userManager = new UserManager();
        ViewManager viewManager = new ViewManager();
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(PostModel post)
        {
            contentManager.AddPost(post);
            return View();
        }

        public JsonResult CreatePost(PostModel post)
        {
            var process = contentManager.AddPost(post);
            return Json(new { status = process}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LikePost(LikeModel like)
        {
            var process = contentManager.AddLike(like);
            return Json(new { status = process}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UnlikePost(int id)
        {
            var process = contentManager.RemoveLike(id);
            return Json(new { status = process }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult NewsFeedContent(int id)
        {
            var newsFeedPost = new UserPostDetailsModel();
            newsFeedPost.PostList = viewManager.FillTimeLinePostList(id);
            return PartialView("NewsfeedPartial", newsFeedPost);
        }

        public ActionResult TimeLineProfile(int id)
        {
            return View(id);
        }

        public ActionResult ProfileContent(int id)
        {
            var profileContent = new UserModel();
            profileContent = userManager.RetrieveSpecificUser(id);
            return PartialView("ProfileContentPartial", profileContent);
        }

        public ActionResult TimeLineContent(int id)
        {
            var timeLineContent = new UserPostDetailsModel();
            timeLineContent.PostList = viewManager.FillTimeLinePostList(id);
            return PartialView("TimeLineContentPartial", timeLineContent);
        }

    }
}