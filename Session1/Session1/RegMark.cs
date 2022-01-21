using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Session1
{
    class RegMark
    {
        string accessesSimbols = "ABEKMHOPCTYX";
        Regex markRegex = new Regex(
                    @"^([ABEKMHOPCTYX])([0-9]{3})([ABEKMHOPCTYX]{2})([0-9]{2,3})$"
                );
        
        char IncrementSeriesChar(char c)
        {
            int charInd = accessesSimbols.IndexOf(c);
            if (charInd < accessesSimbols.Length-1)
                return accessesSimbols[charInd+1];
            else
                return accessesSimbols[0];
        }
        
        int MarkToInt(string mark)
        {
            int number = Convert.ToInt32(mark.Substring(1, 3));
            string series = mark[0].ToString() + mark.Substring(4, 2);
        
            return
                accessesSimbols.IndexOf(series[0]) * 1000 * accessesSimbols.Length * accessesSimbols.Length +
                accessesSimbols.IndexOf(series[1]) * 1000 * accessesSimbols.Length +
                accessesSimbols.IndexOf(series[2]) * 1000 +
                number;
        }
        
        public bool CheckMark(String mark) 
            => markRegex.IsMatch(mark);
        
        public String GetNextMarkAfter(String mark)
        {
            int number = Convert.ToInt32(mark.Substring(1,3));
            string series = mark[0].ToString() + mark.Substring(4, 2);
            string reg = mark.Substring(6);
        
            if (number < 999)
                return $"{series[0]}{number + 1}{series[1]}{series[2]}{reg}";
            else
            {
                if (series == "XXX") return "error";
        
                char trd = IncrementSeriesChar(series[2]);
                if(trd != 'A')
                    return $"{series[0]}000{series[1]}{trd}{reg}";
                else
                {
                    char snd = IncrementSeriesChar(series[1]);
                    if(snd != 'A')
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
        
        public String GetNextMarkAfterInRange(String prevMark, String rangeStart, String rangeEnd)
        {
            int intPrev = MarkToInt(prevMark);
            int intStart = MarkToInt(rangeStart);
            int intEnd = MarkToInt(rangeEnd);
        
            if (intPrev < intStart || intPrev >= intEnd) return "out of stock";
        
            return GetNextMarkAfter(prevMark);
        }
        
        public int GetCombinationsCountInRange(String mark1, String mark2)
        {
            int intMark1 = MarkToInt(mark1);
            int intMark2 = MarkToInt(mark2);
            if (intMark1 > intMark2) return -1;
        
            return intMark2 - intMark1 + 1;
        }
    }
}
