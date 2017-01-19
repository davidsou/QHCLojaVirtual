using QHC.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;
        // GET: Produto 
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos.Take(10);
            return View(produtos);
        }
    }
}