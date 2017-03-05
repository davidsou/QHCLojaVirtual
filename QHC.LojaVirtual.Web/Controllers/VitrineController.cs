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
        public int ProdutosPorPagina = 12;
        // GET: Vitrine
        //public ActionResult ListaProdutos(string categoria, int pagina = 1)
        //{
        //    _repositorio = new ProdutosRepositorio();

        //    ProdutosViewModel model = new ProdutosViewModel();
        //    model.Produtos = _repositorio.Produtos
        //        .Where(p => categoria == null || p.Categoria.ToUpper().Trim() == categoria.ToUpper())
        //       .OrderBy(p => p.Descricao)
        //       .Skip((pagina - 1) * ProdutosPorPagina)
        //       .Take(ProdutosPorPagina);

        //    model.Paginacao = new Paginacao();
        //    model.Paginacao.ItensPorPagina = ProdutosPorPagina;
        //    model.Paginacao.PaginaAtual = pagina;
        //    model.CategoriaAtual = categoria;
        //    model.Paginacao.ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Count(e => e.Categoria.ToUpper().Trim() == categoria.ToUpper());

        //    return View(model);
        //}

        public ActionResult ListaProdutos(string categoria)
        {
            _repositorio = new ProdutosRepositorio();

            var model = new ProdutosViewModel();

            var rnd = new Random();

            if (categoria !=null)
            {
                model.Produtos = _repositorio.Produtos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(x => rnd.Next()).ToList();
            }
            else
            {
                model.Produtos = _repositorio.Produtos
                    .OrderBy(x => rnd.Next())
                    .Take(ProdutosPorPagina).ToList();
            }

         
            return View(model);
        }

        [Route("Vitrine/ObterImagem/{produtoid}")]
        public FileContentResult ObterImagem(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImageMimeType);
            }

            return null;
        }

        [Route("DetalhesProdutos/{id}/{produto}")]
        public ViewResult Detalhes (int id)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.ObterProduto(id);
            return View(produto);
        }
    }
}