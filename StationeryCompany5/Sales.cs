//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StationeryCompany5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int Sale_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> Manager_ID { get; set; }
        public string Buyer_Company_Name { get; set; }
        public int Quantity_Sold { get; set; }
        public decimal Unit_Price { get; set; }
        public System.DateTime Sale_Date { get; set; }
    
        public virtual Managers Managers { get; set; }
        public virtual Products Products { get; set; }
    }
}
