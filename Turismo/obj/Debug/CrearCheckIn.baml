   M S B A M L   `   `   `  ????T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Turismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TurismoTurismo 5   	      Turismo.CrearCheckIn   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Turismo     5   	     ? Title$  Realizar Check In??5	   	   $	??580??6#   $	??630??60   
??????? ? Icon$ Pictures/logo_icon1.png??6T    ? WindowStartupLocation$ Manual=?6s    ? Left$ 0??6?   
 ? Top$ 0??6?   .??5
      ? .+?5   
   ?? -   5         ??Name$ RtPago??5      $
??Left=?6$   $	??162??6?   $??314,340,0,0q?6L   
???   ?$	??Top=?6p   $	??265??6?   ???	#FFDADAD86?   ?? 5   
   $??Realizar Check In??6   $
??Left=?6,   $??	10,10,0,0q?6G   $	??Top=?6Z   $	??311??6r   $??24(?6~   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ lblCondicionDepto??5      $??Condicion Departamento:??6+   $
??Left=?6M   $??
331,79,0,0q?6h   $	??Top=?6|   $
??Bold"?6?   ?? 5   
   -   5        $ lblPagoEstadia??5      $??Nombre Cliente:??6(   $
??Left=?6B   $??
27,158,0,0q?6]   $	??Top=?6q   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ tbNombreCliente??5      $
??Left=?6+   $??131,158,0,0q?6F    ?? TextWrapping$
 Wrap=?6[   $?? ??6o   $	??Top=?6w   $	??160??6?   $
??Bold"?6?   {?.  6?   ?? 5   
   -   5        $ lblNroReserva??5      $??N° de reserva:??6'   $
??Left=?6@   $??	28,78,0,0q?6[   $	??Top=?6n   $
??Bold"?6?   ?? 5   
   -   5        	 ??Name$	 btnSubirFirma??5      $??Subir Firma??6(   $
??Left=?6>   $??101,304,0,0q?6Y   $	??Top=?6n   $??98??6?   ?? 5   
   -   5        $ LblFirma??5      $?? ??6"   $??Center=?6-   $
??Left=?6Q   $??
88,502,0,0q?6l   $	??Top=?6?   $	??121??6?   $
??Bold"?6?   ?? 5   
   -   5        $	 btnRealizarPagoEstadia??5      $??Proceder al Pago??61   $
??Left=?6L   $??380,429,0,0q?6g   $	??Top=?6|   $	??132??6?   $??58??6?   ?? 5   
   -	   5        $ tbCondicionDepto??5      $
??Left=?6,   $??331,104,0,0q?6G   $
 Wrap=?6\   $?? ??6p   $	??Top=?6x   $	??236??6?   $??78??6?   $
??Bold"?6?   ?? 5   
   -
   5        $ lblAnotaciones??5      $??Anotaciones:??6(   $
??Left=?6?   $??333,194,0,0q?6Z   $	??Top=?6o   $
??Bold"?6?   ?? 5   
   -   5        $ tbAnotaciones??5      $
??Left=?6)   $??331,218,0,0q?6D   $
 Wrap=?6Y   $?? ??6m   $	??Top=?6u   $	??236??6?   $??80??6?   $
??Bold"?6?   ?? 5   
   -   5        $ 
lblRegalos??5      $??Regalo:??6$   $
??Left=?66   $??
28,194,0,0q?6Q   $	??Top=?6e   $
??Bold"?6}   ?? 5    
   -   5        
 ??Name$
 cbRegalo??5        ?? SelectedValuePath$ 	id_regalo??6%   $
??Left=?6C   $??131,198,0,0q?6^   $	??Top=?6s   $	??160??6?   $??22??6?   $
??Bold"?6?   6?   ?? 5#   
   -   5        $ tbNumeroReserva??5#      $
??Left=?6+   $??
131,80,0,0q?6F   $
 Wrap=?6Z   $?? ??6n   $	??Top=?6v   $??79??6?   {?.  $
??Bold"?6?   ?? 5$   
   -   5        $ lblPagoEstadia_Copy??5$      $??Rut Cliente:??6-   $
??Left=?6D   $??
27,116,0,0q?6_   $	??Top=?6s   $
??Bold"?6?   ?? 5%   
   -   5        $ tbRutCliente??5%      $
??Left=?6(   $??131,116,0,0q?6C   $
 Wrap=?6X   $?? ??6l   $	??Top=?6t   $	??160??6?   $
??Bold"?6?   {?.  6?   ?? 5&   
   -   5        $ lblPagoEstadia_Copy1??5&      $??Pago por estadía:??6.   $
??Left=?6J   $??376,348,0,0q?6e   $	??Top=?6z   $
??Bold"?6?   $??16(?6?   ?? 5'   
   -   5        $ RtFoto??5'      $
??Left=?6$   $	??164??6?   $??
89,338,0,0q?6L   
???   ?$	??Top=?6o   $	??122??6?   
???????6?   ?? 5(   
   -   5         ??Name$ 	ImgImagen??5(      $
??Left=?6#   $	??160??6>   $??
90,340,0,0q?6K   $	??Top=?6_   $	??120??6w   ?? 5)   
   -   5        $ lblMontoPago??5)      $
??0000??6&   $??Center=?65   $
??Left=?6Y   $??394,377,0,0q?6t   $	??Top=?6?   $
??Bold"?6?   $??16(?6?   $	??108??6?   ?? 5*   
   -   5        $ lblPagoEstadia_Copy2??5*      $??$??6.   $
??Left=?6:   $??380,377,0,0q?6U   $	??Top=?6j   $
??Bold"?6?   $??16(?6?   $??28??6?   53      54      