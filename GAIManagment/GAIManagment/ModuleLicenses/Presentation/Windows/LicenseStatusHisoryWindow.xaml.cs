using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
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
    /// Окно просмотра истории изменения статусов удосоверения.
    /// </summary>
    public partial class LicenseStatusHisoryWindow : Window
    {
        private int licenseId { get; set; }
        public LicenseStatusHisoryWindow()
        {
            InitializeComponent();
        }

        public LicenseStatusHisoryWindow(int licenseId) : this()
        {
            this.licenseId = licenseId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var license = PracticeDAO.Context.Licenses.Find(licenseId);
            Title = $"История изменения статусов лицензии {license.LicenseSeries} {license.LicenseNumber}";
            lvHistory.ItemsSource = license.LicenseStatusHistories.ToArray();
        }
    }
}
