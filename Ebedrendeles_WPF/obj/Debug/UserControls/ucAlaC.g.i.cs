﻿#pragma checksum "..\..\..\UserControls\ucAlaC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1A0D7A80D478A2B5912610DA7DF6F71E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ebedrendeles_WPF.UserControls;
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


namespace Ebedrendeles_WPF.UserControls {
    
    
    /// <summary>
    /// ucAlaC
    /// </summary>
    public partial class ucAlaC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\UserControls\ucAlaC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAlac;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UserControls\ucAlaC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn etelekID;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\ucAlaC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSave;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\ucAlaC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDate;
        
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
            System.Uri resourceLocater = new System.Uri("/Ebedrendeles_WPF;component/usercontrols/ucalac.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\ucAlaC.xaml"
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
            this.dgAlac = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\UserControls\ucAlaC.xaml"
            this.dgAlac.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.dgAlac_MouseDown);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\UserControls\ucAlaC.xaml"
            this.dgAlac.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgAlac_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.etelekID = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.btSave = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserControls\ucAlaC.xaml"
            this.btSave.Click += new System.Windows.RoutedEventHandler(this.btSave_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

