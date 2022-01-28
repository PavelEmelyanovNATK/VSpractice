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
    /// Логика взаимодействия для LicenseStatusHisoryWindow.xaml
    /// </summary>
    public partial class LicenseStatusHisoryWindow : Window
    {
        IEnumerable<LicenseStatusHistory> history;
        public LicenseStatusHisoryWindow()
        {
            InitializeComponent();
        }

        public LicenseStatusHisoryWindow(IEnumerable<LicenseStatusHistory> history) : this()
        {
            this.history = history;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvHistory.ItemsSource = history;
        }
    }
}
