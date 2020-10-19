using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CreditoCarteraAdmin_AbInBev.Controllers
{
    public class CuentaController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public CuentaController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }

        public IActionResult Entrar()
        {
            //return RedirectToAction("Index", "Home");
            var authProperties = _signInManager
                .ConfigureExternalAuthenticationProperties("AzureAD",
                Url.Action("Index", "Home", null, Request.Scheme));

            return Challenge(authProperties, "AzureAD");
        }

        public IActionResult Bienvenido ()
        {
            return View();
        }
        public async Task<IActionResult> Salir()
        {

            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                var prop = new AuthenticationProperties()
                {
                    RedirectUri = Url.Action("Index", "Home")
                    };

                await HttpContext.SignOutAsync("AzureAD", prop);

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
