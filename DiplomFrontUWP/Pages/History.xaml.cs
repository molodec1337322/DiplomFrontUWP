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
    public sealed partial class History : Page
    {

        IAPIWorker _apiWorker;
        List<ExperimentResponse> experiments;
        List<string> analyzators;

        public History()
        {
            this.InitializeComponent();
            _apiWorker = new APIWorker();
            GetData();
        }

        private void Button_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void ExperimentsHistoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AnalyzatorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Button_Analyze(object sender, RoutedEventArgs e)
        {
            var res = await _apiWorker.AnalyzeExperement(Int32.Parse(ExperimentsHistoryList.SelectedValue.ToString().Split(" ")[1].Replace("№", "")), AnalyzatorComboBox.SelectedValue.ToString());

            if (res.Contains("analyzeOk"))
            {
                var okCommand = new UICommand("Ok", cmd => { });

                var dialog = new MessageDialog("Анализ эксперемента произведен успешно!", "Завершено!");
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
        }

        private async void GetData()
        {
            experiments = await _apiWorker.GetExperimentsHistoryList();
            analyzators = await _apiWorker.GetAnalyzatorsList();

            foreach (ExperimentResponse experiment in experiments)
            {
                List<string> dateStartedStr = experiment.startedAt.Split('T').ToList();
                List<string> dateEndedStr = experiment.endedAt.Split('T').ToList();
                experiment.startedAt = dateStartedStr[0] + " " + dateStartedStr[1].Substring(0, dateStartedStr[1].LastIndexOf(":"));
                experiment.endedAt = dateEndedStr[0] + " " + dateEndedStr[1].Substring(0, dateEndedStr[1].LastIndexOf(":"));

                if(experiment.resultPath != null && experiment.resultPath != "" && experiment.resultPath != " ")
                {
                    ExperimentsHistoryList.Items.Add("Эксперемент №" + experiment.Id + " Начат: " + experiment.startedAt + " Закончен: " + experiment.endedAt + " Проанализировано");
                }
                else
                {
                    ExperimentsHistoryList.Items.Add("Эксперемент №" + experiment.Id + " Начат: " + experiment.startedAt + " Закончен: " + experiment.endedAt);
                }
            }

            foreach (string analyzator in analyzators)
            {
                AnalyzatorComboBox.Items.Add(analyzator);
            }
            

            ExperimentsHistoryList.Items.Reverse();
        }
    }
}
