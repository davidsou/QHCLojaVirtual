using QHC.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QHC.LojaVirtual.Web.HtmlHelpers
{
    
    public static class PaginacaoHelpers
    {
        //total paginas = 3
        // este método funciona como uma Extension para a classe MvcHtmlString
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaURL)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", paginaURL(i));
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");

                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}