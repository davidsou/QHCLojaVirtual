using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QHC.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Required(ErrorMessage="Informe seu nome")]
        public string NomeCliente { get; set; }

        [Display(Name= "Cep:")]
        public int Cep { get; set; }

        [Required(ErrorMessage="Informe seu Endereço")]
        [Display(Name= "Endereco:")]
        public String Endereco { get; set; }

        [Display(Name="Complemento:")]
        public string Complemento { get; set; }
        
        [Required(ErrorMessage="Informe sua cidade")]
        [Display(Name="Cidade:")]
        public string Cidade { get; set; }

        [Required(ErrorMessage="Informe seu bairro")]
        [Display(Name="Bairro:")]
        public string Bairro { get; set; }
        
        [Display(Name="Estado:")]
        public string Estado { get; set; }

        [Required(ErrorMessage="Informe seu email")]
        [Display(Name="Email:")]
        [EmailAddress(ErrorMessage="Email invalido")]
        public string Email { get; set; }

        public bool EmbrulharPresente { get; set; }
    }
}
