   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.Empleados   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  	Empleados??5	   	   $	??720??5
      $
??1080??6    ? 
ResizeMode$ NoResize=?6,    ? Icon$ Pictures/logo_icon1.png??6B    ? WindowStartupLocation$ Manual=?6a    ? Left$ 0??5      
 ? Top$ 0??6   .??5      ? 
???????.+?5   
   ?? $??	Empleados??6   $
??Left=?6$   $??
187,31,0,0q?6?   $	??Top=?6S   $	??311??6k   $??24(?6w   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ 
lbl_Nombre??5      $??Nombre Empleado:??6$   $
??Left=?6?   $??191,102,0,0q?6Z   $	??Top=?6o   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5   
   -   5        $ lbl_Apellido??5      $??Apellido Empleado:??6&   $
??Left=?6C   $??191,139,0,0q?6^   $	??Top=?6s   $	??192??6?   $??16(?6?   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ tbnombreEmpleado??5      $
??Left=?6,   $??370,110,0,0q?6G    ?? TextWrapping$
 Wrap=?6\   $	??Top=?6p   $	??214??6?   $??20??6?   $
??Bold"?6?   ?? 5   
   -   5        $ tbApellidoEmpleado??5      $
??Left=?6.   $??370,147,0,0q?6I   $
 Wrap=?6^   $	??Top=?6r   $	??214??6?   $??20??6?   $
??Bold"?6?   ?? 5   
   -   5        $ 	lbl_Cargo??5      $??Cargo:??6#   $
??Left=?64   $??616,103,0,0q?6O   $	??Top=?6d   $	??192??6|   $??16(?6?   $
??Bold"?6?   ?? 5   
   -   5        	 ??Name$	 cbCargo??5      
 ?? SelectedValuePath$
 	id_estado??6$   $
??Left=?6B   $??682,108,0,0q?6]   $	??Top=?6r   $	??118??6?   $??22??6?   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ BtnEliminar??5      $??Eliminar??6&   $
??Left=?69   $??848,582,0,0q?6T   $	??Top=?6i   $??29??6?   $??78??6?   ???	#FFFCC5C56?   ?? 5   
   -   5        $ BtnCrear??5      $??Crear??6#   $
??Left=?63   $??660,582,0,0q?6N   $	??Top=?6c   $??29??6{   $??78??6?   ???	#FFD0FCCE6?   ?? 5   
   -	   5        $ BtnCrearCargo??5      $??Crear Cargo??6(   $
??Left=?6>   $??193,582,0,0q?6Y   $	??Top=?6n   $??29??6?   $??96??6?   6?   ?? 5   
   -
   5        $ 	BtnEditar??5      $??Editar??6$   $
??Left=?65   $??754,582,0,0q?6P   $	??Top=?6e   $??29??6}   $??78??6?   ???	#FFF6F9C36?   ?? 5   
   -   5        $ 	btnAcceso??5      $??Crear Acceso??6$   $
??Left=?6;   $??322,582,0,0q?6V   $	??Top=?6k   $??29??6?   $	??109??6?   6?   ?? 5   
   -   5        $ 
actualizar??5      $??
Actualizar??6%   $
??Left=?6:   $??941,582,0,0q?6U   $	??Top=?6j   $??29??6?   $??78??6?   ???	#FFBCE1E56?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgEmpleados??5         
IsReadOnly .    AutoGenerateColumns .  $??191,196,61,139q?6W   $
??Bold"?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ?? *ID_EMPLEADO+6Q     5       $ Nombre??6%   $	 140 6Q    65   ?? *	NOMBRES+6Q     5!      $ 	Apellidos??6%   $	 140 6V    68   ?? *	APELLIDOS+6V     5"      $ Año contratacion??6%   $	 110 6d    6?   ?? *AÑO_CONTRATACION+6d     5#      $ Cargo??6%   $	 100 6N    64   ?? *CARGO+6N     5$      $ Sueldo??6%   $ 80 6P    65   ?? *SUELDO+6P     5%      $ Username??6%   $ * 6T    67   ?? *
USERNAME+6T    ? 	Resources 5(      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType ?? Property ?? Value??%?   '        ?? 5)      "  6   .?5*      ??  ? ?? ?	#FFE4EEF763   ?? 5+       ? ??$ 0,0,1,2q?68   ?? 5,       ? ?? ?	#FF1487EE64   ?? 5-       ? ??$ Medium"?63   5.      5/      51      ?? 55   
   -   5         ??Name$ RtBarra??55      $
??Left=?6%   $	??727??6@   $??Center=?6M   $	??177??6h    J? OpacityMask
 ?????$??-6,0,0,0q?6?   ???	#FFC69C31??56      ?? 57       ?? EndPoint$ 0.5,1&?6&    ?? 
StartPoint$ 0.5,0&?67   .??58      ?  ? Color$ 	#FFAA9759??6#    ? Offset$ 1Q?65   ? 59      $ 	#FFD5C28C??6#   $ 0Q?65   5:      5<      ?? 5?   
   -   5        $ 
LblUsuario??5?      $??Usuario??6$   $??Center=?66   $??12,37,922,0q?6Z   $	??Top=?6o   $
??Bold"?6?   $??16(?6?   ?? 5@   
   -   5        $ LblCargo??5@      $??Cargo??6"   $??Center=?62   $??12,59,922,0q?6V   $	??Top=?6k   $??14(?6?   $
??Bold"?6?   ???	#FF7272726?   ?? 5A   
   -   5        $ 	RtUsuario??5A      $
??Left=?6'   $??79??6B   $??12,9,0,0q?6N   ???	#FFE5E5E5$	??Top=?6s   $	??146??6?   ?? 5B   
   $??58,12,968,642q?6   $??Pictures/usuario.png??6'    J? Opacity$	 0.8Q?6E   ?? 5F   
   -   5        $ BtnDepartamentos??5F      $
??Left=?6+   $??
12,105,0,0q?6F   $	??Top=?6Z   ???	#FFF1F0F0$	??146??6?   .??5G      ??  ?? Orientation$ 
Horizontal=?6   .+?5H      ?? $ ??Pictures/departamentos.png??6   $??24??6<   $??24??6G   ?? 5I      $??     DEPARTAMENTOS??6   $??Center=?66   $	??106??6Q   5J      5K      ?? 5M   
   -   5        $ BtnInventario??5M      $
??Left=?6(   $??
12,150,0,0q?6C   $	??Top=?6W   ???	#FFF1F0F0$	??146??6?   .??5N      ?? $ 
Horizontal=?6   .+?5O      ?? $??Pictures/inventario.png??6   $??24??69   $??24??6D   ?? 5P      $??     INVENTARIO??6   $??Center=?63   $	??106??6N   5Q      5R      ?? 5T   
   -   5        $ BtnEmpleados??5T      $
??Left=?6'   $??
12,195,0,0q?6B   $	??Top=?6V   ???	#FFEBC351
???????$	??146??6?   .??5U      ?? $ 
Horizontal=?6   .+?5V      ?? $??Pictures/empleados.png??6   $??24??68   $??24??6C   ?? 5W      $??     EMPLEADOS??6   $??Center=?62   $	??106??6M   5X      5Y      ?? 5[   
   -   5        $ BtnClientes??5[      $
??Left=?6&   $??
12,240,0,0q?6A   $	??Top=?6U   ???	#FFF1F0F0$	??146??6?   .??5\      ?? $ 
Horizontal=?6   .+?5]      ?? $??Pictures/clientes.png??6   $??24??67   $??24??6B   ?? 5^      $??     CLIENTES??6   $??Center=?61   $	??106??6L   5_      5`      ?? 5b   
   -   5        $ BtnConductores??5b      $
??Left=?6)   $??
12,285,0,0q?6D   $	??Top=?6X   ???	#FFF1F0F0$	??146??6?   .??5c      ?? $ 
Horizontal=?6   .+?5d      ?? $??Pictures/conductores.png??6   $??24??6:   $??24??6E   ?? 5e      $??     CONDUCTORES??6   $??Center=?64   $	??106??6O   5f      5g      ?? 5i   
   -   5        $ BtnVehiculos??5i      $
??Left=?6'   $??
12,330,0,0q?6B   $	??Top=?6V   ???	#FFF1F0F0$	??146??6?   .??5j      ?? $ 
Horizontal=?6   .+?5k      ?? $??Pictures/vehiculos.png??6   $??24??68   $??24??6C   ?? 5l      $??     VEHÍCULOS??6   $??Center=?62   $	??106??6M   5m      5n      ?? 5p   
   -   5        $ BtnEstadisticas??5p      $
??Left=?6*   $??
12,375,0,0q?6E   $	??Top=?6Y   ???	#FFF1F0F0$	??146??6?   .??5q      ?? $ 
Horizontal=?6   .+?5r      ?? $??Pictures/estadisticas.png??6   $??24??6;   $??24??6F   ?? 5s      $??     ESTADÍSTICAS??6   $??Center=?65   $	??106??6P   5t      5u      ?? 5w   
   -   5        $ BtnPagos??5w      $
??Left=?6#   $??
12,420,0,0q?6>   $	??Top=?6R   ???	#FFF1F0F0$	??146??6?   .??5x      ?? $ 
Horizontal=?6   .+?5y      ?? $??/Pictures/pagos.png??6   $??24??65   $??24??6@   ?? 5z      $??
     PAGOS??6   $??Center=?6.   $	??106??6I   5{      5|      ?? 5~   
   -   5        $ 
BtnCheckIn??5~      $
??Left=?6%   $??
12,465,0,0q?6@   $	??Top=?6T   ???	#FFF1F0F0$	??146??6?   .??5      ?? $ 
Horizontal=?6   .+?5?      ?? $??Pictures/checkin.png??6   $??24??66   $??24??6A   ?? 5?      $??     CHECK IN??6   $??Center=?61   $	??106??6L   5?      5?      ?? 5?   
   -   5        $ BtnCheckOut??5?      $
??Left=?6&   $??
12,511,0,0q?6A   $	??Top=?6U   $	??146??6m   ???	#FFF1F0F0.??5?      ?? $ 
Horizontal=?6   .+?5?      ?? $??Pictures/checkout.png??6   $??24??67   $??24??6B   ?? 5?      $??     CHECK OUT??6   $??Center=?62   $	??106??6M   5?      5?      ?? 5?   
   -   5        $ BtnCerrarSesion??5?      $
??Left=?6*   $??
12,621,0,0q?6E   $	??Top=?6Y   ???	#FFF1F0F0$	??146??6?   .??5?      ?? $ 
Horizontal=?6   .+?5?      ?? $??Pictures/cerrarsesion.png??6   $??24??6;   $??24??6F   ?? 5?      $??     CERRAR SESIÓN??6   $??Center=?66   $	??106??6Q   5?      5?      ?? 5?   
   $??	Empleados??6   $
??Left=?6$   $??
187,31,0,0q?6?   $	??Top=?6S   $	??311??6k   $??24(?6w   $
??Bold"?6?   5?      5?      