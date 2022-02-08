using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using GAIManagment.ModuleCore.Domain;
using GAIManagment.ModuleDrivers.Presentation.Windows;
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

namespace GAIManagment.ModuleDrivers.Presentation.Pages
{
    /// <summary>
    /// Главная страница модуля водителей.
    /// </summary>
    public partial class DriversPage : Page
    {
        public DriversPage()
        {
            InitializeComponent();
            DisableEditButtons();
            RefreshDrivers();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DisableEditButtons();
            RefreshDrivers();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavController.GoBack();
        }

        private void lvDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDrivers.SelectedItems.Count > 0)
            {
                EnableEditButtons();
            }
            else
            {
                DisableEditButtons();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addEditWin = new AddEditDriverWindow();

            addEditWin.OpenForAdd();

            RefreshDrivers();
        }

        private void lvDrivers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenDriver();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenDriver();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    DeleteDriver();
                }
                catch (Exception ex)
                {
                    PracticeDAO.Refresh();
                    MessageBox.Show(ex.Message);
                }
            }

            RefreshDrivers();
        }

        private void btnLicenses_Click(object sender, RoutedEventArgs e)
        {
            var licensesWindow = new DriverLicensesWindow((lvDrivers.SelectedItem as Driver).ID);
            licensesWindow.Show();
        }

        void RefreshDrivers()
        {
            lvDrivers.ItemsSource = PracticeDAO.Context.Drivers.ToList();
        }

        void DisableEditButtons()
        {
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnLicenses.IsEnabled = false;
        }

        void EnableEditButtons()
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnLicenses.IsEnabled = true;
        }

        void OpenDriver()
        {
            var addEditWin = new AddEditDriverWindow();

            addEditWin.OpenForEdit(lvDrivers.SelectedItem as Driver);

            RefreshDrivers();
        }

        private void DeleteDriver()
        {
            var driver = lvDrivers.SelectedItem as Driver;
            driver?.Licenses.Clear();
            PracticeDAO.Context.Drivers.Remove(driver);
            PracticeDAO.Context.SaveChanges();
        }
    }
}
