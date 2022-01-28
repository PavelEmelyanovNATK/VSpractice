using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using GAIManagment.ModuleCore.Domain.Utils;
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
using System.Windows.Shapes;

namespace GAIManagment.ModuleLicenses.Presentation.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegLicenseWindow.xaml
    /// </summary>
    public partial class RegLicenseWindow : Window
    {
        private Driver driver;
        public RegLicenseWindow()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            var categoryDialog = new CategoryDialog();
            string category = categoryDialog.ShowDialog();

            if (category is null) return;
            if (tbCategories.Text.Contains(category)) return;

            var categoriesList = tbCategories.Text.Replace(" ","").Split(',').ToList();
            categoriesList.Remove("");
            categoriesList.Add(category);
            categoriesList.Sort();

            string newCategosies = "";
            foreach(var c in categoriesList)
            {
                newCategosies += c + ", ";
            }

            newCategosies = newCategosies.Remove(newCategosies.Length - 2);
            tbCategories.Text = newCategosies;
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Register();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            DriversDialog driversDialog = new DriversDialog();
            int driverId = driversDialog.ShowDialog();

            if (driverId == -1) return;
            driver = PracticeDAO.Context.Drivers.Find(driverId);
            tbDriver.Text = driver.Surname + " " + driver.Name + " " + driver.Patronymic;
        }

        private void Register()
        {
            if (dpExpire.SelectedDate is null)
            {
                MessageBox.Show("Вы не выбрали дату истечения!");
                return;
            }

            var license = new License();

            license.Categories = tbCategories.Text;
            license.Driver = driver;
            license.ExpireDate = dpExpire.SelectedDate ?? DateTime.Now;
            license.LicenceDate = DateTime.Now;
            license.LicenseSeries = tbSeries.Text;
            license.LicenseNumber = tbNumber.Text;
            license.SetStatus(PracticeDAO.Context.Status.Find(1), "Регистрация");

            PracticeDAO.Context.Licenses.Add(license);
            PracticeDAO.Context.SaveChanges();
        }
    }
}
