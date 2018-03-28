using GVEBar.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.DAL
{
  

    class Context : DbContext
    {

        public Context() : base("dbGVEBar")
        {
        }
        public DbSet<Funcionario> Funcionarios { get; set;}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }

}