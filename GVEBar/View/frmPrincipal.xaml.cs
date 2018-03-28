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
using GVEBar.Model;
using GVEBar.DAL;
using System.Speech.Synthesis;

namespace GVEBar.View
{
    /// <summary>
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        bool atualizar = false;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarProdutos frm = new frmCadastrarProdutos();
            frm.ShowDialog();
        }

        private void menuCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarFuncionario frm = new frmCadastrarFuncionario();
            frm.ShowDialog();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void menuEfetuarVendas_Click(object sender, RoutedEventArgs e)
        {
            frmRegistrarVendas frm = new frmRegistrarVendas();
            frm.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            synthesizer.Rate = 2;
            List<dynamic> itensEstoque = new List<dynamic>();
            List<Produto> produtos = ProdutoDAO.RetornarProdutos();
            foreach(Produto produtoAdicionado in produtos)
            {
                if(produtoAdicionado.Quantidade < 50)
                {
                    synthesizer.SpeakAsync(produtoAdicionado.NomeProduto + " está em falta no estoque!");
                    MessageBox.Show(produtoAdicionado.NomeProduto + " está em falta no estoque!");
                }
                

                dynamic itemEstoque = new
                {
                    Codigo = produtoAdicionado.CodigoDeBarras,
                    Produto = produtoAdicionado.NomeProduto,
                    Compra = produtoAdicionado.ValorDeCompra.ToString("C2"),
                    Venda = produtoAdicionado.ValorDeVenda.ToString("C2"),
                    Quantidade = produtoAdicionado.Quantidade,
                    Validade = produtoAdicionado.Validade
                };


                itensEstoque.Add(itemEstoque);

                dtgEstoque.ItemsSource = itensEstoque;
                dtgEstoque.Items.Refresh();
            }

        }

        private void menuControleEstoque_Click(object sender, RoutedEventArgs e)
        {
            frmControleEstoque frm = new frmControleEstoque();
            frm.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
            atualizar = true;
            menuSair_Click(e, e);
        }

        private void menuDeslogar_Click(object sender, RoutedEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            synthesizer.Rate = 2;
            if (atualizar == false)
            {
                synthesizer.SpeakAsync("Deseja realmente sair?");
                MessageBoxResult resultado = MessageBox.Show("Deseja realmente sair?", "GVEBar",
                   MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resultado == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            atualizar = false;
        }
    }
}
