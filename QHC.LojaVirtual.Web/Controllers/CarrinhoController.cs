using QHC.LojaVirtual.Dominio.Entidades;
using QHC.LojaVirtual.Dominio.Repositorio;
using QHC.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ViewResult Index(Carrinho carrinho ,string returnUrl)
        {
            CarrinhoViewModel carrinhoview = new CarrinhoViewModel();

            carrinhoview.Carrinho = carrinho;
            carrinhoview.ReturnUrl = returnUrl;

            return View(carrinhoview);

        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            return PartialView(carrinho);
        }


        // GET: Carrinho
        public RedirectToRouteResult Adicionar(Carrinho carrinho ,int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
           if(produto!=null)
           {
               carrinho.AdicionarItem(produto, 1);
           }

           return RedirectToAction("Index", new { returnUrl});
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

        public RedirectToRouteResult Remover(Carrinho carrinho,int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto !=null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    
     
        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho,Pedido pedido)
        {
            
            EmailConfiguracoes email = new EmailConfiguracoes();
            email.EscreveArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false");

            EmailPedido emailPedido = new EmailPedido(email);

            if(!carrinho.ItemCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio");

            }

            if(ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();

        }
    }


}