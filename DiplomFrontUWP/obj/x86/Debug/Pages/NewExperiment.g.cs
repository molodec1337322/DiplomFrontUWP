﻿#pragma checksum "C:\Users\Molodec\source\repos\DiplomFrontUWP\DiplomFrontUWP\Pages\NewExperiment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9C24DD7A455C753B8EA27367D1F2DBA349600DEB5901152FF00DAC1B8D59E2C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomFrontUWP.Pages
{
    partial class NewExperiment : 
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
            case 2: // Pages\NewExperiment.xaml line 12
                {
                    this.cancelNewExperiment = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.cancelNewExperiment).Click += this.Button_cancel;
                }
                break;
            case 3: // Pages\NewExperiment.xaml line 13
                {
                    this.saveNewExperiment = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.saveNewExperiment).Click += this.Button_save;
                }
                break;
            case 4: // Pages\NewExperiment.xaml line 15
                {
                    this.ExperimentDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Pages\NewExperiment.xaml line 17
                {
                    this.ExperimentSide7 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Pages\NewExperiment.xaml line 18
                {
                    this.ExperimentSide0 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Pages\NewExperiment.xaml line 19
                {
                    this.ExperimentSide1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Pages\NewExperiment.xaml line 21
                {
                    this.ExperimentSide6 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\NewExperiment.xaml line 22
                {
                    this.ExperimentSide2 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // Pages\NewExperiment.xaml line 24
                {
                    this.ExperimentSide5 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // Pages\NewExperiment.xaml line 25
                {
                    this.ExperimentSide4 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // Pages\NewExperiment.xaml line 26
                {
                    this.ExperimentSide3 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // Pages\NewExperiment.xaml line 28
                {
                    this.ExperimentIsSavePreviousResults = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
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

