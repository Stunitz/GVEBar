   M S B A M L   `   `   `  ����A  =GVEBar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GVEBar.ViewGVEBar.View  5   	   $    GVEBar.View.frmRegistrarVendas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GVEBar.View     5   	   -   5          � Title$  GVEBar - Registrar Vendas��5   	   $	��370��6+   $	��390��68   $	��370��6D   $	��390��6T   .��5	      �  � RowDefinitions 5
   
   �� 5      $��8* �6   �� 5      $��8* �6   �� 5      $��8* �6   �� 5      $��8* �6   �� 5      $	��50* �6   �� 5      $��8* �6   �� 5      $��8* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��45* �6   �� 5      $	��45* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ 
lblProduto��5      $��Produto��6$   $��0��5      $��1��6   $��Center=�5      $��Center=�5      �� 5   
   -   5        $ lblQuantidade��5      $��
Quantidade��6'   $��2��5      $��2��6   $��Center=�5       $��Center=�5!      �� 5"   
   -   5        $ lblCpfCliente��5"      $��CPF Cliente��6'   $��2��5#      $��1��6   $��Center=�5$      $��Center=�5%      �� 5&   
   -   5        $ 
lblEstoque��5&      $��Estoque��6$   $��0��5'      $��2��6   $��Center=�5(      $��Center=�5)      �� 5*   
   -   5        $ lblEstoqueValor��5*      $��Center=�6)   $��Center=�5+      $��2��64   $��1��6D   $	��5,0q�6Q   ���	#FF707070���	#FFDDDDDD$��1q�6�   �� 5-   
   -   5         ��Name$ cboProdutos��5-      $��1��6(   $��1��68   $��0��6E   $	��5,0q�6R   6_   �� 5/   
   -   5         ��Name$ txtQuantidade��5/      $��2��6)   $��3��69   $��2��6F   $	��5,0q�6�   �� 50   
   -	   5        $ txtCpfCliente��50      $��1��6)   $��3��69   $��3��6F    �� 	MaxLength$ 14��6�   $	��5,0q�6�   �� 51   
   -
   5        $ txtValorTotal��51      $��2��6)   $��5��69    �� 
IsReadOnly . $��0,0,5,5q�6X   ���	#FF688CAF$��1,0,1,1q�6�   �� 52   
   -   5        $ txtValorTotalTexto��52      $��Valor Total da Venda��6.   $��1��6J   $��5��6Z   $��5,0,0,5q�6g   $��Center=�6x   $��Center=�6�    . ���	#FF688CAF$��1,0,1,1q�6�   �� 53   
   -   5         ��Name$ btnAdicionarProdutos��53      $��Adicionar Produto��6/   $��2��6K   $��6��6[   $	��5,0q�6�   �� 54   
   -   5        $ btnRegistarVendas��54      $��Registrar Venda��6,   $��1��6F   $��6��6V   $	��5,0q�6�   &   System.Windows.Controls.DataGrid  55   
   -   5        	  Name$	 dtgVenda��55      $��1��6%   $��4��65   $��2��6C   $��5,5,5,0q�6W   
   AutoGenerateColumns
 .     
IsReadOnly . $��1,1,1,0q�6�      Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      -   5        
colProduto��,  &System.Windows.Controls.DataGridColumn   Header$ Produto��57   9      Width5  /System.Windows.Controls.DataGridLengthConverter$	 30* 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 58   %   �� *	Produto+  59      -   5        colPreco��$ Preço��59   7   $	 20* 6F    5:   %   �� *Preco+  5;      -   5        colQuantidade��$ 
Quantidade��5;   <   $	 30* 6P    5<   %   �� *
Quantidade+  5=      -   5        colSubTotal��$ SubTotal��5=   :   $	 20* 6L    5>   %   �� *
SubTotal+  5?      -   5        colValidade��$ Validade��5?   :   $	 20* 6L    5@   %   �� *
Validade+5C      5E      5F      