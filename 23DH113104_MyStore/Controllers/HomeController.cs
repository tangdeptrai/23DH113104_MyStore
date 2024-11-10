using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _23DH113104_MyStore.Models;
using _23DH113104_MyStore.Models.ViewModel;
using PagedList;

namespace _23DH113104_MyStore.Controllers
{
    public class HomeController : Controller
    {
        public class ProductsController : Controller
        {
            private MYSTOREEntities db = new MYSTOREEntities();
            // GET: Products
            public ActionResult Index(string searchTerm,  int? page)
            {
                var model = new HomeProductVM();
                var products = db.Products.AsQueryable();
                if (!string.IsNullOrEmpty(searchTerm))
                { //Tìm kiếm sản phẩm dựa trên từ khóa
                    model.SearchTerm = searchTerm;
                    products = products.Where(p =>
                    p.ProductName.Contains(searchTerm) ||
                    p.ProductDescription.Contains(searchTerm) ||
                    p.Category.CategoryName.Contains(searchTerm));
                }

                //Đoạn code liên quan đến phân trang
                //Lấy số trang hiện tại(mặc định là trang 1 nếu không có giá trị)
                int pageName = page ?? 1;
                int pageSize = 6;// Số sản phẩm mỗi trang
                //Lấy top 10 sản phẩm bán chạy nhất
                model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
                //Lấy 20 sản phẩm bán ế nhất và phân trang
                model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(page ?? 1, 6);
                //model.Products = products.ToList();
                if (model.FeaturedProducts == null)
                {
                    // Ghi log hoặc debug
                    Console.WriteLine("FeaturedProducts is null");
                }
                else
                {
                    Console.WriteLine($"FeaturedProducts has {model.FeaturedProducts.Count} items");
                }

                return View(model);
            }
        }
    }
}