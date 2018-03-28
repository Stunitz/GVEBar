using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GVEBar.Util;
using GVEBar.DAL;
using GVEBar.Model;
using System.Speech.Synthesis;

namespace GVEBar.View
{
    /// <summary>
    /// Interaction logic for frmCadastrarUsuario.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.Rate = 3;

            if (UsuarioDAO.BuscarUsuario(txtCpfUsuario.Text, pwbSenha.Password) != null)
            {
                if (UsuarioDAO.BuscarUsuario(txtCpfUsuario.Text, pwbSenha.Password).CargoUsuario.Equals("Administração"))
                {
                    frmPrincipal frm = new frmPrincipal();
                    frm.Show();
                    Close();
                }
                else
                {
                    frmRegistrarVendas frm = new frmRegistrarVendas();
                    frm.Show();
                    Close();
                }
            }
            else
            {
                synthesizer.SpeakAsync("Dados incorretos! O login ou a senha estão incorretos!");
                MessageBox.Show("Dados incorretos! O login ou a senha estão incorretos!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Hand);
            }
        }

        private void txtCpfUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            int cursorPosition = txtCpfUsuario.SelectionStart;


            if (cursorPosition == 3 || cursorPosition == 7)
            {
                txtCpfUsuario.Text = txtCpfUsuario.Text.Insert(cursorPosition, ".");
                txtCpfUsuario.SelectionStart = txtCpfUsuario.Text.Length;
                txtCpfUsuario.SelectionLength = 0;
            }
            if (cursorPosition == 11)
            {   
                txtCpfUsuario.Text = txtCpfUsuario.Text.Insert(cursorPosition, "-");
                txtCpfUsuario.SelectionStart = txtCpfUsuario.Text.Length;
                txtCpfUsuario.SelectionLength = 0;
            }
        }

        private void txtCpfUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }
    }
}
