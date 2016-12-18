using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QHC.LojaVirtual.Dominio.Entidades;
using System.Linq;

namespace QHC.LojaVirtual.Testes
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste Adicionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto();
            produto1.ProdutoId =1;
            produto1.Nome ="Teste 1";

            Produto produto2 = new Produto();
            produto1.ProdutoId = 2;
            produto1.Nome = "Teste 2";

            Produto produto3 = new Produto();
            produto3.ProdutoId = 3;
            produto3.Nome = "Teste 3";

            //Arrange - criação de carrinho

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 1);


            //Action

            ItemCarrinho[] itens = carrinho.ItemCarrinho.ToArray();

            //Assert

            Assert.AreEqual(itens.Length, 3);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }
    }
}
