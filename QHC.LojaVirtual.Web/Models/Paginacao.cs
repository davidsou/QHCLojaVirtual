using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QHC.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItensTotal { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }
        //Propriedade não necessita de set.
        //Ceiling arrendonda para um número inteiro.
        public int TotalPagina
        {
            get
            {
                return (int)Math.Ceiling((decimal) ItensTotal/ItensPorPagina);;
            }
        }
    }
}