﻿#pragma checksum "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "48BACC9A2282B0326E9671DDB9CAF36A7E0709BBAFB9D5110EB496DC7A68DA41"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GAIManagment.ModuleStatistic.Presentation;
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


namespace GAIManagment.ModuleStatistic.Presentation {
    
    
    /// <summary>
    /// GivenLicensesStatistics
    /// </summary>
    public partial class GivenLicensesStatistics : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbYears;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvLicenses;
        
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
            System.Uri resourceLocater = new System.Uri("/GAIManagment;component/modulestatistic/presentation/givenlicensesstatiscs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml"
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
            
            #line 10 "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml"
            ((GAIManagment.ModuleStatistic.Presentation.GivenLicensesStatistics)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 20 "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbYears = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\..\ModuleStatistic\Presentation\GivenLicensesStatiscs.xaml"
            this.cbYears.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbYears_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lvLicenses = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
