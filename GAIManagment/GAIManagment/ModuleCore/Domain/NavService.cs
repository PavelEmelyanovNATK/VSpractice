using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GAIManagment.ModuleCore.Domain
{
    public class NavService
    {
        private static Frame frameMain;

        public static void Setup(Frame frame)
        {
            frameMain = frame;
        }

        public static void SetPage(Page page)
        {
            frameMain.Navigate(page);

            while (frameMain.CanGoBack)
                frameMain.RemoveBackEntry();
        }
        public static void Navigate(Page page)
        {
            frameMain.Navigate(page);
        }

        public static void GoBack()
        {
            if (frameMain.CanGoBack)
                frameMain.GoBack();
        }
    }
}
