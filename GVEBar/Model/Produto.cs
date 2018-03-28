using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.Model
{
    [Table("Produtos")]
    class Produto
    {
        [Key]
        public string CodigoDeBarras { get; set; }
        public string NomeProduto { get; set; }
        public double ValorDeCompra { get; set; }
        public double ValorDeVenda { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
    }
}