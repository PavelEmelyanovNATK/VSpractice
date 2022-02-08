using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using GAIManagment.ModuleCore.Domain;
using GAIManagment.ModuleStatistic.Domain;
using Microsoft.Win32;
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

namespace GAIManagment.ModuleStatistic.Presentation
{
    /// <summary>
    /// Страница статистики изъятых удостоверений
    /// </summary>
    public partial class TakenLicensesStatisticsPage : Page
    {
        public TakenLicensesStatisticsPage()
        {
            InitializeComponent();

            FillYearsCombobox();
            FillYearsRangeCombobox();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshMonthsTab();

            RefreshYearsTab();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavController.GoBack();
        }

        private void cbYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshMonthsTab();
        }

        private void YearsExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExportYearsCVS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MonthsExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExportMonthsCVS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbStartEndYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshYearsTab();
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

        private void FillYearsRangeCombobox()
        {
            var yearsList = new List<int>();

            for (int i = 1980; i <= DateTime.Now.Year; i++)
            {
                yearsList.Add(i);
            }

            cbStartYear.ItemsSource = yearsList;
            cbEndYear.ItemsSource = yearsList;
            cbStartYear.SelectedItem = 1980;
            cbEndYear.SelectedItem = DateTime.Now.Year;
        }

        private void RefreshMonthsTab()
        {
            var selectedValue = cbYears.SelectedItem as string;
            if (selectedValue == "Все")
            {
                lvMonthsStatistics.ItemsSource = GetAllMonthsStatistics();
            }
            else
            {
                lvMonthsStatistics.ItemsSource = GetMonthsStatisticByYear();
            }
        }

        /// <summary>
        /// Возвращает всю статистику за все года, сортируя её по месяцам.
        /// </summary>
        /// <returns></returns>
        private List<MonthsLicensesStatisticItem> GetAllMonthsStatistics() 
        {
            var newStatistics = new List<MonthsLicensesStatisticItem>();
            var allHistories = PracticeDAO.Context.LicenseStatusHistories.Where(h => h.StatusID == 4);

            var sortedLicenses = new Dictionary<int, List<License>>();
            foreach (var history in allHistories)
            {
                if (!sortedLicenses.Keys.Contains(history.Date.Year))
                    sortedLicenses[history.Date.Year] = new List<License>();
                sortedLicenses[history.Date.Year].Add(history.License);
            }

            foreach (var item in sortedLicenses)
            {
                var statisticItem = new MonthsLicensesStatisticItem { Year = item.Key };

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

        /// <summary>
        /// Возвращает статистику за выбранный год, сортируя её по месяцам.
        /// </summary>
        /// <returns></returns>
        private List<MonthsLicensesStatisticItem> GetMonthsStatisticByYear()
        {
            var newStatistics = new List<MonthsLicensesStatisticItem>();

            var year = Convert.ToInt32(cbYears.SelectedItem);
            var histories = PracticeDAO.Context.LicenseStatusHistories.Where(h => h.Date.Year == year && h.StatusID == 4).ToArray();

            if (histories.Length == 0)
            {
                lvMonthsStatistics.ItemsSource = null;
                return newStatistics;
            }

            var statisticItem = new MonthsLicensesStatisticItem { Year = histories[0].Date.Year };

            foreach (var license in histories)
            {
                if (license.Date.Month == 1)
                    statisticItem.Jan++;
                else if (license.Date.Month == 2)
                    statisticItem.Feb++;
                else if (license.Date.Month == 3)
                    statisticItem.Mar++;
                else if (license.Date.Month == 4)
                    statisticItem.Apr++;
                else if (license.Date.Month == 5)
                    statisticItem.May++;
                else if (license.Date.Month == 6)
                    statisticItem.Jun++;
                else if (license.Date.Month == 7)
                    statisticItem.Jul++;
                else if (license.Date.Month == 8)
                    statisticItem.Aug++;
                else if (license.Date.Month == 9)
                    statisticItem.Sep++;
                else if (license.Date.Month == 10)
                    statisticItem.Oct++;
                else if (license.Date.Month == 11)
                    statisticItem.Nov++;
                else
                    statisticItem.Dec++;
            }

            newStatistics.Add(statisticItem);

            return newStatistics;
        }

        private void ExportYearsCVS()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".CSV|*.csv";
            saveFileDialog.FileName = "driver_license_statistic_by_year";

            if(saveFileDialog.ShowDialog() == true)
            {
                var csvString = "Year;Quantity\n";
                foreach(var item in lvYearsStatistics.Items)
                {
                    var stat = item as YearsLicensesStatisticItem;

                    csvString += stat.Year + ";" + stat.Quantity + '\n';
                }
                File.WriteAllText(saveFileDialog.FileName, csvString);
            }
        }

        private void ExportMonthsCVS()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".CSV|*.csv";
            saveFileDialog.FileName = "driver_license_statistic_by_months";

            if (saveFileDialog.ShowDialog() == true)
            {
                var csvString = "Year;Jun;Feb;Mar;Apr;May;Jun;Jul;Aug;Sep;Oct;Nov;Dec\n";
                foreach (var item in lvMonthsStatistics.Items)
                {
                    var stat = item as MonthsLicensesStatisticItem;

                    csvString += stat.Year + ";" + stat.Jun + ";" + stat.Feb + ";" + stat.Mar + ";" + stat.Apr + ";" + stat.May + ";" + stat.Jun + ";" + stat.Jul + ";" + stat.Aug + ";" + stat.Sep + ";" + stat.Oct + ";" + stat.Nov + ";" + stat.Dec + '\n';
                }
                File.WriteAllText(saveFileDialog.FileName, csvString);
            }
        }

        
        private void RefreshYearsTab()
        {
            int minYear;
            if(cbStartYear.SelectedItem is null)
            {
                minYear = 1980;
            }
            else
            {
                minYear = (int)cbStartYear.SelectedItem;
            }

            int maxYear;
            if (cbEndYear.SelectedItem is null)
            {
                maxYear = DateTime.Now.Year;
            }
            else
            {
                maxYear = (int)cbEndYear.SelectedItem;
            }

            if (minYear > maxYear)
            {
                lvYearsStatistics.ItemsSource = null;
                return;
            }

            //Поиск изъятых удостоверений, входящих
            //в выбранный временной промежуток из истории
            var historyes = PracticeDAO.Context.LicenseStatusHistories.Where(h => h.Date.Year >= minYear && h.Date.Year <= maxYear && h.StatusID == 4).ToArray();

            var sortedHistoryes = new Dictionary<int, int>();
            foreach (var hist in historyes)
            {
                if (!sortedHistoryes.ContainsKey(hist.Date.Year))
                    sortedHistoryes[hist.Date.Year] = 0;
                sortedHistoryes[hist.Date.Year]++;
            }
                
            lvYearsStatistics.ItemsSource = sortedHistoryes.Select(i => new YearsLicensesStatisticItem { Year = i.Key, Quantity = i.Value });
        }
    }
}
