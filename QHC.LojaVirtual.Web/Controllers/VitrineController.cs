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

            ProdutosViewModel model = new ProdutosViewModel();
            model.Produtos = _repositorio.Produtos
                .Where(p => categoria == null || p.Categoria.ToUpper().Trim() == categoria.ToUpper())
               .OrderBy(p => p.Descricao)
               .Skip((pagina - 1) * ProdutosPorPagina)
               .Take(ProdutosPorPagina);

            model.Paginacao = new Paginacao();
            model.Paginacao.ItensPorPagina = ProdutosPorPagina;
            model.Paginacao.PaginaAtual = pagina;
            model.CategoriaAtual = categoria;
            model.Paginacao.ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Count(e => e.Categoria.ToUpper().Trim() == categoria.ToUpper());

            return View(model);
        }
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
    }
}