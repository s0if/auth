using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace crud.Controllers
{ 
    public class UsersController : Controller
    {
        private readonly appDbContext context;

        public UsersController(appDbContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult add(User model)
        {
            var user = context.Users.Add(model);
            context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        
        public IActionResult check(User model)
        {
            var user=context.Users.Where(user=>user.Name == model.Name && user.Password == model.Password);
            if(user.Any())
            {
                return RedirectToAction(nameof(read));
            }
            ViewBag.Error = "invald username or password";
            return RedirectToAction(nameof(Login));
        }
        public IActionResult read()
        {
            var user =context.Users.Where(user=>user.IsActive==false).ToList();
            return View(user);
        }
        public IActionResult changeIsActive(Guid id)
        {
            var user = context.Users.Find(id);
            user.IsActive = true;
            context.SaveChanges();
            return RedirectToAction(nameof(read));
        }
    }
}
