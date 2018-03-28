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
using System.Speech.Synthesis;

namespace GVEBar.View
{
    /// <summary>
    /// Interaction logic for frmControleEstoque.xaml
    /// </summary>
    public partial class frmControleEstoque : Window
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        string CodBarras;
        string excluirProd;

        public frmControleEstoque()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboEditarProdutos.ItemsSource = ProdutoDAO.RetornarProdutos();
            cboEditarProdutos.DisplayMemberPath = "NomeProduto";
            cboEditarProdutos.SelectedValuePath = "CodigoDeBarras";
        }
        private void cboEditarProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string codBarras = (string)cboEditarProdutos.SelectedValue;
            if (codBarras != null)
            {
                Produto produto = ProdutoDAO.BuscarProdutoPorCodigoBarras(codBarras);

                txtEditarCodBarras.Text = produto.CodigoDeBarras;
                txtEditarNomeProduto.Text = produto.NomeProduto;
                txtEditarValorCompra.Text = Convert.ToString(produto.ValorDeCompra);
                txtEditarValorVenda.Text = Convert.ToString(produto.ValorDeVenda);
                txtEditarQuantidade.Text = Convert.ToString(produto.Quantidade);
                dteEditarValidade.Text = Convert.ToString(produto.Validade);

                CodBarras = produto.CodigoDeBarras;
            }




        }
        private void txtEditarValorCompra_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }

        private void txtEditarValorVenda_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }

        private void txtEditarQuantidade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }


        private void btnEditarProduto_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorCodigoBarras(CodBarras);

            if (txtEditarNomeProduto.Text.Equals(""))
            {
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
            }
            else if (txtEditarValorCompra.Text.Equals(""))
            {
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
            }
            else if (txtEditarValorVenda.Text.Equals(""))
            {
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
            }
            else if (dteEditarValidade.Text.Equals(""))
            {
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");
            }
            else if (txtEditarQuantidade.Text.Equals(""))
            {
                MessageBox.Show("Dados insuficientes! Os campos não podem ficar vazios!",
                                "GVEBar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                synthesizer.SpeakAsync("Dados insuficientes! Os campos não podem ficar vazios!");

            }
            else
            {



                produto.NomeProduto = txtEditarNomeProduto.Text;
                produto.ValorDeCompra = Convert.ToDouble(txtEditarValorCompra.Text);
                produto.ValorDeVenda = Convert.ToDouble(txtEditarValorVenda.Text);
                produto.Quantidade = Convert.ToInt32(txtEditarQuantidade.Text);
                produto.Validade = Convert.ToDateTime(dteEditarValidade.Text);

                if (ProdutoDAO.AlterarProduto(produto))
                {
                    MessageBox.Show("Produto editado com sucesso!",
                                    "GVEBar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    synthesizer.SpeakAsync("Produto editado com sucesso!");
                    cboEditarProdutos.ItemsSource = ProdutoDAO.RetornarProdutos();
                    LimparProduto();



                }
                else
                {
                    MessageBox.Show("Produto não editado!",
                        "GVEBar",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    synthesizer.SpeakAsync("Produto não editado!");
                    LimparProduto();
                }



            }

        }
        private void btnExcluirProduto_Click(object sender, RoutedEventArgs e)
        {

            Produto produto = ProdutoDAO.BuscarProdutoPorCodigoBarras(CodBarras);
            excluirProd = produto.CodigoDeBarras;

            if (ProdutoDAO.RemoverProduto(produto))
            {
                MessageBox.Show("Produto excluido com sucesso!",
                                    "GVEBar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                synthesizer.SpeakAsync("Produto excluido com sucesso!");
                cboEditarProdutos.ItemsSource = ProdutoDAO.RetornarProdutos();
                LimparProduto();
            }

            else
            {
                MessageBox.Show("Produto não excluido!",
                        "GVEBar",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                synthesizer.SpeakAsync("Produto não excluido!");
            }

        }
        private void LimparProduto()
        {
            cboEditarProdutos.Text = String.Empty;
            txtEditarNomeProduto.Text = String.Empty;
            txtEditarCodBarras.Text = String.Empty;
            txtEditarValorCompra.Text = String.Empty;
            txtEditarValorVenda.Text = String.Empty;
            txtEditarQuantidade.Text = String.Empty;
            dteEditarValidade.Text = String.Empty;
        }

    }
}
