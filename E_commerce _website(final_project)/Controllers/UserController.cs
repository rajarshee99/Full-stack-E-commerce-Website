using E_commerce__website_final_project_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce__website_final_project_.Controllers
{
    public class UserController : Controller
    {
        private projectcontext _projectcontext;
        public UserController(projectcontext projectcontext)
        {
            _projectcontext = projectcontext;
        }

        public IActionResult registration() { 
        return View();
        
        }
        [HttpPost]
        public IActionResult registration(customer customer)
        {
            var data= _projectcontext.customers.Where(x=>x.c_e_mail==customer.c_e_mail).FirstOrDefault();
            if (data == null)
            {
                _projectcontext.customers.Add(customer);
                _projectcontext.SaveChanges();
                return RedirectToAction("login");
            }
            else
            {
                ViewBag.Message = "user already exsist";
                return View();
            }
        }
        public IActionResult login() {
            return View();   
        
        }
        [HttpPost]
        public async Task<IActionResult> login(customer customer) {

            var checkuser = await _projectcontext.customers.Where(c => c.c_e_mail == customer.c_e_mail && c.c_password == customer.c_password).FirstOrDefaultAsync();
            if (checkuser != null) { 
                HttpContext.Session.SetString("email",customer.c_e_mail);
                return RedirectToAction("Index");
            
            }
            else
            {
                ViewBag.message = "wrong credential";
                return View();
            }
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var email = HttpContext.Session.GetString("email");
            if (email != null)
            {
                //await _projectcontext.customers.Where(x => x.c_e_mail == email).FirstOrDefaultAsync();
                var data = await (from e1 in _projectcontext.products select e1).ToListAsync();
                 return View(data);
            }
            else
            {
                return RedirectToAction("login");
            }
            
           
        }
    }
}
