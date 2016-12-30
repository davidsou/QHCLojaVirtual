using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QHC.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;

        public string ServidorSmtp = "smtp.qhc.com.br";

        public int ServidorPorta = 587;

        public string Usuario = "Davidsou";

        public bool EscreveArquivo = false;

        public string PastaArquivo = @"C:\Users\Davi\Documents\Visual Studio 2013\Projects\QHC.LojaVirtual\EnvioEmail";

        public string Para ="pedido@qhc.com.br";

        public string De = "qhc@qhc.com.br";
    }
}
