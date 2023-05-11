using DiplomFrontUWP.Utils;
using DiplomFrontUWP.Utils.Interfaces;
using DiplomFrontUWP.Utils.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
            experiments = await _apiWorker.GetSchemasList();
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

            startExperiment.IsEnabled = false;
            toMainPageBtn.IsEnabled = false;
            ExperimentChooseComboBox.IsEnabled = false;

            var res = await _apiWorker.StartExperiment(SettingsData.SelectedComPort, splittedExperimentData[0], splittedExperimentData[1], splittedExperimentData[2], splittedExperimentData[3]);

            if(res.Contains("videoRecordOk"))
            {
                var okCommand = new UICommand("Ok", cmd => { });

                var dialog = new MessageDialog("Запись эксперемента произведена успешно!", "Завершено");
                dialog.Options = MessageDialogOptions.None;
                dialog.Commands.Add(okCommand);
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 0;

                var command = await dialog.ShowAsync();
            }
            else
            {
                var okCommand = new UICommand("Ok", cmd => { Frame.Navigate(typeof(MainPage)); });

                var dialog = new MessageDialog(res, "Ошибка!");
                dialog.Options = MessageDialogOptions.None;
                dialog.Commands.Add(okCommand);
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 0;

                var command = await dialog.ShowAsync();
            }

            startExperiment.IsEnabled = true;
            toMainPageBtn.IsEnabled = true;
            ExperimentChooseComboBox.IsEnabled = true;


        }

    }
}
