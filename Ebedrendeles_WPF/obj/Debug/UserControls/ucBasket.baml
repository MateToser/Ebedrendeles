   M S B A M L   `   `   `  ����K  GEbedrendeles_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Ebedrendeles_WPF.UserControlsEbedrendeles_WPF.UserControls  5      ,    &Ebedrendeles_WPF.UserControls.ucBasket   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Ebedrendeles_WPF.UserControls     5      .��5	      � .+�5
   
   �� $��	0,0,0,-39q�6   .��5      ��   �� Orientation$  Vertical=�6   .+�5      �� $��Alacarte��6   $��Center=�6+   $��24(�6H   $y�Visible=�6V   �� 5      $  
Horizontal=�6   $��Center=�66   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgAlac��5         AutoGenerateColumns .     SelectionMode$ Single=�6o      SelectionUnit$ FullRow=�6�   $��Center=�6�   $	��Top=�6�   $��10q�6�   $y�Visible=�6     CanUserAddRows .  ��6/   �� *enEtelekSet+ �� SelectedItem 6�   ��  �� Path$ SelectedFood� �� Mode$ OneWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        etelekID��,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��5   C      
IsReadOnly .    
Visibility$ 	Collapsed=�6~   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *
etelekId+6~   4  .System.Windows.Controls.DataGridTemplateColumn  5      $

 Kép��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6B    .    CellTemplate 5   "   �� 5   &   .R�5   *   �� $��70��6G   $��70��6R   ��60   �� *kep+6R   5   '   5        5      $
 Megnevezés��61   $	 200 6E    .  6c   �� *nev+  5      $
 
Kategória��61   $	 100 6D    .  6b   �� *	kategoria+  5      $
 Ár (Ft)��61   $ 50 6B    .  6_   �� *ar+5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpDate��5   !   $��Center=�61   $
��10,0q�6L   $y�Hidden=�6Z   �� 5      -   5         ��Name$ 
btSaveFood��5      $��Mentés��61   $��Right=�6B   $
��5,10q�6^   $��20��6l   $y�Hidden=�6�   �� 5      -   5        $ btDeleteFood��5      $��Törlés��63   $��60��6D   $
��5,10q�6O   $��20��6]   $y�Hidden=�6i   6}   5       �� 5!      $��Menük��6   $��Center=�6(   $��24(�6E   $y�Visible=�6S   �� 5"      $  
Horizontal=�6   .+�5#      �� .��5$        -   5        $ dgMenus��5$   #    .  $ Single=�6u   $ FullRow=�6�   $��Center=�6�   $	��Top=�6�   $��10q�6�   $y�Visible=�6   .  ��64   �� *enNetelekSet+ 6�   �� *SelectedMenu+$ OneWay=�	 5%        5&   "   -   5        
menuId��$
 Id��5&   E    . $ 	Collapsed=�6c    6z   �� *napietelekID+  5'   "   $
 Dátum��65   $ 75 6D    .  6a   �� *datum+  5(   "   $
 Leves��65   $	 100 6D    .  6b   �� *leves+  5)   "   $
 	Főétel1��65   $	 100 6F    .  6d   �� *	foetel1+  5*   "   $
 	Főétel2��65   $	 100 6F    .  6d   �� *	foetel2+  5+   "   $

 Vega��65   $	 100 6C    .  6a   �� *
foetelvega+  5,   "   $
 Desszert��65   $	 100 6G    .  6e   �� *
desszert+5/      50      �� 51      -   5         ��Name$ spSave��51   !   $  Vertical=�62   $y�	Collapsed=�6I   .+�52      	� -	   5         	�Name$ rbFirst��52   &   $��0��67   	� 53      -
   5        $ rbSecond��53   &   $��0��68   	� 54      -   5        $ rbThird��54   &   $��0��67   �� 55      -   5        $ 
btSaveMenu��55   !   $��Mentés��65   $��50��6F   6Q   �� 56      -   5        $ btDeleteMenu��56   !   $��Törlés��67   $��50��6H   6S   57      58      �� 59      -   5         ��Name$ vegosszegTb��59      $�� ��61   $��Center=�69   $��5q�6V   $��13(�6a   �� 5:      -   5        $ btOrder��5:      $��Megrendelem��6*   $��75��6@   6K   5;      5<      5=      5>      