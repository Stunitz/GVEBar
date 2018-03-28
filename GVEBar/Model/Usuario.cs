using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.Model
{
    [Table("Usuarios")]
    class Usuario
    {
        [Key]
        public string CpfUsuario { get; set; }
        public string Senha { get; set; }
        public string CargoUsuario { get; set; }

    }
}