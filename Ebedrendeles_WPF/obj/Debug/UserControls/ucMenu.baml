   M S B A M L   `   `   `  ����K  GEbedrendeles_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Ebedrendeles_WPF.UserControlsEbedrendeles_WPF.UserControls  5      *    $Ebedrendeles_WPF.UserControls.ucMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Ebedrendeles_WPF.UserControls     5      .��5	      �� .��5
      � .+�5   
   ��   �� Orientation$  Vertical=�6   .+�5      �� $��Menük��6   $��Center=�6$   $��24(�6A   $y�Visible=�6O   �� 5      $  
Horizontal=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgMenus��5         AutoGenerateColumns .     SelectionMode$ Single=�6j      SelectionUnit$ FullRow=�6�   $��Center=�6�   $	��Top=�6�   $��10q�6�   $y�Visible=�6     CanUserAddRows .  ��6,   �� *	enNetelek+ �� SelectedItem 6�   �� *SelectedMenu+ �� Mode$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
menuId��,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��5   =   
   
IsReadOnly
 .    
Visibility$ 	Collapsed=�6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6r   �� *napietelekID+  5      $	 Dátum��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 6<   
 .  6Y   �� *datum+  5      $	 Leves��61   $	 100 6@   
 .  6^   �� *leves+  5      $	 	Főétel1��61   $	 100 6B   
 .  6`   �� *	foetel1+  5      $	 	Főétel2��61   $	 100 6B   
 .  6`   �� *	foetel2+  5      $
	 Vega��61   $	 100 6?   
 .  6]   �� *
foetelvega+  5      $	 Desszert��61   $	 100 6C   
 .  6a   �� *
desszert+5      �� 5      -   5         ��Name$ spSave��5      $  Vertical=�6.   $y�	Collapsed=�6E   .+�5      	� -   5         	�Name$ rbFirst��5   "   $��0��63   	� 5      -   5        $ rbSecond��5   "   $��0��64   	� 5      -   5        $ rbThird��5   "   $��0��63   �� 5       -   5         ��Name$ btSave��5       $��Kosárba��6-   $��50��6?   6J   5!      5"      5$      5&      5'      5(      