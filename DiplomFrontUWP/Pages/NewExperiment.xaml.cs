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
                "0", "1", "2", "3", "4", "5", "6", "7"
            };

            foreach (string str in strs)
            {
                ExperimentSideComboBox.Items.Add(str);
            }

            ExperimentSideComboBox.SelectedIndex = 0;
        }

        private void Button_cancel(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Experiments));
        }

        private async void Button_save(object sender, RoutedEventArgs e)
        {
            if(ExperimentDescription.Text != "" && ExperimentDeformation.Text != "" && ExperimentDirection.Text != "" && ExperimentPauseDuration.Text != "")
            {
                int direction = Int32.Parse(ExperimentDirection.Text);
                int deformation = Int32.Parse(ExperimentDeformation.Text);
                int pauseDuration = Int32.Parse(ExperimentPauseDuration.Text);

                if(direction > -1 && direction < 1000 && deformation > -1 && deformation < 4095 && pauseDuration > -1 && pauseDuration < 5000)
                {
                    string resultText;
                    if (ExperimentSideComboBox.SelectedValue != "Нет")
                    {
                        resultText = direction + " " + deformation + " " + pauseDuration + " " + ExperimentSideComboBox.SelectedValue.ToString();
                    }
                    else
                    {
                        resultText = direction + " " + deformation + " " + pauseDuration + " " + -1;
                    }
                    var res = await _apiWorker.PutNewExperiment(ExperimentDescription.Text, resultText);
                    Frame.Navigate(typeof(Experiments));
                }
            }
            else
            {
                
            }
        }
    }
}
