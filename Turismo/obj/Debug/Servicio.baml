   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.Servicio   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  	Servicios??5	   	   $	??470??6   $	??580??6(   
??????? ? Icon$ Pictures/logo_icon1.png??5
       ? WindowStartupLocation$ Manual=?62    ? Left$ 0??5      
 ? Top$ 0??6   .??5      ? .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgOtrosServicios??5         
IsReadOnly .    AutoGenerateColumns .  $??34,200,46,75q?6\   $
??Bold"?6?    ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 ?? 
TargetType
 ?? Property ?? Value??%?   '        ?? 5      "	  6   .?5      ?? 
 ? ?? ?	#FFE4EEF763   ?? 5      
 ? ??$ 1,1,1,1q?68   ?? 5      
 ? ?? ?	#FF1487EE64   ?? 5      
 ? ??$ Medium"?63   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	  Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ?? *ID_SERVICIO+6R     5      $ 	 Servicio??6%   $	 180 6\    68   ?? *NOMBRE_SERVICIO+6\     5      $  Descripción??6%   $	 200 6[    6;   ?? *DESCRIPCION+6[     5      $  Costo??6%   $ * 6O    65   ?? *COSTO+6O   5      ?? 5!   
   -   5         ??Name$ rtBtnSerAct??5!      $
??Left=?6)   $??29??6D   $??383,167,0,0q?6P   ???	#FFC9A000$	??Top=?6x   $	??150??6?   ???	#FFC9A0006?     5#   
   -   5        $ dgServiciosActuales??5#       .  .  $??34,200,46,75q?6_   $
??Bold"?6?    5$      ??%?   '        ?? 5%      "	  6   .?5&      ?? 
 ? ?? ?	#FFE4EEF763   ?? 5'      
 ? ??$ 1,1,1,1q?68   ?? 5(      
 ? ?? ?	#FF1487EE64   ?? 5)      
 ? ??$ Medium"?63   5*      5+       5-        5.      $	  Id??6%   $ 30 6R    62   ?? *ID_SERVICIO+6R     5/      $ 	 Servicio??6%   $	 180 6\    68   ?? *NOMBRE_SERVICIO+6\     50      $  Descripción??6%   $	 200 6[    6;   ?? *DESCRIPCION+6[     51      $  Costo??6%   $ * 6O    65   ?? *COSTO+6O   54      ?? 58   
   -   5         ??Name$ btnCrear??58      $??Crear??6#   $
??Left=?63   $??
34,380,0,0q?6N   $	??Top=?6b   $??64??6z   $??32??6?   ???	#FFD0FCCE6?   ?? 59   
   -   5        $ btnEliminar??59      $??Eliminar??6&   $
??Left=?69   $??200,380,0,0q?6T   $	??Top=?6i   $??65??6?   $??31??6?    J? RenderTransformOrigin$ 
0.45,0.664&?6?   ???	#FFFCC5C56?   ?? 5:   
   -   5        $ 	btnEditar??5:      $??Editar??6$   $
??Left=?65   $??116,380,0,0q?6P   $	??Top=?6e   $??65??6}   $??31??6?   ???	#FFF6F9C36?   ?? 5;   
   $??ID Departamento:??6   $
??Left=?6+   $??	34,75,0,0q?6F   $	??Top=?6Y   $	??178??6q   $??16(?6}   $
??Bold"?6?   ?? 5<   
   $??	Servicios??6   $
??Left=?6$   $??	10,10,0,0q?6?   $	??Top=?6R   $	??311??6j   $??24(?6v   $
??Bold"?6?   ?? 5=   
   $??Nombre Departamento:??6   $
??Left=?6/   $??
34,106,0,0q?6J   $	??Top=?6^   $	??194??6v   $??16(?6?   $
??Bold"?6?   ?? 5>   
   -   5         ??Name$ tbnombreDepartamento??5>      $
??Left=?60   $??233,109,0,0q?6K    ?? TextWrapping$
 Wrap=?6`   $	??Top=?6t   $	??188??6?   $
??Bold"?6?   {?.  6?   ?? 5?   
   -   5        $ tbidDepartamento??5?      $
??Left=?6,   $??
233,77,0,0q?6G   $
 Wrap=?6[   $	??Top=?6o   $??69??6?   {?.  $
??Bold"?6?   ?? 5@   
   -	   5        $ btnActualizar??5@      $??
Actualizar??6(   $
??Left=?6=   $??284,380,0,0q?6X   $	??Top=?6m   $??79??6?   $??31??6?   ???	#FFBCE1E56?   ?? 5A   
   -
   5        $ rtBtnOtrSer??5A      $??Center=?6)   $??29??6F   $??	0,167,0,0q?6R   ???	#FFC9A000$	??Top=?6x   $	??150??6?   ???	#FFC9A0006?   ?? 5B   
   -   5        $ BtnServiciosActuales??5B      $??Servicios Actuales??6/   $
??Left=?6L   $??385,169,0,0q?6g   $	??Top=?6|   $	??146??6?   $??22??6?   6?   ?? 5C   
   -   5        $ BtnOtrosServicios??5C      $??Todos los Servicios??6,   $??Center=?6J   $??	0,169,0,0q?6g   $	??Top=?6z   $	??146??6?   $??22??6?   6?   ?? 5D   
   -   5        $ BtnMoverServicio??5D      $??Mover Servicio??6+   $
??Left=?6D   $??428,380,0,0q?6_   $	??Top=?6t   $	??106??6?   $??31??6?   ???	#FFA5DF90
???   ?6?   5F      5G      