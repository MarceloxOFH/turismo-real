   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.Inventario   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  
Inventario??5	   	   $	??720??6   $
??1080??6)    ? Icon$ Pictures/logo_icon1.png??5
       ? WindowStartupLocation$ Manual=?62    ? Left$ 0??5      
 ? Top$ 0??6   .??5      ? 
???????.+?5   
   ?? -   5         ??Name$ RtBarra??5      $
??Left=?6%   $	??727??6@   $??Center=?6M   $	??177??6h    J? OpacityMask
 ?????$??-6,0,0,0q?6?   ???	#FFC69C31??5      ?? 5       ?? EndPoint$ 0.5,1&?6&    ?? 
StartPoint$ 0.5,0&?67   .??5      ? 	 ? Color$	 	#FFAA9759??6#   
 ? Offset$
 1Q?65   ? 5      $	 	#FFD5C28C??6#   $
 0Q?65   5      5      ?? 5   
   -   5         ??Name$ 
LblUsuario??5      $??Usuario??6$   $??Center=?66   $??12,37,922,0q?6Z   $	??Top=?6o   $
??Bold"?6?   $??16(?6?   ?? 5   
   -   5        $ LblCargo??5      $??Cargo??6"   $??Center=?62   $??12,59,922,0q?6V   $	??Top=?6k   $??14(?6?   $
??Bold"?6?   ???	#FF7272726?   ?? 5   
   -   5        $ 	RtUsuario??5      $
??Left=?6'   $??79??6B   $??12,9,0,0q?6N   ???	#FFE5E5E5$	??Top=?6s   $	??146??6?   ?? 5   
   $??58,12,968,642q?6   $??Pictures/usuario.png??6'    J? Opacity$	 0.8Q?6E   ?? 5!   
   -   5         ??Name$ BtnDepartamentos??5!      $
??Left=?6+   $??
12,105,0,0q?6F   $	??Top=?6Z   ???	#FFF1F0F0$	??146??6?   .??5"      ??  ?? Orientation$ 
Horizontal=?6   .+?5#      ?? $ ??Pictures/departamentos.png??6   $??24??6<   $??24??6G   ?? 5$      $??     DEPARTAMENTOS??6   $??Center=?66   $	??106??6Q   5%      5&      ?? 5(   
   -   5        $ BtnInventario??5(      $
??Left=?6(   $??
12,150,0,0q?6C   $	??Top=?6W   ???	#FFEBC351
???????$	??146??6?   .??5)      ?? $ 
Horizontal=?6   .+?5*      ?? $??Pictures/inventario.png??6   $??24??69   $??24??6D   ?? 5+      $??     INVENTARIO??6   $??Center=?63   $	??106??6N   5,      5-      ?? 5/   
   -   5        $ BtnEmpleados??5/      $
??Left=?6'   $??
12,195,0,0q?6B   $	??Top=?6V   ???	#FFF1F0F0$	??146??6?   .??50      ?? $ 
Horizontal=?6   .+?51      ?? $??Pictures/empleados.png??6   $??24??68   $??24??6C   ?? 52      $??     EMPLEADOS??6   $??Center=?62   $	??106??6M   53      54      ?? 56   
   -   5        $ BtnClientes??56      $
??Left=?6&   $??
12,240,0,0q?6A   $	??Top=?6U   ???	#FFF1F0F0$	??146??6?   .??57      ?? $ 
Horizontal=?6   .+?58      ?? $??Pictures/clientes.png??6   $??24??67   $??24??6B   ?? 59      $??     CLIENTES??6   $??Center=?61   $	??106??6L   5:      5;      ?? 5=   
   -	   5        $ BtnConductores??5=      $
??Left=?6)   $??
12,285,0,0q?6D   $	??Top=?6X   ???	#FFF1F0F0$	??146??6?   .??5>      ?? $ 
Horizontal=?6   .+?5?      ?? $??Pictures/conductores.png??6   $??24??6:   $??24??6E   ?? 5@      $??     CONDUCTORES??6   $??Center=?64   $	??106??6O   5A      5B      ?? 5D   
   -
   5        $ BtnVehiculos??5D      $
??Left=?6'   $??
12,330,0,0q?6B   $	??Top=?6V   ???	#FFF1F0F0$	??146??6?   .??5E      ?? $ 
Horizontal=?6   .+?5F      ?? $??Pictures/vehiculos.png??6   $??24??68   $??24??6C   ?? 5G      $??     VEHÍCULOS??6   $??Center=?62   $	??106??6M   5H      5I      ?? 5K   
   -   5        $ BtnEstadisticas??5K      $
