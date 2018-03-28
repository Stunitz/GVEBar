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
    /// Interaction logic for frmCadastrarProdutos.xaml
    /// </summary>
    public partial class frmCadastrarProdutos : Window
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private bool virgula = false;
        public frmCadastrarProdutos()
        {
            InitializeComponent();
        }

        private void btnCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.Rate = 2;
            if (ProdutoDAO.BuscarProdutoPorCodigoBarras(txtCodBarras.Text) != null)
            {
                synthesizer.SpeakAsync("Este Código de Barras já foi cadastrado!");
                MessageBox.Show("Este Código de Barras já foi cadastrado!",
                    "GVEBar",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                txtCodBarras.Text = string.Empty;
            }
            else if (txtCodBarras.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (txtNome.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (dteValidade.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (txtValorCompra.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (txtValorVenda.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (txtQuantidade.Text.Equals(""))
            {
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                Produto produto = new Produto
                {
                    CodigoDeBarras = txtCodBarras.Text,
                    NomeProduto = txtNome.Text,
                    ValorDeCompra = Convert.ToDouble(txtValorCompra.Text),
                    ValorDeVenda = Convert.ToDouble(txtValorVenda.Text),
                    Quantidade = Convert.ToInt32(txtQuantidade.Text),
                    Validade = Convert.ToDateTime(dteValidade.Text)
                };
                if (ProdutoDAO.CadastarProdutos(produto))
                {
                    synthesizer.SpeakAsync("Produto cadastrado com sucesso!");
                    MessageBox.Show("Produto cadastrado com sucesso!",
                                    "GVEBar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    LimparProduto();
                }
                else
                {
                    synthesizer.SpeakAsync("Produto não cadastrado!");
                    MessageBox.Show("Produto não cadastrado!",
                        "GVEBar",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    LimparProduto();
                }
            }
        }

        private void txtCodBarras_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }

        private void txtNome_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasLetras(e.Text);
        }

        private void txtValorCompra_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumeros(e.Text);
            if (txtValorCompra.SelectionStart == 1 && txtValorCompra.Text.Equals("0"))
            {
                txtValorCompra.Text = txtValorCompra.Text.Insert(txtValorCompra.SelectionStart, ",");
                txtValorCompra.SelectionStart = txtValorCompra.Text.Length;
                txtValorCompra.SelectionLength = 0;
                virgula = true;
            }
            if (virgula == false) // Controle para apenas permetir que o usúario coloque a virgula corretamente
            {
                if (txtValorCompra.Text.Equals(""))
                    e.Handled = Validar.ApenasNumeros(e.Text);
                else
                {
                    e.Handled = Validar.ApenasNumerosVirgula(e.Text);
                    virgula = true;
                }
            }
            else if (!txtValorCompra.Text.Contains(","))
            {
                virgula = false;
            }
        }

        private void txtValorVenda_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumeros(e.Text);
            if (txtValorVenda.SelectionStart == 1 && txtValorVenda.Text.Equals("0"))
            {
                txtValorVenda.Text = txtValorVenda.Text.Insert(txtValorVenda.SelectionStart, ",");
                txtValorVenda.SelectionStart = txtValorVenda.Text.Length;
                txtValorVenda.SelectionLength = 0;
                virgula = true;
            }
            if (virgula == false)
            {
                if (txtValorVenda.Text.Equals(""))
                    e.Handled = Validar.ApenasNumeros(e.Text);
                else
                {
                    e.Handled = Validar.ApenasNumerosVirgula(e.Text);
                    virgula = true;
                }
            }
            else if (!txtValorVenda.Text.Contains(","))
            {
                virgula = false;
            }
        }

        private void txtQuantidade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }

        private void LimparProduto()
        {
            txtCodBarras.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtValorCompra.Text = String.Empty;
            txtValorVenda.Text = String.Empty;
            txtQuantidade.Text = String.Empty;
        }
    }
}