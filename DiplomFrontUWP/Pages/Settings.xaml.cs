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

namespace DiplomFrontUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Settings : Page
    {
        IAPIWorker _apiWorker;
        public Settings()
        {
            this.InitializeComponent();
            _apiWorker = new APIWorker();
            GetInitSettingsData();
        }

        private async void GetInitSettingsData()
        {
            SettingsData.COMPorts = await _apiWorker.GetAvaliableUSBPorts();
            if (SettingsData.COMPorts.Count > 0)
            {
                SettingsData.SelectedComPort = SettingsData.COMPorts[0].port;
                foreach (USBPortsResponse avaliablePort in SettingsData.COMPorts)
                {
                    ArduinoPortComboBox.Items.Add(avaliablePort.port);
                }
                ArduinoPortComboBox.SelectedValue = SettingsData.SelectedComPort;
            }
        }

        private void Button_ToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void ArduinoPortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingsData.SelectedComPort = ArduinoPortComboBox.SelectedValue.ToString();
        }
    }
}
