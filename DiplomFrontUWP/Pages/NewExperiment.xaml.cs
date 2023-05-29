using DiplomFrontUWP.Utils;
using DiplomFrontUWP.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiplomFrontUWP.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NewExperiment : Page
    {
        private IAPIWorker _apiWorker;
        private string saveVideoPath;

        public NewExperiment()
        {
            this.InitializeComponent();
            _apiWorker = new APIWorker();
            ExperimentSideComboBoxInit();
        }

        public void ExperimentSideComboBoxInit()
        {
            List<string> strs = new List<string>
            {
                "Нет",
                "Да"
            };

            foreach (string str in strs)
            {
                ExperimentIsSavePreviousResults.Items.Add(str);
            }

            ExperimentIsSavePreviousResults.SelectedIndex = 0;
        }

        private void Button_cancel(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Experiments));
        }

        private async void Button_save(object sender, RoutedEventArgs e)
        {
            List<string> SideDeformationStrings = new List<string>
            {
                ExperimentSide0.Text,
                ExperimentSide1.Text,
                ExperimentSide2.Text,
                ExperimentSide3.Text,
                ExperimentSide4.Text,
                ExperimentSide5.Text,
                ExperimentSide6.Text,
                ExperimentSide7.Text
            };

            if (ExperimentDescription.Text != "" && IsSideDeformationsStringsNotEmpty(SideDeformationStrings))
            {
                if(IsSideDeformationsStringsValInScope(SideDeformationStrings))
                {
                    string resultText;
                    if (ExperimentIsSavePreviousResults.SelectedValue != "Нет")
                    {
                        resultText = GetSideDeformationsStringAsOneString(SideDeformationStrings) + 0;
                    }
                    else
                    {
                        resultText = GetSideDeformationsStringAsOneString(SideDeformationStrings) + 1;
                    }
                    var res = await _apiWorker.PutNewExperiment(ExperimentDescription.Text, resultText);
                    Frame.Navigate(typeof(Experiments));
                }
            }
            else
            {
                
            }
        }

        private bool IsSideDeformationsStringsNotEmpty(List<string> list)
        {
            foreach(string str in list)
            {
                if(str == "")
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSideDeformationsStringsValInScope(List<string> list)
        {
            foreach (string val in list)
            {
                int intVal = Int32.Parse(val);
                if (intVal < -4096 || intVal > 4096)
                {
                    return false;
                }
            }
            return true;
        }

        private string GetSideDeformationsStringAsOneString(List<string> list)
        {
            string resultString = "";
            foreach(string val in list)
            {
                resultString += val + " ";
            }
            return resultString;
        }
    }
}
