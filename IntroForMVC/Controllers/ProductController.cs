using IntroForMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroForMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ShowAll()
        {
            ProductBL productBL = new ProductBL();
            List<Product> productListModel = productBL.GetAll();
            return View("ShowAll", productListModel);
        }

        public IActionResult ShowById(int id)
        {
            ProductBL productBL = new ProductBL();
            Product productModel = productBL.GetById(id);
            return View("ShowById", productModel);
        }
    }
}
