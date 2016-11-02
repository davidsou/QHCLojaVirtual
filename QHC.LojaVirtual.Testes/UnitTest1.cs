using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using QHC.LojaVirtual.Web.HtmlHelpers;
using QHC.LojaVirtual.Web.Models;


namespace QHC.LojaVirtual.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Take()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5) select num;
        }

        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao()
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaURL = i => "Pagina" + i;
            
            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaURL);

            //Assert

            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString());


        }
    }

}
