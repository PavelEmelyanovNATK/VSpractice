using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
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
using System.Windows.Shapes;

namespace GAIManagment.ModuleDrivers.Presentation.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditDriverWindow.xaml
    /// </summary>
    public partial class AddEditDriverWindow : Window
    {
        private Driver driver { get; set; }

        private Action action;

        public AddEditDriverWindow()
        {
            InitializeComponent();
        }

        public void OpenForAdd()
        {
            driver = new Driver();

            action = AddAction;

            driver.PostCode = "1";

            btnAction.Content = "Добавить";
            Title = "Добавление водителя";

            this.ShowDialog();
        }

        public void OpenForEdit(Driver driver)
        {
            this.driver = driver;

            action = SaveAction;

            btnAction.Content = "Сохранить";
            Title = "Редактирование информации о водителе";

            tbID.Text = "" + driver.ID;
            tbSurname.Text = driver.Surname;
            tbName.Text = driver.Name;
            tbPatronymic.Text = driver.Patronymic;
            tbPassSeries.Text = driver.PassportSeries;
            tbPassNumber.Text = driver.PassportNumber;
            tbAddress.Text = driver.Address;
            tbAddressLife.Text = driver.AddressLife;
            tbCompany.Text = driver.Company;
            tbJobName.Text = driver.JobName;
            tbPhone.Text = driver.Phone;
            tbEmail.Text = driver.Email;
            tbDescription.Text = driver.Description;

            imgPhoto.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + $"/DriversPhotos/{driver.PhotoPath}"));
            imgPhoto.Tag = driver.PhotoPath;

            this.ShowDialog();
        }

        private void FillDriverInfo()
        {
            driver.Surname = tbSurname.Text;
            driver.Name = tbName.Text;
            driver.Patronymic = tbPatronymic.Text;
            driver.PassportSeries = tbPassSeries.Text;
            driver.PassportNumber = tbPassSeries.Text;
            driver.Address = tbAddress.Text;
            driver.AddressLife = tbAddressLife.Text;
            driver.Company = tbCompany.Text;
            driver.JobName = tbJobName.Text;
            driver.Phone = tbPhone.Text;
            driver.Email = tbEmail.Text;
            driver.PhotoPath = (imgPhoto.Tag as string) ?? "";
            driver.Description = tbDescription.Text;
        }

        private void SaveAction()
        {
            try
            {
                var image = imgPhoto.Source as BitmapImage;
                var imgName = imgPhoto.Tag as string;
                var dir = image.UriSource.OriginalString;

                //Если фотография не изменилась, то ничего не делаем
                if (dir.Remove(dir.Length - 1 - imgName.Length) != Environment.CurrentDirectory + "/DriversPhotos")
                    File.Copy(image.UriSource.OriginalString, Environment.CurrentDirectory + $"/DriversPhotos/{image.UriSource.Segments.Last()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Фото с таким названием уже существует!");
            }

            FillDriverInfo();

            PracticeDAO.Context.SaveChanges();
        }

        private void AddAction()
        {
            try
            {
                var image = imgPhoto.Source as BitmapImage;
                File.Copy(image.UriSource.OriginalString, Environment.CurrentDirectory + $"/DriversPhotos/{image.UriSource.Segments.Last()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Фото с таким названием уже существует!");
            }

            FillDriverInfo();

            PracticeDAO.Context.Drivers.Add(driver);
            PracticeDAO.Context.SaveChanges();
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                action?.Invoke();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPickPhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                var image = new BitmapImage(new Uri(openFileDialog.FileName));

                if (!Check34Res((int)image.Height, (int)image.Width))
                {
                    MessageBox.Show("Неверное соотношение сторон! Соотношение сторон должно быть 3:4!");
                    return;
                }

                imgPhoto.Source = image;
                imgPhoto.Tag = openFileDialog.SafeFileName;
            }
        }

        private bool Check34Res(int height, int width)
        {
            return height % 4 == 0 && width % 3 == 0 && height / 4 == width / 3;
        }
    }
}
