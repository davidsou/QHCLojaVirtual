using QHC.LojaVirtual.Dominio.Entidades;
using QHC.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;
        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoId, string returUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
           if(produto!=null)
           {
               ObterCarrinho().AdicionarItem(produto, 1);
           }

           return RedirectToAction("Index", new { returUrl});
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];
            if(carrinho ==null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto !=null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}