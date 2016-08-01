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
            var knownUsers = UserManager.Users.ToList();

            var users = new List<string>();
            var colours = new List<string>();
            var bowlingResults = new List<List<string>>();

            for (var u = 0; u < knownUsers.Count; u++)
            {
                users.Add(knownUsers[u].UserName);
                colours.Add(knownUsers[u].FavouriteColour);
                bowlingResults.Add(new List<string> { knownUsers[u].UserName, knownUsers[u].FavouriteColour });
            };

            var model = new BowlingViewModel
            {
                UserNames = users,
                FavouriteColours = colours,
                BowlingResults = bowlingResults
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