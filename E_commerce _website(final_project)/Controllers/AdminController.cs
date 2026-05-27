using E_commerce__website_final_project_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce__website_final_project_.Controllers
{
    public class AdminController : Controller
    {
        private projectcontext _projectcontext;
        public AdminController(projectcontext projectcontext)
        {
            _projectcontext = projectcontext;
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(admin admin)
        {
            var checkuser = await _projectcontext.admins.Where(a => a.a_e_mail == admin.a_e_mail && a.a_password == admin.a_password).FirstOrDefaultAsync();
            if (checkuser != null)
            {
                HttpContext.Session.SetString("email", admin.a_e_mail);
                return RedirectToAction("Index", "ProductController1");

            }
            else
            {
                ViewBag.message = "wrong credential";
                return View();
            }

        }

    }
}
