﻿#pragma checksum "C:\Users\Molodec\source\repos\DiplomFrontUWP\DiplomFrontUWP\Pages\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C3EE0AAF66E5F2B521E5CE2D58A0BDF366A7FB6BDCDE938ACA41C92D139D0536"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomFrontUWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\MainPage.xaml line 13
                {
                    this.settingsBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.settingsBtn).Click += this.Button_Settings;
                }
                break;
            case 3: // Pages\MainPage.xaml line 14
                {
                    this.experimentsBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.experimentsBtn).Click += this.Button_Experiments;
                }
                break;
            case 4: // Pages\MainPage.xaml line 15
                {
                    this.historyBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.historyBtn).Click += this.Button_History;
                }
                break;
            case 5: // Pages\MainPage.xaml line 16
                {
                    this.doExperimentBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.doExperimentBtn).Click += this.Button_DoExperiment;
                }
                break;
            case 6: // Pages\MainPage.xaml line 17
                {
                    this.analyzatorsBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.analyzatorsBtn).Click += this.Button_Analyzators;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
