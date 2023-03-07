using DiplomFrontUWP.Utils;
using DiplomFrontUWP.Utils.Interfaces;
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
        private IAPIWorker apiWorker;

        public DoExperiment()
        {
            apiWorker = new APIWorker();
            this.InitializeComponent();
        }
        private void Button_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void Button_StartExperiment(object sender, RoutedEventArgs e)
        {
            var res = await apiWorker.GetTest();

            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Response",
                Content = res,
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }

        
    }
}
