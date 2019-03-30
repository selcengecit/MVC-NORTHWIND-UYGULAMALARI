using MVC_NorthWindUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NorthWindUygulama.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities ctx = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            //Context üzerindeki ürünleri listeye cek ve bu ürünler listesini viewe gönder
            // bunun için en sık kullanılan yöntem MODEL yöntemidir.
            List<Product> products = ctx.Products.ToList();
            List<Category> categories = ctx.Categories.ToList();
            ViewBag.categorylist = categories;
            //Aşagıdaki View metodunun arasına bir değişken vermek o değişkeni MODEL yöntemiyle viewe
            //göndermek demektir.Model yöntemiyle viewe sadece bir tane liste gönderilebilir.
            //Tek bi action içerinden iki farklı listeyi tek bi view içinde listelemek istersek model yöntemine
            //ek olarak ViewBag metodu kullanabiliriz.ViewBag yöntemiyle istediğiniz isimde dinamik tip tanımlayabilir
            //ve içini doldurabilirsiniz

            return View(products);
            //Context içindeki ürünler(products) viewe gönderilecek bunun için actiondan gönderilen verinin
            //view tarafından yakalanması gerekir.Bu yüzden bu actionun gösterdiği viewin içinde (index.cshtml);
            //index()actionu bir veri gönderiyor ve bu verinin tipi List<Product>tır diye belirtmek gerekir.
        }
        public ActionResult AddProduct()
        {
           List<Category> cat= ctx.Categories.ToList();
            List<Supplier> supp = ctx.Suppliers.ToList();
            ViewBag.categoryList = cat;
            ViewBag.supplierList = supp;
            return View();
        }

        //[HttpPost]
        //public ActionResult AddProduct(string productName, decimal unitPrice, short unitsInStock, int catID, int supID)

        //{
        //    Product prd = new Product();
        //    prd.ProductName = productName;
        //    prd.UnitPrice = unitPrice;
        //    prd.UnitsInStock = unitsInStock;
        //    prd.CategoryID = catID;
        //    prd.SupplierID = supID;

        //    ctx.Products.Add(prd);
        //    ctx.SaveChanges();

        //    //return View("index"); eger bu şekilde çagırısak sadece o actıonu cagırır ama actıonun içinde yapılan işlemleri yapmaz
        //    return RedirectToAction("Index");// bu metot ile hem actionu cagırıyoruz hem de çalıştırıyoruz.
        //}
        [HttpPost]
        public ActionResult AddProduct(Product p)

        {
            Product prd = new Product();
            prd.ProductName = p.ProductName;
            prd.UnitPrice = p.UnitPrice;
            prd.UnitsInStock = p.UnitsInStock;
            prd.CategoryID = p.CategoryID;
            prd.SupplierID = p.SupplierID;

            ctx.Products.Add(prd);
            ctx.SaveChanges();

            //return View("index"); eger bu şekilde çagırısak sadece o actıonu cagırır ama actıonun içinde yapılan işlemleri yapmaz
            return RedirectToAction("Index");// bu metot ile hem actionu cagırıyoruz hem de çalıştırıyoruz.
        }

    }
}