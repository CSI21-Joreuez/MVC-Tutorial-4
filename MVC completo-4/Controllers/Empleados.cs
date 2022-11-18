using Microsoft.AspNetCore.Mvc;
using DAL.Modelo;
namespace MVC_completo_4.Controllers
{
    public class Empleados : Controller
    {
        public DAL.Modelo.MvcContext db = new MvcContext();
        //GET EMPLEADOS
        public IActionResult Index()
        {
            var empleados = db.Empleados.ToList();
            HttpContext.Session.GetString(empleados.ToString());
            return View(empleados);
        }
        [HttpPost]
        public ActionResult Index(int area_id)
        {
            Empleado empleado = db.Empleados.Where(e => e.AreaId == area_id).FirstOrDefault();
            if (empleado != null)
            {
                ViewBag.Area = "Empleado:" + empleado.Nombre + " - Area:" + empleado.Area.Area1;
            }
            return View(HttpContext.Session.GetString(empleado.ToString()));
        }
    }
}
