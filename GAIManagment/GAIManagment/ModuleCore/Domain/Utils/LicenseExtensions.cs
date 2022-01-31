using GAIManagment.ModuleCore.Data.DataSource.Local;
using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIManagment.ModuleCore.Domain.Utils
{
    public static class LicenseExtensions
    {
        /// <summary>
        /// Устанавливает статус лицензии и записывает это в историю.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="status">Статус</param>
        /// <param name="description">Комментарий</param>
        public static void SetStatus(this License self, Status status, String description)
        {
            self.Status = status;
            PracticeDAO.Context.LicenseStatusHistories.Add(new LicenseStatusHistory
            {
                License = self,
                Status = status,
                Description = description,
                Date = DateTime.Now
            });
        }
    }
}
