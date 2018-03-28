using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.Model
{
    [Table("Vendas")]
    class Venda
    {
        [Key]
        public int idVenda { get; set; }
        public string CpfCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public int QuantProdVendido { get; set; }
        public double ValorVenda { get; set; }
    }
}
