using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleLicenses.Domain.Models;
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
    /// Окно просмотра списка лицензий водителя.
    /// </summary>
    public partial class DriverLicensesWindow : Window
    {
        private int driverId { get; set; }

        public DriverLicensesWindow()
        {
            InitializeComponent();
        }

        public DriverLicensesWindow(int driverId) : this()
        {
            this.driverId = driverId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefershData();
        }

        private void RefershData()
        {
            var driver = PracticeDAO.Context.Drivers.Find(driverId);

            lvLicenses.ItemsSource = driver.Licenses.ToArray().Select(l => new LicenseWithColorMark(l));
            Title = $"Удостоверения водителя {driver.Surname + " " + driver.Name}";
        }
    }
}
