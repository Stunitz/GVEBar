   M S B A M L   `   `   `  ����A  =GVEBar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GVEBar.ViewGVEBar.View  5   	   $    GVEBar.View.frmControleEstoque   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GVEBar.View     5   	   -   5          � Title$  Controle de  Estoque��5   	   $��329.211��6&   $��360.658��67   $	��315��6G   $	��350��6W   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��45* �6   �� 5      $	��45* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ 
lblProduto��5      $��Produto��6$   $��0��66   $��1��6C   $��Center=�6S   $��Center=�6u   �� 5   
   -   5        $ lblEditarCodBarras��5      $��Código de Barras��6,   $��1��6G   $��1��6T   $��Center=�6d   $��Center=�6�   �� 5   
   -   5        $ lblEditarNomeProduto��5      $
��Nome��6.   $��2��6=   $��1��6J   $��Center=�6Z   $��Center=�6|   �� 5   
   -   5        $ lblEditarValorCompra��5      $��Valor de Compra��6.   $��3��6H   $��1��6U   $��Center=�6e   $��Center=�6�   �� 5   
   -   5        $ lblEditarValorVenda��5      $��Valor de Venda��6-   $��4��6F   $��1��6S   $��Center=�6c   $��Center=�6�   �� 5    
   -   5        $ lblEditarQuantidade��5       $��
Quantidade��6-   $��5��6B   $��1��6O   $��Center=�6_   $��Center=�6�   �� 5!   
   -   5        $ lblEditarValidade��5!      $��Validade��6+   $��6��6>   $��1��6K   $��5q�6[   $��Center=�5"      $��Center=�62   $��4��6V   �� 5#   
   -	   5         ��Name$ cboEditarProdutos��5#      $��2��6.   $��0��6>   $��0��6K   $��5,5,5,5q�6Y   6j   �� 5$   
   -
   5         ��Name$ txtEditarCodBarras��5$      $��2��6.   $��1��6>   $��1��6K    �� 
IsReadOnly . $��5,5,5,5q�6k   ���	#FFEBEBEB6|   �� 5%   
   -   5        $ txtEditarNomeProduto��5%      $��2��60   $��2��6@   $��2��6M   $��5,5,5,5q�6[   �� 5&   
   -   5        $ txtEditarValorCompra��5&      $��2��60   $��3��6@   $��3��6M   $��5,5,5,5q�6�   �� 5'   
   -   5        $ txtEditarValorVenda��5'      $��2��6/   $��4��6?   $��4��6L   $��5,5,5,5q�6�   �� 5(   
   -   5        $ txtEditarQuantidade��5(      $��2��6/   $��5��6?   $��5��6L   $��5,5,5,5q�6�   �� 5)   
   -   5         ��Name$ btnEditarProduto��5)      $��Editar��6+   $��2��6<   $��7��6L   $��5,5,5,5q�6x   �� 5*   
   -   5        $ btnExcluirProduto��5*      $��Excluir��6,   $��1��6>   $��7��6N   $��5,5,5,5q�6{   (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ dteEditarValidade��5+      $��2��60   $��6��6@   $��5q�6M   $��5��6X   5,      5-      