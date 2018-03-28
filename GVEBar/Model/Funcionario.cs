using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.Model
{
    [Table("Funcionarios")]
    class Funcionario
    {
       [Key]
        public string CpfFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public string CargoFuncionario { get; set; }
        public double Salario { get; set; }
    }
}
