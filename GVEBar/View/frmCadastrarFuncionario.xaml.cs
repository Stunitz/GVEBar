using GVEBar.DAL;
using GVEBar.Util;
using GVEBar.Model;
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
using System.Text.RegularExpressions;
using System.Speech.Synthesis;

namespace GVEBar.View
{
    
    /// <summary>
    /// Interaction logic for frmCadastrarFuncionario.xaml
    /// </summary>
    public partial class frmCadastrarFuncionario : Window
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private bool virgula = false;

        public frmCadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void btnCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.Rate = 2;

            // Verifica se o CPF é valido
            if (!Validar.Cpf(txtCpfFuncionario.Text))
            {
                synthesizer.SpeakAsync("CPF inválido! Digite um CPF que exista!");
                MessageBox.Show("CPF inválido! Digite um CPF que exista!",
                    "GVEBar",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            // Verifica se o CPF já foi cadastrado
            else if (FuncionarioDAO.BuscarFuncionarioPorCPF(txtCpfFuncionario.Text) != null) // Verifica se o CPF já existe
            {
                synthesizer.SpeakAsync("Este CPF já foi cadastrado!");
                MessageBox.Show("Este CPF já foi cadastrado!",
                    "GVEBar",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                txtCpfFuncionario.Text = string.Empty;
            }
            else if (txtNomeFuncionario.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (txtSalario.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (pwbSenha.Password.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if(pwbSenha.Password.Length <= 4)
            {
                synthesizer.SpeakAsync("Dados insuficientes! A senha deve ter mais de 4 digitos!");
                MessageBox.Show("Dados insuficientes! A senha deve ter mais de 4 digitos!",
                                               "GVEBar",
                                               MessageBoxButton.OK,
                                               MessageBoxImage.Information);
            }
            else
            {
                Funcionario funcionario = new Funcionario
                {
                    CpfFuncionario = txtCpfFuncionario.Text,
                    NomeFuncionario = txtNomeFuncionario.Text,
                    CargoFuncionario = cboCargo.Text,
                    Salario = Convert.ToDouble(txtSalario.Text)
                };
                Usuario usuario = new Usuario
                {
                    CpfUsuario = txtCpfFuncionario.Text,
                    Senha = pwbSenha.Password,
                    CargoUsuario = cboCargo.Text  
                };
                if (UsuarioDAO.CadastrarUsuario(usuario))
                {
                    if (FuncionarioDAO.CadastrarFuncionario(funcionario))
                    {
                        synthesizer.SpeakAsync("Funcionário cadastrado com sucesso!");
                        MessageBox.Show("Funcionário cadastrado com sucesso!",
                                        "GVEBar",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);
                        LimparFuncionario();
                    }
                    else
                    {
                        synthesizer.SpeakAsync("Funcionário não cadastrado!");
                        MessageBox.Show("Funcionário não cadastrado!",
                            "GVEBar",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        LimparFuncionario();
                    }
                }
                else
                {
                    synthesizer.SpeakAsync("Funcionário não cadastrado!");
                    MessageBox.Show("Funcionário não cadastrado!",
                        "GVEBar",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    LimparFuncionario();
                }

            }
        }

        private void txtCpfFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            int cursorPosition = txtCpfFuncionario.SelectionStart;


            if (cursorPosition == 3 || cursorPosition == 7)
            {
                txtCpfFuncionario.Text = txtCpfFuncionario.Text.Insert(cursorPosition, ".");
                txtCpfFuncionario.SelectionStart = txtCpfFuncionario.Text.Length;
                txtCpfFuncionario.SelectionLength = 0;
            }
            if (cursorPosition == 11)
            {
                txtCpfFuncionario.Text = txtCpfFuncionario.Text.Insert(cursorPosition, "-");
                txtCpfFuncionario.SelectionStart = txtCpfFuncionario.Text.Length;
                txtCpfFuncionario.SelectionLength = 0;
            }
        }

        private void txtCpfFuncionario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }

        private void txtNomeFuncionario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasLetras(e.Text);
        }

        private void txtCargo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasLetras(e.Text);
        }

        private void txtSalario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumeros(e.Text);
            if(txtSalario.SelectionStart == 1 && txtSalario.Text.Equals("0"))
            {
                txtSalario.Text = txtSalario.Text.Insert(txtSalario.SelectionStart, ",");
                txtSalario.SelectionStart = txtSalario.Text.Length;
                txtSalario.SelectionLength = 0;
                virgula = true;
            }
            if (virgula == false) // Controle para apenas permetir que o usúario coloque a virgula corretamente
            {
                if (txtSalario.Text.Equals(""))
                    e.Handled = Validar.ApenasNumeros(e.Text);
                else
                {
                    e.Handled = Validar.ApenasNumerosVirgula(e.Text);
                    virgula = true;
                }
            }
            else if (!txtSalario.Text.Contains(","))
            {
                virgula = false;
            }
        }

        private void LimparFuncionario()
        {
            pwbSenha.Password = string.Empty;
            txtCpfFuncionario.Text = String.Empty;
            txtNomeFuncionario.Text = String.Empty;
            txtSalario.Text = String.Empty;
        }

    }
}
