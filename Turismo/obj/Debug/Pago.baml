   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.Pago   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  Pagos??5	   	   $	??720??6   $
??1080??6$    ? 
ResizeMode$ NoResize=?62    ? Icon$ Pictures/logo_icon1.png??6H    ? WindowStartupLocation$ Manual=?6g    ? Left$ 0??5
      
 ? Top$ 0??6   .??5      ? 
???????$??-4,0,0,0q?6"   .+?5   
   ?? -   5         ??Name$ 	rtActivas??5      $
??Left=?6'   $??29??6B   $??
863,97,0,0q?6N   ???	#FFC9A000$	??Top=?6u   $??67??6?   ???	#FFC9A0006?   ?? 5   
   -   5        $ rtFinalizadas??5      $
??Left=?6+   $??29??6F   $??
940,97,0,0q?6R   ???	#FFC9A000$	??Top=?6y   $??93??6?   ???	#FFC9A0006?   ?? 5   
   -   5        $ RtBarra??5      $
??Left=?6%   $	??727??6@   $??Center=?6M   $	??177??6h    J? OpacityMask
 ?????$??-6,0,0,0q?6?   ???	#FFC69C31??5      ?? 5       ?? EndPoint$ 0.5,1&?6&   	 ?? 
StartPoint$	 0.5,0&?67   .??5      ? 
 ? Color$
 	#FFAA9759??6#    ? Offset$ 1Q?65   ? 5      $
 	#FFD5C28C??6#   $ 0Q?65   5      5      ?? 5"   
   -   5         ??Name$ 
LblUsuario??5"      $??Usuario??6$   $??Center=?66   $??12,37,922,0q?6Z   $	??Top=?6o   $
??Bold"?6?   $??16(?6?   ?? 5#   
   -   5        $ LblCargo??5#      $??Cargo??6"   $??Center=?62   $??12,59,922,0q?6V   $	??Top=?6k   $??14(?6?   $
??Bold"?6?   ???	#FF7272726?   ?? 5$   
   -   5        $ 	RtUsuario??5$      $
??Left=?6'   $??79??6B   $??12,9,0,0q?6N   ???	#FFE5E5E5$	??Top=?6s   $	??146??6?   ?? 5%   
   $??58,12,968,642q?6   $??Pictures/usuario.png??6'    J? Opacity$	 0.8Q?6E   ?? 5)   
   -   5         ??Name$ BtnDepartamentos??5)      $
??Left=?6+   $??
12,105,0,0q?6F   $	??Top=?6Z   ???	#FFF1F0F0$	??146??6?   .??5*      ??  ?? Orientation$ 
Horizontal=?6   .+?5+      ?? $ ??Pictures/departamentos.png??6   $??24??6<   $??24??6G   ?? 5,      $??     DEPARTAMENTOS??6   $??Center=?66   $	??106??6Q   5-      5.      ?? 50   
   -   5        $ BtnInventario??50      $
??Left=?6(   $??
12,150,0,0q?6C   $	??Top=?6W   ???	#FFF1F0F0$	??146??6?   .??51      ?? $ 
Horizontal=?6   .+?52      ?? $??Pictures/inventario.png??6   $??24??69   $??24??6D   ?? 53      $??     INVENTARIO??6   $??Center=?63   $	??106??6N   54      55      ?? 57   
   -	   5        $ BtnEmpleados??57      $
??Left=?6'   $??
12,195,0,0q?6B   $	??Top=?6V   ???	#FFF1F0F0$	??146??6?   .??58      ?? $ 
Horizontal=?6   .+?59      ?? $??Pictures/empleados.png??6   $??24??68   $??24??6C   ?? 5:      $??     EMPLEADOS??6   $??Center=?62   $	??106??6M   5;      5<      ?? 5>   
   -
   5        $ BtnClientes??5>      $
??Left=?6&   $??
12,240,0,0q?6A   $	??Top=?6U   ???	#FFF1F0F0$	??146??6?   .??5?      ?? $ 
Horizontal=?6   .+?5@      ?? $??Pictures/clientes.png??6   $??24??67   $??24??6B   ?? 5A      $??     CLIENTES??6   $??Center=?61   $	??106??6L   5B      5C      ?? 5E   
   -   5        $ BtnConductores??5E      $
??Left=?6)   $??
12,285,0,0q?6D   $	??Top=?6X   ???	#FFF1F0F0$	??146??6?   .??5F      ?? $ 
Horizontal=?6   .+?5G      ?? $??Pictures/conductores.png??6   $??24??6:   $??24??6E   ?? 5H      $??     CONDUCTORES??6   $??Center=?64   $	??106??6O   5I      5J      ?? 5L   
   -   5        $ BtnVehiculos??5L      $
