   M S B A M L   `   `   `  ����K  GEbedrendeles_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Ebedrendeles_WPF.UserControlsEbedrendeles_WPF.UserControls  5      /    )Ebedrendeles_WPF.UserControls.ucStatistic   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Ebedrendeles_WPF.UserControls     5      .��5	      � .+�5
   
   �� .��5      �� $��15q�6   .+�5      �� $��Statisztika��6   $��Center=�6.   $��24(�6K   $y�Visible=�6Y   �� 5        �� Orientation$  
Horizontal=�6   $��Center=�66   .+�5      �� $��Center=�6#   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgFoodStat��5   #      AutoGenerateColumns .     SelectionMode$ Single=�6t      SelectionUnit$ FullRow=�6�   $��Center=�6�   $	��Top=�6�   $��10q�6�   $y�Visible=�6     CanUserAddRows .  ��67   �� *
enEtelek+ �� SelectedItem 6�   �� *SelectedAlacStat+ �� Mode$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "   -   5        etelekID��,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��5   G   
   
IsReadOnly
 .    
Visibility$ 	Collapsed=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6e   �� *
etelekId+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5   "   $
	 Kép��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6F   
 .    CellTemplate 5   &   �� 5   *   .R�5   .   �� $��70��6K   $��70��6V   ��64   �� *kep+6V   5   +   5   #     5   "   $	 Megnevezés��65   $	 200 6I   
 .  6g   �� *nev+  5   "   $	 
Kategória��65   $	 100 6H   
 .  6f   �� *	kategoria+  5   "   $	 Ár (Ft)��65   $ 50 6F   
 .  6c   �� *ar+5      5      5      5       5!      5"      5#      