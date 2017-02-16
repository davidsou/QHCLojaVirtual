using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHC.LojaVirtual.Dominio.Entidades
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage= "Digite o login")]
        [Display(Name="Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}
