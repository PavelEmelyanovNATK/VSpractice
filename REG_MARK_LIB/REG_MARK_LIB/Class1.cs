using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    class Class1
    {
        /// <summary>
        /// Буквы, разрешённые в номере
        /// </summary>
        string accessedSimbols = "ABEKMHOPCTYX";

        /// <summary>
        /// Правило для валидации номера
        /// </summary>
        Regex markRegex = new Regex(
                    @"^([ABEKMHOPCTYX])([0-9]{3})([ABEKMHOPCTYX]{2})([0-9]{2,3})$"
                );

        /// <summary>
        /// Инкрементирует букву на основе списка доступных букв. В случае, если 
        /// буква была последней, она становистся первой из алфавита
        /// </summary>
        /// <param name="c">Принимаемая буква</param>
        /// <returns></returns>
        char IncrementSeriesChar(char c)
        {
            int charInd = accessedSimbols.IndexOf(c);
            if (charInd < accessedSimbols.Length - 1)
                return accessedSimbols[charInd + 1];
            else
                return accessedSimbols[0];
        }

        /// <summary>
        /// Конвертирует номер в цифровой эквивалент. Цифровые эквиваленты можно сравнивать.
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        int MarkToInt(string mark)
        {
            int number = Convert.ToInt32(mark.Substring(1, 3));
            string series = mark[0].ToString() + mark.Substring(4, 2);

            return
                accessedSimbols.IndexOf(series[0]) * 1000 * accessedSimbols.Length * accessedSimbols.Length +
                accessedSimbols.IndexOf(series[1]) * 1000 * accessedSimbols.Length +
                accessedSimbols.IndexOf(series[2]) * 1000 +
                number;
        }

        /// <summary>
        /// Проверяет переданный номерной знак в формате a999aa999  (латинскими буквами) и возвращает 
        /// true или false в зависимости от правильности номерного знака
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public bool CheckMark(String mark)
            => markRegex.IsMatch(mark);

        /// <summary>
        /// Принимает номерной знак в формате a999aa999 (латинскими буквами) и выдает 
        /// следующий номер в данной серии или создает следующую серию.
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public String GetNextMarkAfter(String mark)
        {
            int number = Convert.ToInt32(mark.Substring(1, 3));
            string series = mark[0].ToString() + mark.Substring(4, 2);
            string reg = mark.Substring(6);

            if (number < 999)
                return $"{series[0]}{number + 1}{series[1]}{series[2]}{reg}";
            else
            {
                if (series == "XXX") return "error";

                char trd = IncrementSeriesChar(series[2]);
                if (trd != 'A')
                    return $"{series[0]}000{series[1]}{trd}{reg}";
                else
                {
                    char snd = IncrementSeriesChar(series[1]);
                    if (snd != 'A')
                        return $"{series[0]}000{snd}{trd}{reg}";
                    else
                    {
                        char fst = IncrementSeriesChar(series[0]);
                        return $"{fst}000{snd}{trd}{reg}";
                    }
                }
            }

            return "error";
        }

        /// <summary>
        /// Принимает номерной знак в формате a999aa999 (латинскими буквами) и выдает следующий 
        /// номер в данной данном промежутке номеров rangeStart до rangeEnd (включая обе границы). 
        /// Если нет возможности выдать следующий номер, вернет “out of stock”.
        /// </summary>
        /// <param name="prevMark"></param>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns></returns>
        public String GetNextMarkAfterInRange(String prevMark, String rangeStart, String rangeEnd)
        {
            int intPrev = MarkToInt(prevMark);
            int intStart = MarkToInt(rangeStart);
            int intEnd = MarkToInt(rangeEnd);

            if (intPrev < intStart || intPrev >= intEnd) return "out of stock";

            return GetNextMarkAfter(prevMark);
        }

        /// <summary>
        /// Принимает два номера в формате a999aa999 (латинскими буквами) и возвращает 
        /// количество возможных номеров между ними (включая обе границы). 
        /// Метод необходим, чтобы рассчитать оставшиеся свободные номера для региона.
        /// </summary>
        /// <param name="mark1"></param>
        /// <param name="mark2"></param>
        /// <returns></returns>
        public int GetCombinationsCountInRange(String mark1, String mark2)
        {
            int intMark1 = MarkToInt(mark1);
            int intMark2 = MarkToInt(mark2);
            if (intMark1 > intMark2) return -1;

            return intMark2 - intMark1 + 1;
        }
    }
}
