using GAIManagment.ModuleCore.Domain;
using GAIManagment.ModuleDrivers.Presentation.Pages;
using GAIManagment.ModuleLicenses.Presentation.Pages;
using GAIManagment.ModuleStatistic.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAIManagment.ModuleMainMenu.Presentation.Pages
{
    /// <summary>
    /// Страница главного меню.
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void DriversButton_Click(object sender, RoutedEventArgs e)
        {
            NavController.Navigate(new DriversPage());
        }

        private void LicensesButton_Click(object sender, RoutedEventArgs e)
        {
            NavController.Navigate(new LicensesPage());
        }

        private void GivenLicensesStatistics_Click(object sender, RoutedEventArgs e)
        {
            NavController.Navigate(new GivenLicensesStatistics());
        }

        private void TakenLicensesStatistics_Click(object sender, RoutedEventArgs e)
        {
            NavController.Navigate(new TakenLicensesStatisticsPage());
        }
    }
}
