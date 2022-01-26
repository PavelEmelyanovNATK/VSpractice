using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using GAIManagment.ModuleCore.Domain;
using GAIManagment.ModuleDrivers.Presentation.Windows;
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
    /// Логика взаимодействия для DriversPage.xaml
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
            NavService.GoBack();
        }


        void RefreshDrivers()
        {
            lvDrivers.ItemsSource = PracticeDAO.Context.Drivers.ToList();
        }

        void DisableEditButtons()
        {
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        void EnableEditButtons()
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
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

        void OpenDriver()
        {
            var addEditWin = new AddEditDriverWindow();

            addEditWin.OpenForEdit(lvDrivers.SelectedItem as Driver);

            RefreshDrivers();
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
            try
            {
                PracticeDAO.Context.Drivers.Remove(lvDrivers.SelectedItem as Driver);
                PracticeDAO.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RefreshDrivers();
        }
    }
}
