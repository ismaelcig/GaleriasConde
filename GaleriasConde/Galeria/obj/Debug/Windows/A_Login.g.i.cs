﻿#pragma checksum "..\..\..\Windows\A_Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1EEA9AC65FD603A103D647E173597041"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Elysium;
using Elysium.Controls;
using Elysium.Converters;
using Elysium.Parameters;
using Galeria.User_Controls.Management_Windows;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Galeria.Windows {
    
    
    /// <summary>
    /// A_Login
    /// </summary>
    public partial class A_Login : Elysium.Controls.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridUS;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttNext;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttReg;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridPW;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttLogin;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\A_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttBack;
        
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
            System.Uri resourceLocater = new System.Uri("/Galeria;component/windows/a_login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\A_Login.xaml"
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
            this.GridUS = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.textBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Windows\A_Login.xaml"
            this.textBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttNext = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Windows\A_Login.xaml"
            this.buttNext.Click += new System.Windows.RoutedEventHandler(this.buttNext_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttReg = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Windows\A_Login.xaml"
            this.buttReg.Click += new System.Windows.RoutedEventHandler(this.buttReg_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GridPW = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 45 "..\..\..\Windows\A_Login.xaml"
            this.passwordBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.passwordBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttLogin = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Windows\A_Login.xaml"
            this.buttLogin.Click += new System.Windows.RoutedEventHandler(this.buttLogin_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttBack = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Windows\A_Login.xaml"
            this.buttBack.Click += new System.Windows.RoutedEventHandler(this.buttBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

