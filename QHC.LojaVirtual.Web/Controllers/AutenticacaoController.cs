using QHC.LojaVirtual.Dominio.Entidades;
using QHC.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }
        public  void Login ()
        {
            
            Administrador administrador = new Administrador();
            administrador.Login = "QHC";
            AdministradoresRepositorio repositorio = new AdministradoresRepositorio();
            var admin = repositorio.ObterAdministrador(administrador);

        }
    }
}