   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.MantenciónDep   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  Ingresar Mantención??5	   	   $	??500??6%   $	??700??62   
??????? ? Icon$ Pictures/logo_icon1.png??5
       ? WindowStartupLocation$ Manual=?62    ? Left$ 0??5      
 ? Top$ 0??6   .??5      ? .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgMantencionTerminada??5         
IsReadOnly .    AutoGenerateColumns .  $??34,199,37,75q?6a   $
??Bold"?6?    ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 ?? 
TargetType
 ?? Property ?? Value??%?   '        ?? 5      "	  6   .?5      ?? 
 ? ?? ?	#FFE4EEF763   ?? 5      
 ? ??$ 1,1,1,1q?68   ?? 5      
 ? ?? ?	#FF1487EE64   ?? 5      
 ? ??$ Medium"?63   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	  Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ?? *ID_MANTENCION+6T     5      $  Fecha inicio??6%   $	 150 6]    6<   ?? *FECHA_INICIO+6]     5      $  Fecha término??6%   $	 150 6_    6=   ?? *FECHA_TERMINO+6_     5      $  Costo??6%   $ 60 6O    65   ?? *COSTO+6O     5      $  Descripción??6%   $ * 6[    6;   ?? *DESCRIPCION+6[   5       ?? 5"   
   -   5         ??Name$ rtBtnManAge??5"      $
??Left=?6)   $??29??6D   $??497,165,0,0q?6P   $	??Top=?6e   $	??162??6}   ???	#FFC9A000???	#FFC9A0006?     5$   
   -   5        $ dgMantencion??5$       .  .  $??34,199,37,75q?6X   $
??Bold"?6?    5%      ??%?   '        ?? 5&      "	  6   .?5'      ?? 
 ? ?? ?	#FFE4EEF763   ?? 5(      
 ? ??$ 1,1,1,1q?68   ?? 5)      
 ? ?? ?	#FF1487EE64   ?? 5*      
 ? ??$ Medium"?63   5+      5,       5.        5/      $	  Id??6%   $ 40 6T    62   ?? *ID_MANTENCION+6T     50      $  Fecha inicio??6%   $	 150 6]    6<   ?? *FECHA_INICIO+6]     51      $  Fecha término??6%   $	 150 6_    6=   ?? *FECHA_TERMINO+6_     52      $  Costo??6%   $ 60 6O    65   ?? *COSTO+6O     53      $  Descripción??6%   $ * 6[    6;   ?? *DESCRIPCION+6[   56      ?? 5:   
   -   5         ??Name$ btnCrear??5:      $??Crear??6#   $
??Left=?63   $??
34,410,0,0q?6N   $	??Top=?6b   $??64??6z   $??32??6?   ???	#FFD0FCCE6?   ?? 5;   
   -   5        $ btnEliminar??5;      $??Eliminar??6&   $
??Left=?69   $??198,410,0,0q?6T   $	??Top=?6i   $??66??6?   $??31??6?    J? RenderTransformOrigin$ 
0.45,0.664&?6?   ???	#FFFCC5C56?   ?? 5<   
   -   5        $ 	btnEditar??5<      $??Editar??6$   $
??Left=?65   $??115,410,0,0q?6P   $	??Top=?6e   $??65??6}   $??31??6?   ???	#FFF6F9C36?   ?? 5=   
   $??Id Departamento:??6   $
??Left=?6+   $??	34,71,0,0q?6F   $	??Top=?6Y   $	??178??6q   $??16(?6}   $
??Bold"?6?   ?? 5>   
   $??Ingresar Mantención??6   $
??Left=?6.   $??	10,10,0,0q?6I   $	??Top=?6\   $	??311??6t   $??24(?6?   $
??Bold"?6?   ?? 5?   
   $??Nombre Departamento:??6   $
??Left=?6/   $??
34,102,0,0q?6J   $	??Top=?6^   $	??192??6v   $??16(?6?   $
??Bold"?6?   ?? 5@   
   -   5         ??Name$ tbnombreDepartamento??5@      $
??Left=?60   $??226,106,0,0q?6K    ?? TextWrapping$
 Wrap=?6`   $	??Top=?6t   $	??188??6?   $
??Bold"?6?   ?? 5A   
   -   5        $ tbidDepartamento??5A      $
??Left=?6,   $??
226,73,0,0q?6G   $
 Wrap=?6[   $	??Top=?6o   $??69??6?   {?.  $
??Bold"?6?   ?? 5B   
   -	   5        $ btnActualizar??5B      $??
Actualizar??6(   $
??Left=?6=   $??282,410,0,0q?6X   $	??Top=?6m   $??74??6?   $??31??6?   ???	#FFBCE1E56?   ?? 5C   
   -
   5        $ rtBtnManTer??5C      $
??Left=?6)   $??29??6D   $??320,165,0,0q?6P   $	??Top=?6e   $	??165??6}   ???	#FFC9A000???	#FFC9A0006?   ?? 5D   
   -   5        $ BtnMantencionesAgendadas??5D      $??Mantenciones agendadas??63   $
??Left=?6T   $??499,167,0,0q?6o   $	??Top=?6?   $	??158??6?   $??22??6?   6?   ?? 5E   
   -   5        $ btnMantencionesTerminadas??5E      $??Mantenciones terminadas??64   $
??Left=?6V   $??322,167,0,0q?6q   $	??Top=?6?   $	??161??6?   $??22??6?   6?   5G      5H      