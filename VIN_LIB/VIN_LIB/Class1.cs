using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VIN_LIB
{
    public class Class1
    {
        public Class1()
        {
            RawCountiesToCodesDict();
            FillYearsDict();
        }

        /// <summary>
        /// Исходный список стран, далее они будут конвертированы в Regex-правило.
        /// </summary>
        string rawCountries =
            "AA-AH=ЮАР;" +
            "AJ-AN=Кот-д’Ивуар;" +
            "BA-BE=Ангола;" +
            "BF-BK=Кения;" +
            "BL-BR=Танзания;" +
            "CA-CE=Бенин;" +
            "CF-CK=Мадагаскар;" +
            "CL-CR=Тунис;" +
            "DA-DE=Египет;" +
            "DF-DK=Марокко;" +
            "DL-DR=Замбия;" +
            "EA-EE=Эфиопия;" +
            "EF-EK=Мозамбик;" +
            "FA-FE=Гана;" +
            "FF-FK=Нигерия;" +
            "JA-JT=Япония;" +
            "KA-KE=Шри Ланка;" +
            "KF-KK=Израиль;" +
            "KL-KR=Южная Корея;" +
            "KS-K0=Казахстан;" +
            "LA-L0=Китай;" +
            "MA-ME=Индия;" +
            "MF-MK=Индонезия;" +
            "ML-MR=Таиланд;" +
            "NF-NK=Пакистан;" +
            "NL-NR=Турция;" +
            "PA-PE=Филиппины;" +
            "PF-PK=Сингапур;" +
            "PL-PR=Малайзия;" +
            "RA-RE=ОАЭ;" +
            "RF-RK=Тайвань;" +
            "RL-RR=Вьетнам;" +
            "RS-R0=Саудовская Аравия;" +
            "SA-SM=Великобритания;" +
            "SN-ST=Германия;" +
            "SU-SZ=Польша;" +
            "S1-S4=Латвия;" +
            "TA-TH=Швейцария;" +
            "TJ-TP=Чехия;" +
            "TR-TV=Венгрия;" +
            "TW-T1=Португалия;" +
            "UH-UM=Дания;" +
            "UN-UT=Ирландия;" +
            "UU-UZ=Румыния;" +
            "U5-U7=Словакия;" +
            "VA-VE=Австрия;" +
            "VF-VR=Франция;" +
            "VS-VW=Испания;" +
            "VX-V2=Сербия;" +
            "V3-V5=Хорватия;" +
            "V6-V0=Эстония;" +
            "WA-W0=Германия;" +
            "XA-XE=Болгария;" +
            "XF-XK=Греция;" +
            "XL-XR=Нидерланды;" +
            "XS-XW=СССР/СНГ;" +
            "XX-X2=Люксембург;" +
            "X3-X0=Россия;" +
            "YA-YE=Бельгия;" +
            "YF-YK=Финляндия;" +
            "YL-YR=Мальта;" +
            "YS-YW=Швеция;" +
            "YX-Y2=Норвегия;" +
            "Y3-Y5=Беларусь;" +
            "Y6-Y0=Украина;" +
            "ZA-ZR=Италия;" +
            "ZX-Z2=Словения;" +
            "Z3-Z5=Литва;" +
            "Z6-Z0=Россия;" +
            "1A-10=США;" +
            "2A-20=Канада;" +
            "3A-3W=Мексика;" +
            "3X-37=Коста Рика;" +
            "38-30=Каймановы острова;" +
            "4A-40=США;" +
            "5A-50=США;" +
            "6A-6W=Австралия;" +
            "7A-7E=Новая Зеландия;" +
            "8A-8E=Аргентина;" +
            "8F-8K=Чили;" +
            "8L-8R=Эквадор;" +
            "8S-8W=Перу;" +
            "8X-82=Венесуэла;" +
            "9A-9E=Бразилия;" +
            "9F-9K=Колумбия;" +
            "9L-9R=Парагвай;" +
            "9S-9W=Уругвай;" +
            "9X-92=Тринидад и Тобаго;" +
            "93-99=Бразилия";

        /// <summary>
        /// Правило для проверки валидности VIN`а
        /// </summary>
        Regex vinRegex = new Regex(
                   @"^([A-Z1-9-[OIQ]]{3})([A-Z0-9-[OIQ]]{5})([0-9X]{1})([A-Y1-9-[OIQU]]{1})(([A-Z0-9-[OIQ]]{7})|([A-Z0-9-[OIQ]]{5}))$"
               );

        /// <summary>
        /// Словарь для правил проверки стран. Первый элемент - правило, второй - страна.
        /// </summary>
        Dictionary<string, string> countryCodes;

        /// <summary>
        /// Словарь с возможными годами. Первый элемент - код года, второй - год.
        /// </summary>
        Dictionary<char, int> modelYears;

        /// <summary>
        /// проверяет переданный VIN номер и возвращает true или false в зависимости 
        /// от правильности VIN номера. Также учитывается контрольная сумма.
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public bool CheckVIN(String vin)
        {
            var formattedVin = vin.ToUpper();

            if (!vinRegex.IsMatch(formattedVin)) return false;

            //Перевод символов в цифровой эквивалент
            int[] numberedVin = formattedVin.Select(it =>
            {
                if (it == 'A') return 1;
                if (it == 'B') return 2;
                if (it == 'C') return 3;
                if (it == 'D') return 4;
                if (it == 'E') return 5;
                if (it == 'F') return 6;
                if (it == 'G') return 7;
                if (it == 'H') return 8;
                if (it == 'J') return 1;
                if (it == 'K') return 2;
                if (it == 'L') return 3;
                if (it == 'M') return 4;
                if (it == 'N') return 5;
                if (it == 'P') return 7;
                if (it == 'R') return 9;
                if (it == 'S') return 2;
                if (it == 'T') return 3;
                if (it == 'U') return 4;
                if (it == 'V') return 5;
                if (it == 'W') return 6;
                if (it == 'X') return 7;
                if (it == 'Y') return 8;
                if (it == 'Z') return 9;

                return Convert.ToInt32(it.ToString());
            }).ToArray();

            //Подсчёт суммы с учётом весов
            int sum = 0;
            for (int i = 0; i < numberedVin.Count(); i++)
            {
                if (i + 1 == 1) { sum += numberedVin[i] * 8; continue; }
                if (i + 1 == 2) { sum += numberedVin[i] * 7; continue; }
                if (i + 1 == 3) { sum += numberedVin[i] * 6; continue; }
                if (i + 1 == 4) { sum += numberedVin[i] * 5; continue; }
                if (i + 1 == 5) { sum += numberedVin[i] * 4; continue; }
                if (i + 1 == 6) { sum += numberedVin[i] * 3; continue; }
                if (i + 1 == 7) { sum += numberedVin[i] * 2; continue; }
                if (i + 1 == 8) { sum += numberedVin[i] * 10; continue; }
                if (i + 1 == 9) { continue; }
                if (i + 1 == 10) { sum += numberedVin[i] * 9; continue; }
                if (i + 1 == 11) { sum += numberedVin[i] * 8; continue; }
                if (i + 1 == 12) { sum += numberedVin[i] * 7; continue; }
                if (i + 1 == 13) { sum += numberedVin[i] * 6; continue; }
                if (i + 1 == 14) { sum += numberedVin[i] * 5; continue; }
                if (i + 1 == 15) { sum += numberedVin[i] * 4; continue; }
                if (i + 1 == 16) { sum += numberedVin[i] * 3; continue; }
                if (i + 1 == 17) { sum += numberedVin[i] * 2; continue; }
            }

            int min_nearest_int = ((int)(sum / 11f)) * 11;
            int control_sum = sum - min_nearest_int;
            char control_char;

            if (control_sum == 10)
                control_char = 'X';
            else
                control_char = Convert.ToChar(control_sum.ToString());

            if (vin[8] != control_char) return false;

            return true;
        }

        /// <summary>
        /// Возвращает страну, в которой было изготовлено транспортное средство.
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public string GetVINCountry(String vin)
        {
            foreach (var code in countryCodes)
            {
                if (new Regex(code.Key).IsMatch(vin[0].ToString() + vin[1].ToString()))
                    return code.Value;
            }
            return "error";
        }

        /// <summary>
        /// Возвращает год, в который было выпущено транспортное средство.
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public int GetTransportYear(String vin)
        {
            if (modelYears.ContainsKey(vin[9]))
            {
                return modelYears[vin[9]];
            }

            return -1;
        }

        /// <summary>
        /// Заполняет словарь правил для стран на основе исходного списка стран.
        /// </summary>
        void RawCountiesToCodesDict()
        {
            countryCodes = new Dictionary<string, string>();

            string[] countries = rawCountries.Split(';'); //Разделяем список на элементы, содержащие страну с промежуток.

            foreach (var country in countries)
            {
                string[] country_and_code = country.Split('='); //Разделяем каждый элемент на пару промежуток - страна

                //Если промежуток охватывает и буквенную часть,
                //и цифровую, формируем соотвествующее правило.
                //Прим. AV-A9 => A[V-Z0-9].
                if ((country_and_code[0][1] >= 'A' && country_and_code[0][1] <= 'Z') && (country_and_code[0][4] >= '0' && country_and_code[0][4] <= '9'))
                    countryCodes.Add(
                        country_and_code[0][0] + "[" + country_and_code[0][1] + "-Z0-" + country_and_code[0][4] + "]", country_and_code[1]);
                //Иначе указан либо только буквенный промежуток, либо только цифровой.
                //Прим. A1-A8 => A[1-8] | AA-AC => A[A-c].
                else
                    countryCodes.Add(
                        country_and_code[0][0] + "[" + country_and_code[0][1] + "-" + country_and_code[0][4] + "]", country_and_code[1]);
            }
        }

        /// <summary>
        /// Заполняет словарь годов начиная с 1980.
        /// </summary>
        void FillYearsDict()
        {
            modelYears = new Dictionary<char, int>();

            int year = 1980;
            //Проходимся по символам от A до Y, исключая O I Q U.
            for (int i = 'A'; i <= 'Y'; i++)
            {
                if (i == 'O' || i == 'I' || i == 'Q' || i == 'U')
                    continue;
                modelYears.Add((char)i, year);
                year++;
            }
            //Проходимся от 0 до 9
            for (int i = '0'; i <= '9'; i++)
            {
                modelYears.Add((char)i, year);
                year++;
            }
        }
    }
}
