   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.Categoria   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  	Categoria??5	   	   $	??460??6   $	??500??6(   
??????? ? Icon$ Pictures/logo_icon1.png??6K    ? WindowStartupLocation$ Manual=?6j    ? Left$ 0??6?   
 ? Top$ 0??6?   .??5
      ? .+?5   
   ?? $??Gestionar Categorías??6   $
??Left=?6/   $??	10,10,0,0q?6J   $	??Top=?6]   $	??311??6u   $??24(?6?   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ testName_lbl??5      $??Nombre Categoría:??6&   $
??Left=?6B   $??	19,70,0,0q?6]   $	??Top=?6p   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5   
   -   5        $ testName_lbl_Copy??5      $??Id Categoría:??6+   $
??Left=?6C   $??
19,107,0,0q?6^   $	??Top=?6r   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ tbCategoria??5      $
??Left=?6'   $??
171,73,0,0q?6B    ?? TextWrapping$
 Wrap=?6V   $	??Top=?6j   $	??118??6?   $??20??6?   $
??Bold"?6?   {?.  6?   ?? 5   
   -   5         ??Name$ BtnEliminar??5      $??Eliminar??6&   $
??Left=?69   $??282,370,0,0q?6T   $	??Top=?6i   $??29??6?   $??78??6?   ???	#FFFCC5C56?   ?? 5   
   -   5        $ BtnCrear??5      $??Crear??6#   $
??Left=?63   $??
91,370,0,0q?6N   $	??Top=?6b   $??29??6z   $??78??6?   ???	#FFD0FCCE6?   ?? 5   
   -   5        $ 	BtnEditar??5      $??Editar??6$   $
??Left=?65   $??187,370,0,0q?6P   $	??Top=?6e   $??29??6}   $??78??6?   ???	#FFF6F9C36?   ?? 5   
   -   5        $ BtnActualizar??5      $??
Actualizar??6(   $
??Left=?6=   $??376,370,0,0q?6X   $	??Top=?6m   $??29??6?   $??78??6?   ???	#FFBCE1E56?   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dgCategoria??5      
   
IsReadOnly
 .    AutoGenerateColumns .  $??19,146,46,86q?6W   $
??Bold"?6?    ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType ?? Property ?? Value??%?   '        ?? 5      "  6   .?5      ??  ? ?? ?	#FFE4EEF763   ?? 5       ? ??$ 1,1,1,1q?68   ?? 5       ? ?? ?	#FF1487EE64   ?? 5       ? ??$ Medium"?63   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	  Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ?? *ID_CATEGORIA+6S     5      $  Categoría??6%   $	 140 6W    69   ?? *	CATEGORIA+6W     5       $  Descripción??6%   $ * 6[    6;   ?? *DESCRIPCION+6[   5#      ?? 5$   
   -	   5        $ tbIdCategoria??5$      $
??Left=?6)   $??171,109,0,0q?6D   $
 Wrap=?6Y   $	??Top=?6m   $	??118??6?   $??20??6?   $
??Bold"?6?   {?.  6?   5&      5'      