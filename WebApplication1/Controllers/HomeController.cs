using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LoginButton()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return PartialView("Login_Partial");
            }
            return new EmptyResult();
        }

        public ActionResult Bowling()
        {
            var users = new List<string>();
            var knownUsers = UserManager.Users.ToList();
            
            foreach( var u in knownUsers)
            {
                users.Add(u.UserName);
            };

            var model = new BowlingViewModel
            {
                UserNames = users
            };

            

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}