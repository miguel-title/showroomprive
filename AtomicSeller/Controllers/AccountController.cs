using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtomicSeller.Helpers;
using AtomicSeller.ViewModels;
using AtomicSeller.Models;

namespace AtomicSeller.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {

            return RedirectToAction("Index", "Home");
            //return View();
        }


    }
}