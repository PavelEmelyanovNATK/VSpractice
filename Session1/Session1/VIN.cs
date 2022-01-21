using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Session1
{
    public class VIN
    {
        static string rawCountries =
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

        static Dictionary<string, string> countryCodes;
        static Dictionary<char, int> modelYears;

        static bool CheckVIN(String vin)
        {
            var formattedVin = vin.ToUpper();
            var vinRegex = new Regex(
                    @"^([A-Z1-9-[OIQ]]{3})([A-Z0-9-[OIQ]]{5})([0-9X]{1})([A-Y1-9-[OIQU]]{1})(([A-Z0-9-[OIQ]]{7})|([A-Z0-9-[OIQ]]{5}))$"
                );

            if (!vinRegex.IsMatch(formattedVin)) return false;

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

        static void RawCountiesToCodesDict()
        {
            countryCodes = new Dictionary<string, string>();

            string[] countries = rawCountries.Split(';');

            foreach (var country in countries)
            {
                string[] country_and_code = country.Split('=');

                if ((country_and_code[0][1] >= 'A' && country_and_code[0][1] <= 'Z') && (country_and_code[0][4] >= '0' && country_and_code[0][4] <= '9'))
                    countryCodes.Add(
                        country_and_code[0][0] + "[" + country_and_code[0][1] + "-Z0-" + country_and_code[0][4] + "]", country_and_code[1]);
                else
                    countryCodes.Add(
                        country_and_code[0][0] + "[" + country_and_code[0][1] + "-" + country_and_code[0][4] + "]", country_and_code[1]);
            }
        }

        static void FillYearsDict()
        {
            modelYears = new Dictionary<char, int>();

            int year = 1980;
            for (int i = 'A'; i <= 'Y'; i++)
            {
                if (i == 'O' || i == 'I' || i == 'Q' || i == 'U')
                    continue;
                modelYears.Add((char)i, year);
                year++;
            }
            for (int i = '0'; i <= '9'; i++)  // 0..9
            {
                modelYears.Add((char)i, year);
                year++;
            }
        }

        static string GetVINCountry(String vin)
        {
            foreach (var code in countryCodes)
            {
                if (new Regex(code.Key).IsMatch(vin[0].ToString() + vin[1].ToString()))
                    return code.Value;
            }
            return "error";
        }

        static int GetTransportYear(String vin)
        {
            if (modelYears.ContainsKey(vin[9]))
            {
                return modelYears[vin[9]];
            }

            return -1;
        }
    }
}
