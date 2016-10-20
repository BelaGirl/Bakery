using Bakery.BL;
using Bakery.ViewModel;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace Bakey.Web.Controllers
{
    public class AccountController : Controller    {      

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        //BakeryService _service = new BakeryService();
        
        IBakeryService _service;

        public AccountController(IBakeryService serv)
        {
            _service = serv;
        }

        public ActionResult Login()
        {
            return PartialView("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {                               
                UserViewModel user = _service.SearchUser(login);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                }

                else
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email));
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name));
                    claims.Add(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "OWIN Provider", ClaimValueTypes.String));

                    var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true                                             
                    }, identity);

                    // return RedirectToAction("Index", "Home");
                    // return JavaScript(String.Format("document.location.href = '{0}';", Url.Action("Index", "Home")));
                    return new EmptyResult();
                }                  
                
            }
            
            return PartialView("Login",login);
        }
                


        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home"); ;
        }



        public ActionResult Register()
        {
            return PartialView();
        }



        [HttpPost]
        public ActionResult Register(RegisterViewModel newUser)
        {
            if (ModelState.IsValid)
            {                           
                bool isNewUser = _service.CreateUser(newUser);
                if (isNewUser)
                        //  return RedirectToAction("Login", "Account");    
                        return new EmptyResult(); 

                else
                {
                    ModelState.AddModelError("", "Such user is in Database already.");

                }
            }
                        
            return PartialView(newUser);
           
        }





    }
}