   M S B A M L   `   `   `  ����K  GEbedrendeles_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Ebedrendeles_WPF.UserControlsEbedrendeles_WPF.UserControls  5      .    (Ebedrendeles_WPF.UserControls.ucMenuFood   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Ebedrendeles_WPF.UserControls     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��Center=�6<   .+�5      �� $��Menük összeállítása��6   $��Center=�62   $��24(�6O   $y�Visible=�6]   �� 5      $ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Dátum:��6   �� 5      -   5         ��Name$ tbMenuDatum��5      $	��100��63   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Leves:��6   �� 5      -   5        $ tbMenuLeves��5      $	��100��63   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��
Főétel1:��6   �� 5      -   5        $ 
tbMenuElso��5      $	��100��62   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��
Főétel2:��6   �� 5      -   5        $ tbMenuMasodik��5      $	��100��65   5       �� 5!      $ 
Horizontal=�6   .+�5"      �� $��Vegetáriánus:��6   �� 5#      -   5        $ tbMenuHarmadik��5#      $	��100��66   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��	Desszert:��6   �� 5'      -   5        $ tbMenuDesszert��5'      $	��100��66   5(      �� 5)      -   5         ��Name$ btMenuFeltolt��5)   7   $��Feltölt��6   $��50��6+   6N   5*      5+      �� 5,   
   $ Vertical=�6   $��1��6-   .+�5-      �� $��Ételek hozzáadása��6   $��Center=�60   $��24(�6M   $y�Visible=�6[   �� 5.      $ 
Horizontal=�6   $	��Top=�62   $��Center=�6J   .+�5/      �� $��0 0 10 0q�6   $ Vertical=�6/   $
��Left=�6F   .+�50      �� $	��200��6   $
��Left=�6(   .��6C   Étel megnevezés:6U   �� 51      -   5        $ tbNev��51      $	��150��6-   $
��Left=�69    � ToolTip$&  Írja be az étel megnevezését��6T   �� 52      $	��200��6   $
��Left=�6(   .��6C   Ár:6H   �� 53      $ 
Horizontal=�6!   $��18��6:   .+�54      �� -	   5        $
 tbAr��54   "   $��50��60   $
��Left=�6;    �� TextAlignment$ Right=�6V   $( "Írja be az étel árát forintban��6l   �� 55      $��Ft��6    $��10,0,0,0q�6-   56      �� 57      $	��200��6   $
��Left=�6(   .��6C   Kategória:6O   �� 58      -
   5         ��Name$ cbKategoria��58      $	��120��64   $
��Left=�6@   $ Válasszon kategóriát��6[   .@�59      �� .��6'   leves6.   �� 5:      .��6'   
főétel6/   �� 5;      .��6'   vega6-   �� 5<      .��6'   
desszert61   5=      �� 5>      $��Kép tallózása:��6   �� 5?      -   5        $��Tallóz��5?      $
��Left=�6.   $��40��6I   6T   �� 5@      -   5        $��Feltölt��5@      $��60��6/   $��18(�6:   6H   5A      5B      5C      5D      5E      