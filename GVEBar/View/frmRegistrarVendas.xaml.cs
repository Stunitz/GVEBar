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
    /// Interaction logic for frmRegistrarVendas.xaml
    /// </summary>
    public partial class frmRegistrarVendas : Window
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private List<dynamic> itensVenda = new List<dynamic>();

        double totalVenda = 0;
        int quantTotal = 0;
        public frmRegistrarVendas()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboProdutos.ItemsSource = ProdutoDAO.RetornarProdutos();
            cboProdutos.DisplayMemberPath = "NomeProduto";
            cboProdutos.SelectedValuePath = "CodigoDeBarras";
        }

        private void btnAdicionarProdutos_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.Rate = 2;
            bool cpfVazio = false;
            if (txtCpfCliente.Text.Length == 0)
            {
                cpfVazio = true;
            }
            else
            {
                cpfVazio = false;
            }
            if (!Validar.Cpf(txtCpfCliente.Text) && cpfVazio == false)
            {
                synthesizer.SpeakAsync("CPF inválido! Digite um CPF que exista!");
                MessageBox.Show("CPF inválido! Digite um CPF que exista!",
                    "GVEBar",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                string codBarras = (string)cboProdutos.SelectedValue;
                Produto produto = ProdutoDAO.BuscarProdutoPorCodigoBarras(codBarras);
                if (codBarras != null)
                {
                    if (produto.Quantidade == 0)
                    {

                        synthesizer.SpeakAsync("O estoque de " + produto.NomeProduto + " está vazio!");
                        MessageBox.Show("O estoque de " + produto.NomeProduto + " está vazio!",
                               "GVEBar",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
                    }
                    else
                    {
                        if (!txtQuantidade.Text.Equals(""))
                        {

                            if (Convert.ToInt32(txtQuantidade.Text) > produto.Quantidade)
                            {
                                synthesizer.SpeakAsync("Não contêm produtos suficientes no estoque!");
                                MessageBox.Show("Não contêm produtos suficientes no estoque!",
                              "GVEBar",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
                            }
                            else
                            {
                                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                                double subTotal = quantidade * produto.ValorDeVenda;
                                totalVenda += subTotal;
                                quantTotal += quantidade;

                                dynamic itemVenda = new
                                {
                                    Codigo = produto.CodigoDeBarras,
                                    Produto = produto.NomeProduto,
                                    Quantidade = txtQuantidade.Text,
                                    Preco = produto.ValorDeVenda.ToString("C2"),
                                    SubTotal = subTotal.ToString("C2"),
                                    Validade = produto.Validade
                                };


                                itensVenda.Add(itemVenda);

                                dtgVenda.ItemsSource = itensVenda;
                                dtgVenda.Items.Refresh();


                                txtQuantidade.Text = String.Empty;
                            }
                        }
                        else
                        {
                            synthesizer.SpeakAsync("O campo quantidade não pode estar vazio!");
                            MessageBox.Show("O campo quantidade não pode estar vazio!",
                                    "GVEBar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                        }

                        txtValorTotal.Text = Convert.ToString(totalVenda);
                    }
                }
                else
                {
                    synthesizer.SpeakAsync("Selecione um produto na lista antes!");
                    MessageBox.Show("Selecione um produto na lista antes!",
                                    "GVEBar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        private void btnRegistarVendas_Click(object sender, RoutedEventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            synthesizer.Rate = 2;

            if (dtgVenda.ItemsSource == null)
            {
                synthesizer.SpeakAsync("Adicione um produto antes!");
                MessageBox.Show("Adicione um produto antes!",
                        "GVEBar",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
            else
            {
                Venda venda = new Venda
                {
                    CpfCliente = txtCpfCliente.Text,
                    DataVenda = Convert.ToDateTime(thisDay.ToString("d")),
                    QuantProdVendido = quantTotal,
                    ValorVenda = totalVenda
                };

                foreach (dynamic itemsAdicionados in itensVenda)
                {
                    Produto produto = ProdutoDAO.BuscarProdutoPorCodigoBarras(itemsAdicionados.Codigo);
                    produto.Quantidade -= Convert.ToInt32(itemsAdicionados.Quantidade);
                    ProdutoDAO.AlterarProduto(produto);
                }


                if (VendaDAO.CadastrarVendas(venda))
                {
                    synthesizer.SpeakAsync("Venda registrada com sucesso!");
                    MessageBox.Show("Venda registrada com sucesso!",
                                    "GVEBar",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    LimparVendas();
                }
                else
                {
                    synthesizer.SpeakAsync("Venda não registrada!");
                    MessageBox.Show("Venda não registrada!",
                        "GVEBar",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    LimparVendas();
                }
            }



        }

        private void LimparVendas()
        {
            txtCpfCliente.Text = String.Empty;
            txtQuantidade.Text = String.Empty;
            txtValorTotal.Text = String.Empty;
            cboProdutos.Text = String.Empty;
            itensVenda.Clear();
            dtgVenda.ItemsSource = itensVenda;
            dtgVenda.Items.Refresh();
        }

        private void txtQuantidade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }



        private void cboProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string codBarras = (string)cboProdutos.SelectedValue;
            Produto produto = ProdutoDAO.BuscarProdutoPorCodigoBarras(codBarras);
            if (codBarras != null)
                lblEstoqueValor.Content = produto.Quantidade;
            else
                lblEstoqueValor.Content = null;
        }

        private void txtCpfCliente_KeyDown(object sender, KeyEventArgs e)
        {
            int cursorPosition = txtCpfCliente.SelectionStart;


            if (cursorPosition == 3 || cursorPosition == 7)
            {
                txtCpfCliente.Text = txtCpfCliente.Text.Insert(cursorPosition, ".");
                txtCpfCliente.SelectionStart = txtCpfCliente.Text.Length;
                txtCpfCliente.SelectionLength = 0;
            }
            if (cursorPosition == 11)
            {
                txtCpfCliente.Text = txtCpfCliente.Text.Insert(cursorPosition, "-");
                txtCpfCliente.SelectionStart = txtCpfCliente.Text.Length;
                txtCpfCliente.SelectionLength = 0;
            }
        }
        private void txtCpfCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Validar.ApenasNumerosInteiros(e.Text);
        }
    }
}