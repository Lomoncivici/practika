﻿#pragma checksum "..\..\Check.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0CF57980E9703C647BEBBD94D3FBCC4E2BF05CD01E593071C4BDD4126C3E219E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Practoz5;
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


namespace Practoz5 {
    
    
    /// <summary>
    /// Check
    /// </summary>
    public partial class Check : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CheckpleaseTable;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteClick;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddClick;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeClick;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Position;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategorBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Check.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckUpload;
        
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
            System.Uri resourceLocater = new System.Uri("/Practoz5;component/check.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Check.xaml"
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
            
            #line 9 "..\..\Check.xaml"
            ((Practoz5.Check)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WindDead);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CheckpleaseTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.DeleteClick = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Check.xaml"
            this.DeleteClick.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddClick = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Check.xaml"
            this.AddClick.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChangeClick = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Check.xaml"
            this.ChangeClick.Click += new System.Windows.RoutedEventHandler(this.Change_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Position = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CategorBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.CheckUpload = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\Check.xaml"
            this.CheckUpload.Click += new System.Windows.RoutedEventHandler(this.Check_Upload);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

