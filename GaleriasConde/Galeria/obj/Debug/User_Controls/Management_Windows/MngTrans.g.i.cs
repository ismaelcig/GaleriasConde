﻿#pragma checksum "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DC84EF40B739AF32834962B067E01898"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Elysium;
using Elysium.Controls;
using Elysium.Converters;
using Elysium.Parameters;
using Galeria.User_Controls;
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


namespace Galeria.User_Controls.Management_Windows {
    
    
    /// <summary>
    /// MngTrans
    /// </summary>
    public partial class MngTrans : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Elysium.Controls.ToggleSwitch checkBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxArt;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxUser;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBenefit;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtComment;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttAdd;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttMod;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttDel;
        
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
            System.Uri resourceLocater = new System.Uri("/Galeria;component/user_controls/management_windows/mngtrans.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
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
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 22 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.checkBox = ((Elysium.Controls.ToggleSwitch)(target));
            return;
            case 4:
            this.comboBoxArt = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.comboBoxUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtBenefit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtComment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.buttAdd = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
            this.buttAdd.Click += new System.Windows.RoutedEventHandler(this.buttAdd_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buttMod = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
            this.buttMod.Click += new System.Windows.RoutedEventHandler(this.buttMod_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.buttDel = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\User_Controls\Management_Windows\MngTrans.xaml"
            this.buttDel.Click += new System.Windows.RoutedEventHandler(this.buttDel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

