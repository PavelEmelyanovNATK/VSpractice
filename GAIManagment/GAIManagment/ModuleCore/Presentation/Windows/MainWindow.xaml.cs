using GAIManagment.ModuleAuth.Presentation.Pages;
using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GAIManagment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PracticeDAO.Refresh();
            NavController.Setup(frameMain);
            NavController.SetPage(new AuthPage());
        }
    }
}
