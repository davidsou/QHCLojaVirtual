using QHC.LojaVirtual.Dominio.Repositorio;
using QHC.LojaVirtual.Dominio.Entidades;
using QHC.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 3;
        // GET: Vitrine
        public ActionResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos
               .Where(p => categoria == null || p.Categoria.ToUpper().Trim() == categoria.ToUpper())
               .OrderBy(p => p.Descricao)
               .Skip((pagina - 1) * ProdutosPorPagina)
               .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },
                CategoriaAtual = categoria
            };

          


            return View(model);
        }
    }
}