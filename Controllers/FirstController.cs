using System.IO;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using System.Linq;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            // this.ModelState
            // this.ViewBag
            // this.ViewData
            // this.Url
            // this.TempData

            _logger.Log(LogLevel.Warning, "Thong bao Abc");
            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Index action");
            //Serilog
            return "Toi la Index cua FirstController";
        }
        public void Nothing()
        {
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("Hi", "Xin chao cac ban");
        }
        public object AnyThing() => Math.Sqrt(2);
        public object Anything() => new int[] { 1, 2, 3 };
        //IActionResult
        //     Kiểu trả về                 | Phương thức
        // ------------------------------------------------
        // ContentResult               | Content()
        // EmptyResult                 | new EmptyResult()
        // FileResult                  | File()
        // ForbidResult                | Forbid()
        // JsonResult                  | Json()
        // LocalRedirectResult         | LocalRedirect()
        // RedirectResult              | Redirect()
        // RedirectToActionResult      | RedirectToAction()
        // RedirectToPageResult        | RedirectToRoute()
        // RedirectToRouteResult       | RedirectToPage()
        // PartialViewResult           | PartialView()
        // ViewComponentResult         | ViewComponent()
        // StatusCodeResult            | StatusCode()
        // ViewResult                  | View()
        public IActionResult Readme()
        {
            var content = @"
        xin chao cac ban cac ban dang hoc ve ASP.NET MVC
        Doan Duy Thanh
        ";
            return Content(content, "text/html");
        }
        public IActionResult Sam()
        {
            // Startup.ContentRootPath
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "Sam.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }
        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Iphone 12 pro",
                    Price = 1000
                }
            );
        }
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den" + url);
            return LocalRedirect(url);//Local ~ host
        }
        public IActionResult Google()
        {
            var url = "https://www.google.com/";
            _logger.LogInformation("Chuyen huong den" + url);
            return Redirect(url);//Local ~ host
        }
        //ViewResult                |  View()
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Khach";
            //View() => Razor Engine, doc.cshtml (template)
            //==================
            //View(template) template duong dan tuyet doi toi cs.html
            //View(template, model)
            //Return View("/MyViews/xinchao1.cshtml", username);
            //xinchao2.cshtml => View/First/xinchao2.cshtml
            // return View("xinchao2", username);

            //HelloView.cshtml =>/View/First/HelloView.cshtml
            ///View/Controller/Action.cshtml
            // return View((object)username);
            return View("xinchao3", username);
            //View();
            //ViewModel();
        }
        [TempData]
        public String StatusMessage { get; set; }
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "San pham ban yeu cau khong co";
            return Redirect(Url.Action("Index", "Home"));
            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml

            //Model
            //return View(product);
            //ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");
            // ViewBag.product = product;
            // return View("product3");

        }
    }
}