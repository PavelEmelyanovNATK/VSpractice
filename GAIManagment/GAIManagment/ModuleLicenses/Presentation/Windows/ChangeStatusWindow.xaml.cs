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
    /// Логика взаимодействия для ChangeStatusWindow.xaml
    /// </summary>
    public partial class ChangeStatusWindow : Window
    {
        int licenseId;
        public ChangeStatusWindow()
        {
            InitializeComponent();
        }

        public ChangeStatusWindow(int licenseId) : this()
        {
            this.licenseId = licenseId;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (cbStatuses.SelectedItem is null)
            {
                MessageBox.Show("Вы не выбрали статус!");
                return;
            }
            try
            {
                ChangeStatus();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshStatuses();
        }

        private void RefreshStatuses()
        {
            cbStatuses.ItemsSource = PracticeDAO.Context.Status.ToArray();
        }

        private void ChangeStatus()
        {
            var license = PracticeDAO.Context.Licenses.Find(licenseId);
            license.SetStatus(cbStatuses.SelectedItem as Status, tbDescription.Text);
            PracticeDAO.Context.SaveChanges();
        }
    }
}