??Left=?6*   $??
12,375,0,0q?6E   $	??Top=?6Y   ???	#FFF1F0F0$	??146??6?   .??5L      ?? $ 
Horizontal=?6   .+?5M      ?? $??Pictures/estadisticas.png??6   $??24??6;   $??24??6F   ?? 5N      $??     ESTADÍSTICAS??6   $??Center=?65   $	??106??6P   5O      5P      ?? 5R   
   -   5        $ BtnPagos??5R      $
??Left=?6#   $??
12,420,0,0q?6>   $	??Top=?6R   ???	#FFF1F0F0$	??146??6?   .??5S      ?? $ 
Horizontal=?6   .+?5T      ?? $??/Pictures/pagos.png??6   $??24??65   $??24??6@   ?? 5U      $??
     PAGOS??6   $??Center=?6.   $	??106??6I   5V      5W      ?? 5Y   
   -   5        $ 
BtnCheckIn??5Y      $
??Left=?6%   $??
12,465,0,0q?6@   $	??Top=?6T   ???	#FFF1F0F0$	??146??6?   .??5Z      ?? $ 
Horizontal=?6   .+?5[      ?? $??Pictures/checkin.png??6   $??24??66   $??24??6A   ?? 5\      $??     CHECK IN??6   $??Center=?61   $	??106??6L   5]      5^      ?? 5`   
   -   5        $ BtnCheckOut??5`      $
??Left=?6&   $??
12,511,0,0q?6A   $	??Top=?6U   $	??146??6m   ???	#FFF1F0F0.??5a      ?? $ 
Horizontal=?6   .+?5b      ?? $??Pictures/checkout.png??6   $??24??67   $??24??6B   ?? 5c      $??     CHECK OUT??6   $??Center=?62   $	??106??6M   5d      5e      ?? 5g   
   -   5        $ BtnCerrarSesion??5g      $
??Left=?6*   $??
12,621,0,0q?6E   $	??Top=?6Y   ???	#FFF1F0F0$	??146??6?   .??5h      ?? $ 
Horizontal=?6   .+?5i      ?? $??Pictures/cerrarsesion.png??6   $??24??6;   $??24??6F   ?? 5j      $??     CERRAR SESIÓN??6   $??Center=?66   $	??106??6Q   5k      5l      ?? 5p   
   $
??Left=?6   $	??580??6/   $??
632,90,0,0q?6<   
???   ?$	??Top=?6_   $	??418??6w   ?? 5r   
   $
??Left=?6   $	??580??6/   $??
190,90,0,0q?6<   
???   ?$	??Top=?6_   $	??423??6w   ?? 5s   
   $??Gestionar Inventario??6   $
??Left=?6/   $??
187,31,0,0q?6J   $	??Top=?6^   $	??311??6v   $??24(?6?   $
??Bold"?6?   ?? 5t   
   -   5        $ testName_lbl??5t      $??Nombre Artículo:??6&   $
??Left=?6A   $??214,164,0,0q?6\   $	??Top=?6q   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5u   
   -   5        $ testName_lbl_Copy??5u      $??Id Artículo:??6+   $
??Left=?6B   $??214,201,0,0q?6]   $	??Top=?6r   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5v   
   -   5         ??Name$ tbNombreArticulo??5v      $
??Left=?6,   $??356,168,0,0q?6G    ?? TextWrapping$
 Wrap=?6\   $	??Top=?6p   $	??226??6?   $??20??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   $
??Bold"?6?   {?.  .??6?   z?5w      V? 5x      .~?5y      ?? ?? 5z      ?? 5{       ?? Angle$ -0.045Q?6&   T? 5|      5}      .??5~   '   5      ?? 5?   
   -   5        $ tbIdArticulo??5?      $
