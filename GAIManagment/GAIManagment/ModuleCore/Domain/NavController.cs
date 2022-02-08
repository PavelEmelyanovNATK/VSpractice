using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GAIManagment.ModuleCore.Domain
{
    /// <summary>
    /// Вспомогательный класс для осуществления навигации в главном окне.
    /// </summary>
    public class NavController
    {
        private static Frame frameMain;

        /// <summary>
        /// Записывает ссылку фрейма в котором будет осуществлятся навигация.
        /// </summary>
        /// <param name="frame"></param>
        public static void Setup(Frame frame)
        {
            frameMain = frame;
        }

        /// <summary>
        /// Устанавливает переданную страницу не записывая её в историю.
        /// </summary>
        /// <param name="page"></param>
        public static void SetPage(Page page)
        {
            frameMain.Navigate(page);

            while (frameMain.CanGoBack)
                frameMain.RemoveBackEntry();
        }

        /// <summary>
        /// Устанавливает переданную страницу.
        /// </summary>
        /// <param name="page"></param>
        public static void Navigate(Page page)
        {
            frameMain.Navigate(page);
        }

        /// <summary>
        /// Возвращает на предыдущую страницу.
        /// </summary>
        public static void GoBack()
        {
            if (frameMain.CanGoBack)
                frameMain.GoBack();
        }
    }
}
