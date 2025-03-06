using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder.Extensions;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.Net;
using Firebase.Utils;
using System.Text.Json.Nodes;
using System;
// Configura Firebase con tus credenciales de Google


namespace FirebaseLoginCustom.Controllers
{

    public class LoginController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {

            if (username == "usuario" && password == "contraseña")
             {
               
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Usuario")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
            }
            
                ViewBag.Error = "Credenciales inválidas";
                return View();
        

        }
    }
}