using QHC.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHC.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        public void Salvar(Produto produto)
        { 
            if ( produto.ProdutoId == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                Produto p = _context.Produtos.Find(produto.ProdutoId);
                if (p!=null)
                {
                    p.Nome = produto.Nome;
                    p.Descricao = produto.Descricao;
                    p.Categoria = produto.Categoria;
                    p.Preco = produto.Preco;
                    p.Imagem = produto.Imagem;
                    p.ImageMimeType = produto.ImageMimeType;
                }
            }
            _context.SaveChanges();
        }
     
        public Produto Excluir (int produtoId)
        {
            Produto prod = _context.Produtos.Find(produtoId);
            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }
            return prod;
        }
    }
  
}
