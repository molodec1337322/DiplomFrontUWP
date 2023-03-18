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
    public sealed partial class Experiments : Page
    {
        private IAPIWorker _apiWorker;
        List<ExperimentResponse> experiments;

        public Experiments()
        {
            _apiWorker = new APIWorker();
            GetData();
            this.InitializeComponent();
        }

        private async void GetData()
        {
            experiments = await _apiWorker.GetExperimentsList();
            foreach(ExperimentResponse experiment in experiments)
            {
                experimentsList.Items.Add(experiment);
            }
        }

        private void Button_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_CreateNewExperiment(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewExperiment));
        }
    }
}
