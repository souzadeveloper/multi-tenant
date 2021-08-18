using Repository;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public ActionResult Index()
        {
            var clientes = _clienteRepository.GetClientes();

            return View(clientes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}