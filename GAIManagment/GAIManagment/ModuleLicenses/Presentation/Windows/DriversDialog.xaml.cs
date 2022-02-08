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
    /// Диаологовое окно выбора водителя.
    /// </summary>
    public partial class DriversDialog : Window
    {
        public DriversDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Открывает диаологовое окно выбора водителя. Возвращает выбранного водителя.
        /// </summary>
        /// <returns></returns>
        public new int ShowDialog()
        {
            base.ShowDialog();

            return (lvDrivers.SelectedItem as Driver)?.ID ?? -1; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDrivers();
        }
        private void RefreshDrivers()
        {
            lvDrivers.ItemsSource = PracticeDAO.Context.Drivers.ToList();
        }
    }
}
