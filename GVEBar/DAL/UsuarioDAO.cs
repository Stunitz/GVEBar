using GVEBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.DAL
{
    class UsuarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        public static bool CadastrarUsuario(Usuario p)
        {
            try
            {
                ctx.Usuarios.Add(p);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Usuario> RetornarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        public static Usuario BuscarUsuario(string cpf, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.CpfUsuario.Equals(cpf) && x.Senha.Equals(senha));
        }
    }
}