//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SE_Adidatcuong
{
    using System;
    using System.Collections.Generic;
    
    public partial class WR_Detail
    {
        public string WRID { get; set; }
        public string ProductID { get; set; }
        public decimal Quantity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual WarehouseReceipt WarehouseReceipt { get; set; }
    }
}
