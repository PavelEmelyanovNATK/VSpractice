using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GAIManagment.ModuleLicenses.Domain.Models
{
    public class LicenseWithColorMark : License
    {
        public LicenseWithColorMark(License license)
        {
            this.ID = license.ID;
            this.LicenceDate = license.LicenceDate;
            this.ExpireDate = license.ExpireDate;
            this.Categories = license.Categories;
            this.Driver = license.Driver;
            this.LicenseSeries = license.LicenseSeries;
            this.LicenseNumber = license.LicenseNumber;
            this.LicenseStatusHistories = license.LicenseStatusHistories;
            this.Status = license.Status;
            this.StatusID = license.StatusID;
        }

        public Brush Color { 
            get
            {
                if (StatusID == 2 || StatusID == 4)
                    return new SolidColorBrush(Colors.Red);
                else if(StatusID == 3)
                    return new SolidColorBrush(Colors.Gray);

                return new SolidColorBrush(Colors.Green);
            } 
        }
    }
}
