using DiplomFrontUWP.Utils;
using DiplomFrontUWP.Utils.Interfaces;
using DiplomFrontUWP.Utils.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class DoExperiment : Page
    {
        private IAPIWorker _apiWorker;
        List<SchemaResponse> experiments;

        public DoExperiment()
        {
            this.InitializeComponent();
            _apiWorker = new APIWorker();
            ExperimentChooseComboBoxInit();
        }

        private async void ExperimentChooseComboBoxInit()
        {
            experiments = await _apiWorker.GetExperimentsList();
            foreach (SchemaResponse experiment in experiments)
            {
                List<string> dateStr = experiment.createdAt.Split('T').ToList();
                experiment.createdAt = dateStr[0] + " " + dateStr[1].Substring(0, dateStr[1].LastIndexOf(":"));
                ExperimentChooseComboBox.Items.Add(experiment.description + " Создан: " + experiment.createdAt);
            }
        }

        private void Button_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void Button_StartExperiment(object sender, RoutedEventArgs e)
        {
            SchemaResponse schema = experiments[ExperimentChooseComboBox.SelectedIndex];
            List<string> splittedExperimentData = schema.text.Split(" ").ToList();
            var res = await _apiWorker.StartExperimant(SettingsData.SelectedComPort, splittedExperimentData[0], splittedExperimentData[1], splittedExperimentData[2], splittedExperimentData[3]);

            Frame.Navigate(typeof(MainPage));
        }

    }
}
