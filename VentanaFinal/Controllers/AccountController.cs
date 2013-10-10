using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentanaFinal.Interfaces;
using VentanaFinal.Models.Account;

namespace VentanaFinal.Controllers
{
    public class AccountController : Controller
    {
        private IMembership _membership;
        public AccountController(IMembership membership)
        {
            this._membership = membership;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                this._membership.LoginUser(loginModel.Email, loginModel.Password);
                return RedirectToAction("Index", "Home");
            }

            return View(loginModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                this._membership.CreateAccount(registerModel.Email, registerModel.Password, "Admin", false, null);
                return RedirectToAction("Login");
            }

            return View(registerModel);
        }

        public ActionResult Logout()
        {
            this._membership.LogoutUser();
            return RedirectToAction("Index", "Home");
        }
    }
}
