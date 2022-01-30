using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using GAIManagment.ModuleCore.Domain;
using GAIManagment.ModuleStatistic.Domain;
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

namespace GAIManagment.ModuleStatistic.Presentation
{
    /// <summary>
    /// Логика взаимодействия для GivenLicensesStatiscs.xaml
    /// </summary>
    public partial class GivenLicensesStatistics : Page
    {
        public GivenLicensesStatistics()
        {
            InitializeComponent();

            FillYearsCombobox();
        }

        private void FillYearsCombobox()
        {
            var yearsList = new List<String>();
            yearsList.Add("Все");

            for (int i = 1980; i <= DateTime.Now.Year; i++)
            {
                yearsList.Add(i.ToString());
            }

            cbYears.ItemsSource = yearsList;
            cbYears.SelectedItem = "Все";
        }

        private void RefreshStatistics()
        {
            var newStatistics = new List<GivenLicensesStatisticItem>();
            var selectedValue = cbYears.SelectedItem as String;

            if (selectedValue == "Все")
            {
                lvLicenses.ItemsSource = GetAllStatistics();
            }
            else
            {
                lvLicenses.ItemsSource = GetStatisticByYear();
            }
        }

        private List<GivenLicensesStatisticItem> GetAllStatistics()
        {
            var newStatistics = new List<GivenLicensesStatisticItem>();
            var allLicenses = PracticeDAO.Context.Licenses.ToArray();

            var sortedLicenses = new Dictionary<int, List<License>>();
            foreach (var license in allLicenses)
            {
                if (!sortedLicenses.Keys.Contains(license.LicenceDate.Year))
                    sortedLicenses[license.LicenceDate.Year] = new List<License>();
                sortedLicenses[license.LicenceDate.Year].Add(license);
            }

            foreach (var item in sortedLicenses)
            {
                var statisticItem = new GivenLicensesStatisticItem { Year = item.Key };

                foreach (var license in item.Value)
                {
                    if (license.LicenceDate.Month == 1)
                        statisticItem.Jan++;
                    else if (license.LicenceDate.Month == 2)
                        statisticItem.Feb++;
                    else if (license.LicenceDate.Month == 3)
                        statisticItem.Mar++;
                    else if (license.LicenceDate.Month == 4)
                        statisticItem.Apr++;
                    else if (license.LicenceDate.Month == 5)
                        statisticItem.May++;
                    else if (license.LicenceDate.Month == 6)
                        statisticItem.Jun++;
                    else if (license.LicenceDate.Month == 7)
                        statisticItem.Jul++;
                    else if (license.LicenceDate.Month == 8)
                        statisticItem.Aug++;
                    else if (license.LicenceDate.Month == 9)
                        statisticItem.Sep++;
                    else if (license.LicenceDate.Month == 10)
                        statisticItem.Oct++;
                    else if (license.LicenceDate.Month == 11)
                        statisticItem.Nov++;
                    else
                        statisticItem.Dec++;
                }

                newStatistics.Add(statisticItem);
            }

            return newStatistics;
        }

        private List<GivenLicensesStatisticItem> GetStatisticByYear()
        {
            var newStatistics = new List<GivenLicensesStatisticItem>();

            var year = Convert.ToInt32(cbYears.SelectedItem);
            var licenses = PracticeDAO.Context.Licenses.Where(l => l.LicenceDate.Year == year).ToArray();

            if (licenses.Length == 0)
            {
                lvLicenses.ItemsSource = null;
                return newStatistics;
            }

            var statisticItem = new GivenLicensesStatisticItem { Year = licenses[0].LicenceDate.Year };

            foreach (var license in licenses)
            {
                if (license.LicenceDate.Month == 1)
                    statisticItem.Jan++;
                else if (license.LicenceDate.Month == 2)
                    statisticItem.Feb++;
                else if (license.LicenceDate.Month == 3)
                    statisticItem.Mar++;
                else if (license.LicenceDate.Month == 4)
                    statisticItem.Apr++;
                else if (license.LicenceDate.Month == 5)
                    statisticItem.May++;
                else if (license.LicenceDate.Month == 6)
                    statisticItem.Jun++;
                else if (license.LicenceDate.Month == 7)
                    statisticItem.Jul++;
                else if (license.LicenceDate.Month == 8)
                    statisticItem.Aug++;
                else if (license.LicenceDate.Month == 9)
                    statisticItem.Sep++;
                else if (license.LicenceDate.Month == 10)
                    statisticItem.Oct++;
                else if (license.LicenceDate.Month == 11)
                    statisticItem.Nov++;
                else
                    statisticItem.Dec++;
            }

            newStatistics.Add(statisticItem);

            return newStatistics;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavController.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshStatistics();
        }

        private void cbYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshStatistics();
        }
    }
}
