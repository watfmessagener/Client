﻿#pragma checksum "..\..\UserControl1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "900CC3A851E8BA9E7E5409008DC8BCEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using UserChat;


namespace UserChat {
    
    
    /// <summary>
    /// Userchat
    /// </summary>
    public partial class Userchat : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label indicatorOnline;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label indicatorOffline;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bcall;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Avatar;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FirstName;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MessageList;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewmessageBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bsend;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bsmile;
        
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
            System.Uri resourceLocater = new System.Uri("/UserChat;component/usercontrol1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControl1.xaml"
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
            this.indicatorOnline = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.indicatorOffline = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Bcall = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Avatar = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.FirstName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.MessageList = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\UserControl1.xaml"
            this.MessageList.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.MessageList_TextChanged);
            
            #line default
            #line hidden
            
            #line 44 "..\..\UserControl1.xaml"
            this.MessageList.KeyDown += new System.Windows.Input.KeyEventHandler(this.MessageList_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NewmessageBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\UserControl1.xaml"
            this.NewmessageBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.NewmessageBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Bsend = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\UserControl1.xaml"
            this.Bsend.Click += new System.Windows.RoutedEventHandler(this.Bsend_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Bsmile = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\UserControl1.xaml"
            this.Bsmile.Click += new System.Windows.RoutedEventHandler(this.Bsmile_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 20 "..\..\UserControl1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.PART_message_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

