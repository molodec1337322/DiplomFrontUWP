using DiplomFrontUWP.Pages;
using DiplomFrontUWP.Utils;
using DiplomFrontUWP.Utils.Interfaces;
using DiplomFrontUWP.Utils.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace DiplomFrontUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IAPIWorker _apiWorker;

        public MainPage()
        {
            this.InitializeComponent();
            _apiWorker = new APIWorker();
            GetInitPortData();
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 1024); 
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void GetInitPortData()
        {
            SettingsData.COMPorts = await _apiWorker.GetAvaliableUSBPorts();
            if (SettingsData.COMPorts.Count > 0)
            {
                SettingsData.SelectedComPort = SettingsData.COMPorts[0].port;
            }
        }


        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        private void Button_Experiments(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Experiments));
        }

        private void Button_History(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(History));
        }

        private void Button_Analyzators(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Analyzators));
        }

        private void Button_DoExperiment(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DoExperiment));
        }
    }
}
