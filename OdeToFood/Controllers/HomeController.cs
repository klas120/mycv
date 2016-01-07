using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        //[ChildActionOnly]
        //[OutputCache(Duration=60)]
        //public ActionResult SayHello() 
        //{
        //    return Content("Hello word!!!");
        //}



        [OutputCache(Duration=5)]
        public ActionResult Index(string searchTerm = null)
        {
           // var controller = RouteData.Values["controller"];
           // var action = RouteData.Values["action"];
           // var id = RouteData.Values["id"];
           // var message = String.Format("{0}::{1} {2}", controller, action, id);
            //ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";

            //var model =
            //    from r in _db.Restaurants
            //    orderby r.Reviews.Average(review => review.Rating) descending
            //    select new RestaurantListViewModel
            //    {
            //        Id = r.Id,
            //        Name = r.Name,
            //        City = r.City,
            //        Country = r.Country,
            //        CountOfViews = r.Reviews.Count()
            //    };

            var model =
                _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select(r => new RestaurantListViewModel 
                        {
                            Id = r.Id,
                            Name = r.Name,
                            City = r.City,
                            Country = r.Country,
                            CountOfViews = r.Reviews.Count()
                        });

            return View(model);
        }

        public ActionResult About()
        {
           ViewBag.Message = "Página de descripción de la aplicación.";
           ViewBag.MensajeParaElMundo = "Todo lo puedo en Cristo que me fotalece. Y soy más que vencedor en Cristo!";

            var model = new AboutModel();
            model.Name = "Kenneth";
            model.Location = "Ciuda Quesada, San Carlos";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null){
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
