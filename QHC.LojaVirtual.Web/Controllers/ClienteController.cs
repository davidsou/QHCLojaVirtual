using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.Controllers
{
    public class ClienteController : Controller
    {
        [Route("Teste")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Cliente";
            ViewBag.Action = "Index";

            return View();
        }
        [Route("Usuario/Adicionar/{usuario}/{id}")]
        public string Adicionar(string usuario, int id)
        { 
            return String.Format("Usuário: {0}, Id {1}", usuario, id);
        }
    }
}