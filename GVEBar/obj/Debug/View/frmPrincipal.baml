   M S B A M L   `   `   `  ����A  =GVEBar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GVEBar.ViewGVEBar.View  5   	       GVEBar.View.frmPrincipal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GVEBar.View     5   	   -   5          � Title$  GVEBar��5   	   $	��500��6   $	��500��6%    � WindowStartupLocation$ CenterScreen=�6H   $	��500��6m   $	��500��6}   .��5	      � -   5         �Name$ grdForm��5	       � RowDefinitions 5
   
   �� 5      $	��43* �6   �� 5      $	��37* �6   �� 5      $
��389* �6   �� 5      $	��37* �6   .+�5   
   o� -   5         o�Name$
 menu��5      $
��Left=�6   $��40��68   $	��Top=�6D   ��6\   ��  �� ElementName$ grdForm�� �� Path$ ActualWidth�.@�5      m� $��_Vendas��6   $��40��6(   .@�5      m� -   5         m�Name$ menuEfetuarVendas��5      $��Registar Vendas��66   $
��Left=�6O   $	��170��6j   6v   5      m� 5      $��	_Produtos��6   $��40��6*   .@�5      m� -   5        $ menuCadastrarProduto��5      $��Cadastrar Produto��69   $
��Left=�6T   6p   m� 5      -   5        $ menuControleEstoque��5      $��Controle de Estoque��68   $
��Left=�6U   6p   5      m� 5      $��_Funcionário��6   $��40��6-   .@�5      m� -   5        $ menuCadastrarFuncionario��5      $��Cadastrar Funcionário��6=   $
��Left=�6\   $	��200��6w   6�   5      m� 5      $��	_Opções��6   $��40��6(   .@�5      m� -   5        $ menuDeslogar��5      $��Deslogar��61   $
��Left=�6C   $��139.2��6^   6l   m� 5      -	   5        $ menuSair��5      $
��Sair��6-   $
��Left=�6;   $��139.2��6V   6d   5       5!      �� 5"   
   -
   5         ��Name$ lblRelatorio��5"      $��Relatório do Estoque��6&   $��1��5#      $��2��6   $��Center=�5$      $��Center=�5%      $��20(�64   $
��Bold"�6B   &   System.Windows.Controls.DataGrid  5&   
   -   5        	  Name$	 
dtgEstoque��5&      $��1��6'   $��2��67   $��2��6E   $
��0,10q�6Y   
   AutoGenerateColumns
 .     
IsReadOnly . $��1,1,1,0q�6�      Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      -   5        colCodBarra��,  &System.Windows.Controls.DataGridColumn   Header$ Código de Barra��5(   :      Width5  /System.Windows.Controls.DataGridLengthConverter$	 22* 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5)   %   �� *Codigo+  5*      -   5        
colProduto��$ Produto��5*   9   $	 15* 6J    5+   %   �� *	Produto+  5,      -   5        colValorCompra��$ Valor de Compra��5,   =   $	 25* 6V    5-   %   �� *Compra+  5.      -   5        colValorVenda��$ Valor de Venda��5.   <   $	 25* 6T    5/   %   �� *Venda+  50      -   5        colQuantidade��$ 
Quantidade��50   <   $	 20* 6P    51   %   �� *
Quantidade+  52      -   5        colValidade��$ Validade��52   :   $	 20* 6L    53   %   �� *
Validade+56      �� 57   
   -   5         ��Name$ btnAtualizar��57      $��Atualizar Relatório��6'   $��Center=�6E   $��3��6b   $��Center=�6o   $	��150��6�   6�   59      5:      