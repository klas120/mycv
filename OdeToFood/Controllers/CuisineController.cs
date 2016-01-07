using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        //[Authorize]
        public ActionResult Index()
        {            
            var message = Server.HtmlEncode("Exito, este es el index de cuisine, solamente la podrá ver si está logueado!!!");
            return Content(message);
        }

        // Pasar en formato JSON
        public ActionResult Search(string id) {
            var message = Server.HtmlEncode(id);

            return Json(new {  Message = message, Name = "Carlos Aragonés" }, JsonRequestBehavior.AllowGet);
        }

        [ActionName("BuscarArchivo")]
        public ActionResult SearchFile() {
            return File(Server.MapPath("~/Content/site.css"), "text/css");
        }

    }
}
