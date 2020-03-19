using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RecordShack.Models;
using RecordShack.View_Models.Account;

namespace RecordShack.Controllers
{
    public class AccountController : Controller
    {
        RecordShackCMSEntities context = new RecordShackCMSEntities();

        // returns sign in partial view in the navigation
        public ActionResult SignInPartial()
        {
            return PartialView(@"/Views/Shared/SignInPartial.cshtml");
        }

        // http: get for sign in 
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        // http: post for sign in using SignInViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel view)
        {
            if(ModelState.IsValid)
            {
                bool userNameExisits = context.tblUsers.Any(x => x.UserName == view.UserName);
                if (!userNameExisits)
                {
                    ModelState.AddModelError("Username", "Username does not exist");
                    return View();
                }

                bool isUserValid = context.tblUsers
                                    .Any(x => x.UserName.ToLower() == view.UserName.ToLower() &&
                                     x.Password == view.Password);

                if(isUserValid)
                {
                    FormsAuthentication.SetAuthCookie(view.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Username", "Password or username is incorrect");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // http: get for register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // http: post for register using RegisterViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel view)
        {
            if(ModelState.IsValid)
            {
                bool isUserNameTaken = context.tblUsers.Any(u => u.UserName.ToLower() == view.UserName.ToLower());
                bool isEmailAddressTaken = context.tblUsers.Any(u => u.EmailAddress.ToLower() == view.EmailAddress.ToLower());

                if(isUserNameTaken)
                {
                    ModelState.AddModelError("UserName", "This username already exists");
                    return View();
                }
                else if(isEmailAddressTaken)
                {
                    ModelState.AddModelError("EmailAddress", "This email is already associted with an account");
                    return View();
                }
                else
                {
                    tblUser user = new tblUser(view.UserName, view.EmailAddress, view.Password);
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("SignIn");
                }

            }
            else
            {
                return View();
            }
        }

        // signout for users
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }   

        // details for users logged in 
        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                DetailsViewModel detailsvm = new DetailsViewModel(id);
                return View(detailsvm);
            }
            else
            {
                if(User.Identity.IsAuthenticated)
                {
                    DetailsViewModel detailsvm = new DetailsViewModel(User.Identity.Name.ToString());
                    return View(detailsvm);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            
        }
    }
}