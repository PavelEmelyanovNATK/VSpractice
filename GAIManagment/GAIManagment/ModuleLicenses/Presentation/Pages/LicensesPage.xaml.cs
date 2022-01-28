using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using GAIManagment.ModuleCore.Domain;
using GAIManagment.ModuleLicenses.Domain.Models;
using GAIManagment.ModuleLicenses.Presentation.Windows;
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

namespace GAIManagment.ModuleLicenses.Presentation.Pages
{
    /// <summary>
    /// Логика взаимодействия для LicensesPage.xaml
    /// </summary>
    public partial class LicensesPage : Page
    {
        public LicensesPage()
        {
            InitializeComponent();

            DisableButtons();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshLicenses();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavController.GoBack();
        }

        private void lvDrivers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        void RefreshLicenses()
        {
            lvLicenses.ItemsSource = PracticeDAO.Context.Licenses.ToArray().Select(item => new LicenseWithColorMark(item));
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            var regLicenseWindow = new RegLicenseWindow();
            regLicenseWindow.ShowDialog();
            RefreshLicenses();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenHistory();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            OpenHistory();
        }

        private void OpenHistory()
        {
            var selectedLicense = lvLicenses.SelectedItem as License;
            var historyWindow = new LicenseStatusHisoryWindow(selectedLicense.LicenseStatusHistories);

            historyWindow.Show();
        }

        private void DisableButtons()
        {
            btnHistory.IsEnabled = false;
            btnChangeStatus.IsEnabled = false;
        }

        private void EnableButtons()
        {
            btnHistory.IsEnabled = true;
            btnChangeStatus.IsEnabled = true;
        }

        private void lvLicenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvLicenses.SelectedItems.Count > 0)
            {
                EnableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void btnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            OpenChangeStatus();
        }

        private void OpenChangeStatus()
        {
            var changeStatusWindow = new ChangeStatusWindow((lvLicenses.SelectedItem as License).ID);
            changeStatusWindow.ShowDialog();
        }
    }
}
