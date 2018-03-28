using GVEBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.DAL
{
    class VendaDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        public static bool CadastrarVendas(Venda p)
        {
            try
            {
                ctx.Vendas.Add(p);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Venda> RetornarProdutos()
        {
            return ctx.Vendas.ToList();
        }

        public static Venda BuscarVendaPorID(int id)
        {
            return ctx.Vendas.FirstOrDefault(x => x.idVenda.Equals(id));
        }
    }
}
