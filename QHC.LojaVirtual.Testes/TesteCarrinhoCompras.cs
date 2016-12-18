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

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto();
            produto1.ProdutoId = 1;
            produto1.Nome = "Teste 1";

            Produto produto2 = new Produto();
            produto2.ProdutoId = 2;
            produto2.Nome = "Teste 2";

            //Produto produto3 = new Produto();
            //produto3.ProdutoId = 3;
            //produto3.Nome = "Teste 3";

            //Arrange - criação de carrinho

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);


            //Action

            ItemCarrinho[] itens = carrinho.ItemCarrinho.OrderBy(c=> c.Produto.ProdutoId).ToArray();

            //Assert

            Assert.AreEqual(itens.Length, 2);

            Assert.AreEqual(itens[0].Quantidade, 11);
        
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto();
            produto1.ProdutoId = 1;
            produto1.Nome = "Teste 1";

            Produto produto2 = new Produto();
            produto2.ProdutoId = 2;
            produto2.Nome = "Teste 2";

            Produto produto3 = new Produto();
            produto3.ProdutoId = 3;
            produto3.Nome = "Teste 3";

           // Arrange - criação de carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2);

            Assert.AreEqual(carrinho.ItemCarrinho.Where(c => c.Produto == produto2).Count(),0);

            Assert.AreEqual(carrinho.ItemCarrinho.Count(),2);
            
        }

        [TestMethod]
        public void CalcularValorTotal()
        {

            //Arrange - criação dos produtos
            Produto produto1 = new Produto();
            produto1.ProdutoId = 1;
            produto1.Nome = "Teste 1";
            produto1.Preco = 100M;

            Produto produto2 = new Produto();
            produto2.ProdutoId = 2;
            produto2.Nome = "Teste 2";
            produto2.Preco = 50M;


            // Arrange - criação de carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);
            decimal resultado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resultado, 450M);


        }

        [TestMethod]
        public void LimparItensCarrinho()
        {

            //Arrange - criação dos produtos
            Produto produto1 = new Produto();
            produto1.ProdutoId = 1;
            produto1.Nome = "Teste 1";
            produto1.Preco = 100M;

            Produto produto2 = new Produto();
            produto2.ProdutoId = 2;
            produto2.Nome = "Teste 2";
            produto2.Preco = 50M;


            // Arrange - criação de carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItemCarrinho.Count(), 0);

        }
    }
}
