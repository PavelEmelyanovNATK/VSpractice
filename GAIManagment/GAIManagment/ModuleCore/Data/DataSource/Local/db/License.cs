//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAIManagment.ModuleCore.Data.DataSource.Local.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class License
    {
        public int ID { get; set; }
        public System.DateTime LicenceDate { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public string Categories { get; set; }
        public string LicenseSeries { get; set; }
        public string LicenseNumber { get; set; }
    
        public virtual Driver Driver { get; set; }
    }
}