using Microsoft.VisualStudio.TestTools.UnitTesting;
using QHC.LojaVirtual.Dominio.Entidades;
using QHC.LojaVirtual.Web.Controllers;
using QHC.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Testes
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        //Arrange

        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            Produto produto1 = new Produto();
            produto1.ProdutoId = 1;
            produto1.Nome = "Teste1";

            Produto produto2 = new Produto();
            produto2.ProdutoId = 2;
            produto2.Nome = "Teste2";

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 4);

            CarrinhoController controller = new CarrinhoController(); ;

            //Act
            controller.Adicionar(carrinho, 2, "");

            //Assert

            Assert.AreEqual(carrinho.ItemCarrinho.Count(), 2);

            Assert.AreEqual(carrinho.ItemCarrinho.ToArray()[0].Produto.ProdutoId, 1);

        }
        [TestMethod]
        public void Adiciono_Produto_No_Carrinho_Volta_Para_A_Categoria()
        {
            //Arrange

            Carrinho carrinho = new Carrinho();            
            CarrinhoController controller = new CarrinhoController();

            //Act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
        }

        [TestMethod]
        public void Posso_Ver_O_Conteudo_Do_Carrinho()
        {
            //Arrange

            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            //Act

            CarrinhoViewModel result = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;



            //Assert
            Assert.AreEqual(result.Carrinho,carrinho);
            Assert.AreEqual(result.ReturnUrl, "minhaUrl");
        }
    }
}
