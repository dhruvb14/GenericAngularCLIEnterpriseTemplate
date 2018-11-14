using System;
using Brownbag.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Brownbag.Web.Middleware;

namespace Brownbag.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDataContext db;
        private readonly IBrownbagRoleProvider BrownbagRoleProvider;

        public AccountController(ApplicationDataContext context, IBrownbagRoleProvider rp)
        {
            db = context;
            BrownbagRoleProvider = rp;
        }
        public ActionResult Denied()
        {
            return View();
        }
        [Route("api/account/user")]
        public ActionResult GetRoles()
        {
            return Json(new { name = User.Identity.Name, roles = BrownbagRoleProvider.GetRolesForUser(User.Identity.Name), id = User.FindFirst("userId").Value });
        }
    }
}