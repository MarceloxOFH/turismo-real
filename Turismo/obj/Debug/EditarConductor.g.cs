﻿#pragma checksum "..\..\EditarConductor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D2771EBB079EF06DDF0AC83393DA84EF011A65EEF257CFE118CF6AAA95071121"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// EditarConductor
    /// </summary>
    public partial class EditarConductor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEditar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLimpiar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombres;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbRut;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDisponibilidad;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbApellidos;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSueldo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EditarConductor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpCaducidadLicencia;
        
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
            System.Uri resourceLocater = new System.Uri("/Turismo;component/editarconductor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditarConductor.xaml"
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
            this.BtnEditar = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\EditarConductor.xaml"
            this.BtnEditar.Click += new System.Windows.RoutedEventHandler(this.btnEditar_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLimpiar = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.tbNombres = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbRut = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbDisponibilidad = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.tbApellidos = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbSueldo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.dpCaducidadLicencia = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

