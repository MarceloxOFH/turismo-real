﻿#pragma checksum "..\..\Product.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "00EF73C18C0E2ED3C5CE9E14A473F62C52040528F0A90B50AF0E1FBB0FC91EF4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using Tienda;


namespace Tienda {
    
    
    /// <summary>
    /// Product
    /// </summary>
    public partial class Product : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productName_lbl;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productType_lbl;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addToCart_btn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amount_txtbx;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productPrice_lbl;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productStock_lbl;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productDescription_lbl;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label productId_lbl;
        
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
            System.Uri resourceLocater = new System.Uri("/Turismo;component/product.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Product.xaml"
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
            this.productName_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.productType_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.addToCart_btn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Product.xaml"
            this.addToCart_btn.Click += new System.Windows.RoutedEventHandler(this.AddToCart_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.amount_txtbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.productPrice_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.productStock_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.productDescription_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.productId_lbl = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

