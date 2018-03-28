using GVEBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace GVEBar.DAL
{
    class ProdutoDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        public static bool CadastarProdutos(Produto p)
        {
            try
            {
                ctx.Produtos.Add(p);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.ToList();
        }

        public static Produto BuscarProdutoPorCodigoBarras(string codigo)
        {
            return ctx.Produtos.FirstOrDefault(x => x.CodigoDeBarras.Equals(codigo));
        }

        public static Produto BuscarProdutoPorNome(string nome)
        {
            return ctx.Produtos.FirstOrDefault(x => x.NomeProduto.Equals(nome));
        }

        public static bool AlterarProduto(Produto p)
        {
            try
            {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public static bool RemoverProduto(Produto p)
        {
            try
            {
                ctx.Produtos.Remove(p);
                ctx.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}