   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.Regalos   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  Regalos??5	   	   $	??520??6   $	??361??6&   
??????? ? 
ResizeMode$ NoResize=?6J    ? Icon$ Pictures/logo_icon1.png??6`    ? WindowStartupLocation$ Manual=?6   .??5
      ? .+?5   
   ?? $"??Lista de Regalos disponibles??6   $
??Left=?67   $??	10,10,0,0q?6R   $	??Top=?6e   $	??329??6}   $??24(?6?   $
??Bold"?6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgRegalos??5         
IsReadOnly .    AutoGenerateColumns .  $??23,142,22,124q?6U   $??2q?6?   $
??Bold"?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 30 6O   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   ?? *	ID_REGALO+6O     5      $ 	Contenido??6%   $		 120 6V   
 68   ?? *	CONTENIDO+6V     5      $ Valor??6%   $	 80 6N   
 64   ?? *VALOR+6N    ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType ?? Property ?? Value??%?   '        ?? 5      "  6   .?5      ??  ? ?? ?	#FFE4EEF763   ?? 5       ? ??$ 0,0,1,2q?68   ?? 5       ? ?? ?	#FF1487EE64   ?? 5       ? ??$ Medium"?63   5      5      5      ?? 5   
   -   5         ??Name$ btnCrearRegalo??5      $??Crear??6)   $
??Left=?69   $??181,403,0,0q?6T   $	??Top=?6i   $??68??6?   6?   ?? 5   
   -   5        $ btnEditarRegalo??5      $??Editar??6*   $
??Left=?6;   $??106,403,0,0q?6V   $	??Top=?6k   $??68??6?   ?? 5   
   -   5        $ btnEliminarRegalo??5      $??Eliminar??6,   $
??Left=?6?   $??
23,403,0,0q?6Z   $	??Top=?6n   $??68??6?   6?   ?? 5    
   -   5        $ btnActualizarRegalo??5       $??
Actualizar??6.   $
??Left=?6C   $??267,403,0,0q?6^   $	??Top=?6s   6?   5"      5#      