   M S B A M L   `   `   `  ����N  JSecurityTableParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SecurityTableParserSecurityTableParser  5   	   $    SecurityTableParser.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SecurityTableParser     5   	     � Title$  Security-Table-Parser��5   	   $	��550��6'   $	��800��64    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 20��6!   #��z��5   !   ._�5      �� #��z��6/   #��z��5   /   5      5      5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ btnFirst��5      $��1��6#   $
��Left=�6/   $��
60,459,0,0q�6J   $	��Top=�6^   $��30��6v   $��55��6�   6�   �� 5   
   -   5        $ btnPrev��5      $��<��6"   $
��Left=�61   $��145,459,0,0q�6L   $	��Top=�6a   $��30��6y   $��55��6�    J� RenderTransformOrigin$ 0.727,3.501&�6�   �� 5   
   -   5        $ btnNext��5      $��>��6"   $
��Left=�61   $��625,459,0,0q�6L   $	��Top=�6a   $��30��6y   $��55��6�   6�   �� 5   
   -   5        $ btnLast��5      $�� ��6"   $
��Left=�6-   $��715,459,0,0q�6H   $	��Top=�6]   $��30��6u   $��55��6�   $ 6.364,0.501&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dataGrid��5      $��60,119,30,0q�6%   $	��320��6:   
   
IsReadOnly
 . $	��Top=�6Z      AutoGenerateColumns .     Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+   ClipboardContentBinding 6<   Z� 6_     5"      $ Наименование��6a    6%   �� *Name+ 6>   Z� 6a   5$      �� 5%   
   -   5        $ btnDownload��5%      $��Обновить��6&   $
��Left=�69   $��
120,74,0,0q�6T   $	��Top=�6h   $��30��6�   $��80��6�   6�   �� 5&   
   -   5        $ btnView��5&      $��Подробности��6"   $
��Left=�68   $��
330,74,0,0q�6S   $	��Top=�6g   $��30��6   $	��125��6�   $ 0.062,0.668&�6�   �� 5'   
   -   5        $ btnSave��5'      $��Сохранить��6"   $
��Left=�66   $��
625,74,0,0q�6Q   $	��Top=�6e   $��30��6}   $��80��6�   6�   �� 5(   
   -	   5         ��Name$ pageInfo��5(      $�� ��6"   $
��Left=�6-   $��520,459,0,0q�6H   $	��Top=�6]   $��85��6u   �� 5)   
   -
   5        $ label��5)      $�� ��6   $
��Left=�6*   $��
230,25,0,0q�6E   $	��Top=�6Y   $ -2.096,-9.051&�6q   $	��340��6�   $��44��6�   $��20(�6�   5+      5,      