??Left=?6(   $??356,205,0,0q?6C   $
 Wrap=?6X   $	??Top=?6l   $??84??6?   $??20??6?   $
??Bold"?6?   {?.  6?   ?? 5?   
   -   5        $ BtnEliminar??5?      $??Eliminar??6&   $
??Left=?69   $??409,624,0,0q?6T   $	??Top=?6i   $??29??6?   $??78??6?   ???	#FFFCC5C56?   ?? 5?   
   -   5        $ BtnCrear??5?      $??Crear??6#   $
??Left=?63   $??214,624,0,0q?6N   $	??Top=?6c   $??29??6{   $??78??6?   ???	#FFD0FCCE6?   ?? 5?   
   -   5        $ 	BtnEditar??5?      $??Editar??6$   $
??Left=?65   $??311,624,0,0q?6P   $	??Top=?6e   $??29??6}   $??78??6?   ???	#FFF6F9C36?   &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ dgInventario??5?         
IsReadOnly .    AutoGenerateColumns .  $??214,242,497,89q?6X   $
??Bold"?6?    ? 	Resources 5?      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType ?? Property ?? Value??%?   '        ?? 5?      "  6   .?5?      ??  ? ?? ?	#FFE4EEF763   ?? 5?       ? ??$ 1,1,1,1q?68   ?? 5?       ? ?? ?	#FF1487EE64   ?? 5?       ? ??$ Medium"?63   5?      5?         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$	  Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ?? *ID_ARTICULO+6R     5?      $  Categoría??6%   $	 100 6W    69   ?? *	CATEGORIA+6W     5?      $ 
 Artículo??6%   $ * 6\    68   ?? *NOMBRE_ARTICULO+6\   5?      ?? 5?   
   -   5        $ BtnInvDepartamento??5?      $??Gestionar inventario??6-   $
??Left=?6L   $??885,624,0,0q?6g   $	??Top=?6|   $??29??6?   $	??139??6?   $ 0.111,0.601&?6?     5?   
   -   5        $ dgInvDepartamento??5?       .  .  $??655,241,56,89q?6]   $
??Bold"?6?    5?      ??%?   '        ?? 5?      "  6   .?5?      ??  ? ?? ?	#FFE4EEF763   ?? 5?       ? ??$ 1,1,1,1q?68   ?? 5?       ? ?? ?	#FF1487EE64   ?? 5?       ? ??$ Medium"?63   5?      5?       5?        5?      $	  Id??6%   $ 40 6V    62   ?? *ID_DEPARTAMENTO+6V     5?      $  Nombre??6%   $	 200 6Q    66   ?? *NOMBRE+6Q     5?      $  Región??6%   $ * 6Q    66   ?? *REGION+6Q   5?      ?? 5?   
   -   5        $ testName_lbl_Copy1??5?      $??Inventario:??6,   $
??Left=?6B   $??
214,98,0,0q?6]   $	??Top=?6q   $	??192??6?   $??18(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ testName_lbl_Copy2??5?      $??Departamento:??6,   $
??Left=?6D   $??
656,97,0,0q?6_   $	??Top=?6s   $	??192??6?   $??18(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ testName_lbl_Copy3??5?      $??Nombre Depto:??6,   $
??Left=?6D   $??656,162,0,0q?6_   $	??Top=?6t   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ testName_lbl_Copy4??5?      $??	Id Depto:??6,   $
??Left=?6@   $??656,199,0,0q?6[   $	??Top=?6p   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ tbNombreDepartamento??5?      $
??Left=?60   $??798,166,0,0q?6K   $
 Wrap=?6`   $	??Top=?6t   $	??225??6?   $??20??6?   $
??Bold"?6?   {?.  6?   ?? 5?   
   -   5        $ tbIdDepartamento??5?      $
??Left=?6,   $??798,203,0,0q?6G   $
 Wrap=?6\   $	??Top=?6p   $??84??6?   $??20??6?   $
??Bold"?6?   {?.  6?   ?? 5?   
   -    5        $ testName_lbl_Copy5??5?      $%??Listado de todos los artículos??6,   $
??Left=?6U   $??214,122,0,0q?6p   $	??Top=?6?   $	??242??6?   $??14(?6?   $
??Bold"?6?   ???	#FF7070706?   ?? 5?   
   -!   5        $ testName_lbl_Copy6??5?      $+??%Gestionar inventario por departamento??6,   $
??Left=?6\   $??657,121,0,0q?6w   $	??Top=?6?   $	??297??6?   $??14(?6?   $
??Bold"?6?   ???	#FF7070706?   ?? 5?   
   -"   5        $ BtnActualizar??5?      $??
Actualizar??6(   $
??Left=?6=   $??505,624,0,0q?6X   $	??Top=?6m   $??29??6?   $??78??6?   ???	#FFBCE1E56?   ?? 5?   
   -#   5        $ BtnGestionarCategorias??5?      $??      Ver
Categorías??61   $
??Left=?6T   $??505,116,0,0q?6o   $	??Top=?6?   $??78??6?   $??40??6?   6?   5?      5?      