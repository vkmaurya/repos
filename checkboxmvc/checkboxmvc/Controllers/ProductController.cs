using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using checkboxmvc.Models;


namespace checkboxmvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            productModel product = new productModel();
            using (ModelDb db = new ModelDb())
            {
                product.Products = db.Products.ToList<Product>();
            }
                return View(product);
        }

        [HttpPost]
        public ActionResult Index(productModel model)
        {
            var selectProduct = model.Products.Where(x => x.IsChecked == true).ToList<Product>();

            return Content(string.Join(",", selectProduct.Select(x => x.ProductName)));
        }
    }
}