using DiplomFrontUWP.Pages;
using DiplomFrontUWP.Utils;
using DiplomFrontUWP.Utils.Interfaces;
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
