   M S B A M L   `   `   `  ����N  JSecurityTableParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SecurityTableParserSecurityTableParser  5   	   #    SecurityTableParser.LogWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SecurityTableParser     5   	     � Title$  Security-Table-Parser��5   	   $	��450��6'   $	��800��64    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 20��6!   #��z��5   !   ._�5      �� #��z��6/   #��z��5   /   5      5      5      5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $
��Left=�6%   $	��357��6@   $��	10,54,0,0q�6M   $	��Top=�6`   $	��773��6x      
IsReadOnly . 	   AutoGenerateColumns	 .  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+   ClipboardContentBinding 6<   Z� 6_     5      $ Наименование��6a    6%   �� *Name+ 6>   Z� 6a   5       �� 5!   
   -   5         ��Name$ btnView��5!      $��Подробности��6"   $
��Left=�68   $��	665,9,0,0q�6S   $	��Top=�6f   $	��110��6~   $��40��6�   �� 5"   
   -   5         ��Name$ label��5"      $�� ��6   $
��Left=�6*   $��	225,5,0,0q�6E   $	��Top=�6X    J� RenderTransformOrigin$ -2.096,-9.051&�6p   $	��340��6�   $��44��6�   $��20(�6�   5$      5%      