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

        
        public ActionResult Home()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.PostList = viewManager.FillPostList();
            return PartialView(homeViewModel);
        }


        public PartialViewResult Content()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.PostList = contentManager.RetrievePost();
            return PartialView(homeViewModel);
        }

    }
}