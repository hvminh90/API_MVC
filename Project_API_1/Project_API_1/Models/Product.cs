//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_API_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<long> Quantity { get; set; }
        public string PathImage { get; set; }
        public string ImageName { get; set; }
        public Nullable<bool> IsHot { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
