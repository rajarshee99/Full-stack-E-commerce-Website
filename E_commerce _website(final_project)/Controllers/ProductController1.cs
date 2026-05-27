using E_commerce__website_final_project_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;

namespace E_commerce__website_final_project_.Controllers
{
    public class ProductController1 : Controller
    {
        private projectcontext _projectcontext;
        public ProductController1(projectcontext projectcontext)
        {
            _projectcontext = projectcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var email = HttpContext.Session.GetString("email");
            if (email != null)
            {
                var data = await (from e1 in _projectcontext.products select e1).ToListAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }


        }
        public IActionResult create()
        {
            var email = HttpContext.Session.GetString("email");
            if (email != null)
            {
                // var data2 = _projectcontext.admins.Where(x => x.a_e_mail == email).FirstOrDefault();
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }

        }
        [HttpPost]
        public async Task<IActionResult> create(product p)
        {
            try
            {
                await _projectcontext.products.AddAsync(p);
                await _projectcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {


            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var email = HttpContext.Session.GetString("email");
            if (email != null)
            {

                var data = await (from e2 in _projectcontext.products where (e2.p_id == id) select e2).FirstOrDefaultAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(product p)
        {
            _projectcontext.Entry(p).State = EntityState.Modified;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var email = HttpContext.Session.GetString("email");
            if (email != null)
            {

                var data = await (from e2 in _projectcontext.products where (e2.p_id == id) select e2).FirstOrDefaultAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }
        [HttpPost]
        public IActionResult Delete(int id, int a1)
        {
            var data = (from e1 in _projectcontext.products where (e1.p_id == id) select e1).FirstOrDefault();
            if (data != null)
            {
                _projectcontext.products.Remove(data);
                _projectcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("login", "Admin");
        }
        public async Task<IActionResult> add_to_cart(int id)
        {
            List<product> oldcart = null;
            var oldcartstring = HttpContext.Session.GetString("cart");
            if (oldcartstring != null)
            {
                oldcart = JsonConvert.DeserializeObject<List<product>>(oldcartstring);

            }

            if (oldcart == null)
            {
                List<product> productcart = new List<product>();
                var result = await _projectcontext.products.Where(x => x.p_id == id).FirstOrDefaultAsync();
                result.p_qty = 1;
                productcart.Add(result);
                string productcartstring = JsonConvert.SerializeObject(productcart);
                HttpContext.Session.SetString("cart", productcartstring);
            }
            else
            {
                int flag = 0;
                foreach (var item in oldcart)
                {
                    if (item.p_id == id)
                    {
                        item.p_qty += 1;
                        flag = 1; 
                        break;
                    }
                    
                }
                if (flag == 0) { 
                
                    var result= await _projectcontext.products.Where(x=>x.p_id==id).FirstOrDefaultAsync();
                    result.p_qty = 1;
                    oldcart.Add(result);
                }    
                string stringproductcart= JsonConvert.SerializeObject(oldcart);
                HttpContext.Session.SetString("cart",stringproductcart);


            }
            return RedirectToAction("Index","user");
        }
        public IActionResult cart()
        {
            List<product> oldcart = new List<product>();
            var oldcartstring = HttpContext.Session.GetString("cart");
            if (oldcartstring != null)
            {
                oldcart=JsonConvert.DeserializeObject<List<product>>(oldcartstring);
            }
            int totalamount = 0;
            foreach(var item in oldcart)
            {
                totalamount = item.p_qty * item.p_price;

            }
            ViewBag.totalamount = totalamount;
            return View(oldcart);
        }
        public ActionResult deletecart(int id) {
            List<product> oldcart = null;
            var oldcartstring = HttpContext.Session.GetString("cart");
            if (oldcartstring != null) {
                oldcart = JsonConvert.DeserializeObject<List<product>>(oldcartstring);
                
            }
            foreach(var item in oldcart)
            {
                if (item.p_id==id)
                {
                    oldcart.Remove(item);
                    break;
                }
            }
            string stringproductcart=JsonConvert.SerializeObject(oldcart);
            HttpContext.Session.SetString("cart", stringproductcart);
            return RedirectToAction("cart");
        
        }



    }
}
