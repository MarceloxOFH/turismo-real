﻿#pragma checksum "..\..\CrearVehiculo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F2FB0855D93668B5E7EA63A7C05E83B3AE6A70705C5E62E498557F70ED0BDC54"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Turismo;


namespace Turismo {
    
    
    /// <summary>
    /// CrearVehiculo
    /// </summary>
    public partial class CrearVehiculo : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCrear;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLimpiar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPatente;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDisponibilidad;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCapacidad;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbEstado;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDescripcion;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CrearVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbModelo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Turismo;component/crearvehiculo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CrearVehiculo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnCrear = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\CrearVehiculo.xaml"
            this.BtnCrear.Click += new System.Windows.RoutedEventHandler(this.BtnCrear_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLimpiar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\CrearVehiculo.xaml"
            this.btnLimpiar.Click += new System.Windows.RoutedEventHandler(this.btnLimpiar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbPatente = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cbDisponibilidad = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\CrearVehiculo.xaml"
            this.cbDisponibilidad.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbDisponibilidad_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbCapacidad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbEstado = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\CrearVehiculo.xaml"
            this.cbEstado.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbEstado_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbDescripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbModelo = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

