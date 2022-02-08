﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIManagment.ModuleStatistic.Domain
{
    /// <summary>
    /// Сущность для отображение в таблице статистики. Содержит год и числовое значение для него.
    /// </summary>
    public class YearsLicensesStatisticItem
    {
        public int Year { get; set; }
        public int Quantity { get; set; }
    }
}
