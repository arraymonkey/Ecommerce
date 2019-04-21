/*
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private EcommerceDbContext _context;

        public HomeController(EcommerceDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Login")))
            {
                HttpContext.Session.SetString("Login", "False");
                HttpContext.Session.SetInt32("UserId", 0);
            }  
            ViewBag.Error = TempData["error"];
            ViewBag.ErrorReg = TempData["ErrorReg"];
            return View("Index");
        }
        // Signin and login page
        [Route("signin")]
        public IActionResult Signin()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Login")))
            {
                HttpContext.Session.SetString("Login", "False");
                HttpContext.Session.SetInt32("UserId", 0);
            }  
            ViewBag.Error = TempData["error"];
            ViewBag.ErrorReg = TempData["ErrorReg"];
            return View("Signin");
        }
        //GET products in category
        [Route("products/category/{CategoryId}")]
        public IActionResult ShowCategory(int CategoryId)
        {
            //Retrieve category from url input
            Category RetrievedCategory = _context.categories.SingleOrDefault(c => c.CategoryId == CategoryId);
            @ViewBag.MyCategory = RetrievedCategory;
            @ViewBag.CategoryId = CategoryId;
            //Product list that category is attached to.
            var MyProducts = (from p in _context.products
                                join pc in _context.productcategories on p.ProductId equals pc.ProductId
                                where pc.CategoryId == CategoryId 
                                select p).ToList();
            ViewBag.MyProducts = MyProducts;
            return View("ShowCategory");
        }
        //GET one product
        [Route("products/show/{ProductId}")]
        public IActionResult ShowProduct()
        {
            return View("ShowProduct");
        }
        //GET user's cart
        [Route("cart")]
        public IActionResult ShowCart()
        {
            return View("ShowCart");
        }
        //POST Register user  
        [HttpPost]
        [Route("PostRegister")]
        public IActionResult PostRegister(UserValidator User)
        {   
            if(ModelState.IsValid)  
            {   
                User OldUser =_context.users.SingleOrDefault(user => user.Email == User.Email);
                if(OldUser == null){
                
                User NewUser = new User();
                NewUser.FirstName = User.FirstName;
                NewUser.LastName = User.LastName;
                NewUser.Email = User.Email;
                // DateTime CurrentTime = DateTime.Now;
                // NewUser.CreatedAt = CurrentTime;
                
                PasswordHasher<UserValidator> Hasher = new PasswordHasher<UserValidator>();
                NewUser.Password = Hasher.HashPassword(User, User.Password);
                
                _context.users.Add(NewUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("Login", "True");
                HttpContext.Session.SetInt32("UserId", NewUser.UserId);
                return RedirectToAction("Index");
                }
                //if user is found
                else{
                TempData["ErrorReg"] = "That email address already exists";
                return RedirectToAction("Signin");
                }
            }
            else
            {
                return View("Signin");
            }
        }
        //POST Login user
        [HttpPost("PostLogin")]
        public IActionResult PostLogin(string PasswordLogin, string EmailLogin)
        {   
            if(EmailLogin != null && PasswordLogin != null)
            {   
               User User =_context.users.SingleOrDefault(user => user.Email == EmailLogin);
                if(User != null){
                    var Hasher = new PasswordHasher<User>();
                
                    if(0 != Hasher.VerifyHashedPassword(User, User.Password, PasswordLogin))
                    {
                        HttpContext.Session.SetString("Login", "True");
                        HttpContext.Session.SetInt32("UserId", User.UserId);
                        return RedirectToAction("Index");
                    }
                }
                TempData["Error"] = "Your email or password are not correct";
                return RedirectToAction("Signin");      
            }
            else 
            {   
                TempData["Error"] = "An email and password are required";
                return RedirectToAction("Signin");
            }
        }
        [HttpGet("Logoff")]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        //ADMIN FUNCTIONS

        //GET Admin Dashboard
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            
            return View("ADashboard");
        }

        //GET Create product
        [HttpGet("admin/product")]
        public IActionResult AdminGetProduct()
        {
            var Products = (from p in _context.products 
                                select p).ToList();
            @ViewBag.Products = Products;
            return View("AProduct");
        }
        //GET Create category
        [HttpGet("admin/category")]
        public IActionResult AdminGetCategory()
        {
            ViewBag.Error = TempData["Error"];

            //Get all categories
            var Categories = (from c in _context.categories 
                                select c).ToList();
            @ViewBag.Categories = Categories;
            return View("ACategory");
        }
        
        //POST Create category
        [HttpPost("admin/category")]
        public IActionResult AdminPostCategory(Category Category)
        {
            if(ModelState.IsValid)  
            {   Category OldCategory = _context.categories.SingleOrDefault(c => c.Name == Category.Name);
                if(OldCategory == null){
                    Category NewCategory = new Category();
                    NewCategory.Name = Category.Name;
                               
                    _context.categories.Add(NewCategory);
                    _context.SaveChanges();
                    return RedirectToAction("AdminGetCategory");
                }
                else{
                    TempData["Error"] = "That category already exists";
                    return RedirectToAction("AdminGetCategory");
                }
            }
            else
            {
                return View("ACategory");
            }
        }
        //POST Create product
        [HttpPost("admin/product")]
        public IActionResult AdminPostProduct(Product Product)
        {
            if(ModelState.IsValid)  
            {   
                Product NewProduct = new Product();
                NewProduct.Name = Product.Name;
                NewProduct.Description = Product.Description;
                NewProduct.Price = Product.Price;
          
                _context.products.Add(NewProduct);
                _context.SaveChanges();
                int ProductId = NewProduct.ProductId;
                TempData["ProductId"] = ProductId;
                // return RedirectToAction("ShowProduct");
                return Redirect($"/admin/product/{ProductId}");
            }    
            else
            {
                return View("AProduct");
            }
        }
        //GET 1 category
        [Route("admin/category/{CategoryId}")]
        [HttpGet]
        public IActionResult AdminShowCategory(int CategoryId)
        {
            //Retrieve category from url input
            Category RetrievedCategory = _context.categories.SingleOrDefault(c => c.CategoryId == CategoryId);
            @ViewBag.MyCategory = RetrievedCategory;
            @ViewBag.CategoryId = CategoryId;
            //Product list that category is attached to.
            var MyProducts = (from p in _context.products
                                join pc in _context.productcategories on p.ProductId equals pc.ProductId
                                where pc.CategoryId == CategoryId 
                                select p).ToList();
            ViewBag.MyProducts = MyProducts;
            //All other products
            var OtherProducts = from p in _context.products    
                                    where !(MyProducts).Contains(p)     
                                    select p;
            ViewBag.OtherProducts = OtherProducts;

            return View("ACategories");
        }
        //GET 1 product
        [Route("admin/product/{ProductId}")]
        [HttpGet]
        public IActionResult AdminGetProduct(int ProductId)
        {
            //Retrieve product from url input
            Product RetrievedProduct = _context.products.SingleOrDefault(p => p.ProductId == ProductId);
            @ViewBag.MyProduct = RetrievedProduct;
            @ViewBag.ProductId = ProductId;
            //Category list product is attached to already
            var Categories1 = (from c in _context.categories
                                join p in _context.productcategories on c.CategoryId equals p.CategoryId
                                where p.ProductId == ProductId 
                                select c).ToList();
            @ViewBag.Categories1 = Categories1;
            //All other categories
            var query =    from c in _context.categories    
                            where !(Categories1).Contains(c)     
                            select c;
            ViewBag.query = query;

            return View("AProducts");
        }
        
        //POST Assign category/product relationship
        [HttpPost]
        [Route("admin/Process")]
        public IActionResult AdminProcess(int CategoryId, int ProductId)
        {
            ProductCategory NewProductCategory = new ProductCategory();
            NewProductCategory.ProductId = ProductId;
            NewProductCategory.CategoryId = CategoryId;        
            _context.productcategories.Add(NewProductCategory);
            _context.SaveChanges();
            // Return Redirect("~/product/" + ProductId);
            return Redirect($"/admin/product/{ProductId}");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
*/