??Left=?6'   $??
12,330,0,0q?6B   $	??Top=?6V   ???	#FFF1F0F0$	??146??6?   .??5M      ?? $ 
Horizontal=?6   .+?5N      ?? $??Pictures/vehiculos.png??6   $??24??68   $??24??6C   ?? 5O      $??     VEHÍCULOS??6   $??Center=?62   $	??106??6M   5P      5Q      ?? 5S   
   -   5        $ BtnEstadisticas??5S      $
??Left=?6*   $??
12,375,0,0q?6E   $	??Top=?6Y   ???	#FFF1F0F0$	??146??6?   .??5T      ?? $ 
Horizontal=?6   .+?5U      ?? $??Pictures/estadisticas.png??6   $??24??6;   $??24??6F   ?? 5V      $??     ESTADÍSTICAS??6   $??Center=?65   $	??106??6P   5W      5X      ?? 5Z   
   -   5        $ BtnPagos??5Z      $
??Left=?6#   $??
12,420,0,0q?6>   $	??Top=?6R   ???	#FFEBC351
???????$	??146??6?   .??5[      ?? $ 
Horizontal=?6   .+?5\      ?? $??/Pictures/pagos.png??6   $??24??65   $??24??6@   ?? 5]      $??
     PAGOS??6   $??Center=?6.   $	??106??6I   5^      5_      ?? 5a   
   -   5        $ 
BtnCheckIn??5a      $
??Left=?6%   $??
12,465,0,0q?6@   $	??Top=?6T   ???	#FFF1F0F0$	??146??6?   .??5b      ?? $ 
Horizontal=?6   .+?5c      ?? $??Pictures/checkin.png??6   $??24??66   $??24??6A   ?? 5d      $??     CHECK IN??6   $??Center=?61   $	??106??6L   5e      5f      ?? 5h   
   -   5        $ BtnCheckOut??5h      $
??Left=?6&   $??
12,511,0,0q?6A   $	??Top=?6U   $	??146??6m   ???	#FFF1F0F0
???????.??5i      ?? $ 
Horizontal=?6   .+?5j      ?? $??Pictures/checkout.png??6   $??24??67   $??24??6B   ?? 5k      $??     CHECK OUT??6   $??Center=?62   $	??106??6M   5l      5m      ?? 5o   
   -   5        $ BtnCerrarSesion??5o      $
??Left=?6*   $??
12,621,0,0q?6E   $	??Top=?6Y   ???	#FFF1F0F0$	??146??6?   .??5p      ?? $ 
Horizontal=?6   .+?5q      ?? $??Pictures/cerrarsesion.png??6   $??24??6;   $??24??6F   ?? 5r      $??     CERRAR SESIÓN??6   $??Center=?66   $	??106??6Q   5s      5t      ?? 5w   
   $??Pagos??6   $
