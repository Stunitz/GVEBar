using GVEBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVEBar.DAL
{
    class FuncionarioDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        public static bool CadastrarFuncionario(Funcionario p)
        {
            try
            {
                ctx.Funcionarios.Add(p);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Funcionario> Retornarfuncionarios()
        {
            return ctx.Funcionarios.ToList();
        }

        public static Funcionario BuscarFuncionarioPorCPF(string cpf)
        {
            return ctx.Funcionarios.FirstOrDefault(x => x.CpfFuncionario.Equals(cpf));
        }
    }
}