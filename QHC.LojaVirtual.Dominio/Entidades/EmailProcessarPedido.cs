using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QHC.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {

            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho,Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(
                _emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp
                    );

                if(_emailConfiguracoes.EscreveArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder();
                body.AppendLine("Novo Pedido");
                body.AppendLine("-----------");
                body.AppendLine("Itens");

                foreach (var item in carrinho.ItemCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", item.Quantidade, item.Produto.Nome, subtotal);
                }
                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal());
                body.AppendLine("-----------");

                body.AppendLine("Enviar Para:");
                body.AppendLine(pedido.NomeCliente);
                body.AppendLine(pedido.Email);
                body.AppendLine(pedido.Endereco??"");
                body.AppendLine(pedido.Cidade??"");
                body.AppendLine(pedido.Complemento ?? "");
                body.AppendLine("-----------");
                body.AppendFormat("Para presente?: {0}",pedido.EmbrulharPresente?"Sim":"Não");



                MailMessage mailMessage = new MailMessage(_emailConfiguracoes.De, _emailConfiguracoes.Para, "Novo Pedido", body.ToString());

                if(_emailConfiguracoes.EscreveArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                }
                smtpClient.Send(mailMessage);








            }
        }
    }
}
