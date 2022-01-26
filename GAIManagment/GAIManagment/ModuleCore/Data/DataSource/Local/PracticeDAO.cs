using GAIManagment.ModuleCore.Data.DataSource.Local.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIManagment.ModuleCore.Data.DataSource.Local
{
    public class PracticeDAO
    {
        private static VSpracticeEntities _dao;
        public static VSpracticeEntities Context
        {
            get => _dao;
        }
        public static void Refresh()
        {
            _dao = new VSpracticeEntities();
        }
    }
}