??Left=?6    $??
187,31,0,0q?6;   $	??Top=?6O   $	??311??6g   $??24(?6s   $
??Bold"?6?   ?? 5x   
   -   5        $ testName_lbl??5x      $??	Reservas:??6&   $
??Left=?6:   $??195,102,0,0q?6U   $	??Top=?6j   $	??192??6?   $??16(?6?   $
??Bold"?6?   &   System.Windows.Controls.DataGrid  5{   
   -   5          Name$ 	dgReserva??5{         
IsReadOnly .    AutoGenerateColumns .  $??198,133,45,312q?6U   ???	#CCD72F00$
??Bold"?6?    ? 	Resources 5|      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? 
TargetType ?? Property ?? Value??%?   '        ?? 5}      "  6   .?5~      ??  ? ?? ?	#FFE4EEF763   ?? 5       ? ??$ 1,1,1,1q?68   ?? 5?       ? ?? ?	#FF1487EE64   ?? 5?       ? ??$ Medium"?63   5?      5?         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$
  N°??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ?? *NRO_RESERVA+6R     5?      $  Rut Cliente??6%   $ 85 6c    6;   ?? *CLIENTE_RUT_CLIENTE+6c     5?      $  Nombres??6%   $	 115 6S    67   ?? *	NOMBRES+6S     5?      $ 
 Apellidos??6%   $	 115 6W    69   ?? *	APELLIDOS+6W     5?      $  Fecha Reserva??6%   $	 150 6_    6=   ?? *FECHA_RESERVA+6_     5?      $  Reserva Inicio??6%   $	 150 6a    6>   ?? *RESERVA_INICIO+6a     5?      $  Reserva Termino??6%   $ * 6c    6?   ?? *RESERVA_TERMINO+6c   5?      ?? 5?   
   -   5        $ testName_lbl_Copy??5?      $??Pagos:??6+   $
??Left=?6<   $??196,397,0,0q?6W   $	??Top=?6l   $	??192??6?   $??16(?6?   $
??Bold"?6?     5?   
   -   5        $ dgPagos??5?       .  .  $??198,431,175,106q?6S   ???	#CCD72F00$
??Bold"?6?    5?      ??%?   '        ?? 5?      "  6   .?5?      ??  ? ?? ?	#FFE4EEF763   ?? 5?       ? ??$ 1,1,1,1q?68   ?? 5?       ? ?? ?	#FF1487EE64   ?? 5?       ? ??$ Medium"?63   5?      5?       5?        5?      $
  N°??6%   $ 80 6Z    62   ?? *RESERVA_NRO_RESERVA+6Z     5?      $  ID Pago??6%   $ 50 6S    67   ?? *	ID_PAGO+6S     5?      $  Pago??6%   $	 120 6T    64   ?? *DESCRIPCION+6T     5?      $  Medio Pago??6%   $	 120 6Y    6:   ?? *
MEDIO_PAGO+6Y     5?      $  Fecha Pago??6%   $	 150 6Y    6:   ?? *
FECHA_PAGO+6Y     5?      $  Monto??6%   $ 70 6O    65   ?? *MONTO+6O     5?      $  Estado??6%   $ * 6Q    66   ?? *ESTADO+6Q   5?      ?? 5?   
   -   5        $ 
BtnActivas??5?      $??Activas??6%   $
??Left=?67   $??
865,99,0,0q?6R   $	??Top=?6f   $??63??6~   $??22??6?   6?   ?? 5?   
   -   5        $ BtnFinalizadas??5?      $??Finalizadas??6)   $
??Left=?6?   $??
942,99,0,0q?6Z   $	??Top=?6n   $??89??6?   $??22??6?   6?   ?? 5?   
   -   5        $ BtnGenerarInforme??5?      $(??"Generar Informe 
        de Pagos??6,   $
??Left=?6a   $??926,537,0,0q?6|   $	??Top=?6?   $	??109??6?   $??47??6?   6?     5?   
   -   5        $ dgReservaFinalizada??5?       .  .  $??198,133,45,312q?6_   ???	#CCD72F00$
??Bold"?6?    5?      ??%?   '        ?? 5?      "  6   .?5?      ??  ? ?? ?	#FFE4EEF763   ?? 5?       ? ??$ 1,1,1,1q?68   ?? 5?       ? ?? ?	#FF1487EE64   ?? 5?       ? ??$ Medium"?63   5?      5?       5?        5?      $
  N°??6%   $ 80 6R    62   ?? *NRO_RESERVA+6R     5?      $  Rut Cliente??6%   $ 85 6[    6;   ?? *RUT_CLIENTE+6[     5?      $  Nombres??6%   $	 115 6S    67   ?? *	NOMBRES+6S     5?      $ 
 Apellidos??6%   $	 115 6W    69   ?? *	APELLIDOS+6W     5?      $  Fecha Reserva??6%   $	 150 6_    6=   ?? *FECHA_RESERVA+6_     5?      $  Reserva Inicio??6%   $	 150 6a    6>   ?? *RESERVA_INICIO+6a     5?      $  Reserva Termino??6%   $ * 6c    6?   ?? *RESERVA_TERMINO+6c   5?      ?? 5?   
   -   5        $ testName_lbl_Copy1??5?      $??Monto Total:??6,   $
??Left=?6C   $??930,442,0,0q?6^   $	??Top=?6s   $	??113??6?   $??16(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ lblMontoTotal??5?      $??Center=?6(   $??0??6L   $
??Left=?6X   $??935,466,0,0q?6s   $	??Top=?6?   $	??100??6?   $??16(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ testName_lbl_Copy2??5?      $??$??6,   $
??Left=?68   $??924,465,0,0q?6S   $	??Top=?6h   $??24??6?   $??16(?6?   $
??Bold"?6?   ?? 5?   
   -   5        $ BtnRevisarComprobantePago??5?      $*??$Revisar Comprobante de Transferencia??64   $
??Left=?6c   $??198,612,0,0q?6~   $	??Top=?6?   $	??241??6?   $??28??6?   6?   ?? 5?   
   -   5        $ BtnActualizar??5?      $??
Actualizar??6(   $
??Left=?6=   $??831,612,0,0q?6X   $	??Top=?6m   $??78??6?   $??28??6?   ???	#FFBCE1E56?   5?      5?      