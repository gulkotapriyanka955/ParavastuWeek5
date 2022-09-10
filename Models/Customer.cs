using System;
using System.Collections.Generic;

namespace ParavastuWeek5.Models
{
    public partial class Customer
    {
        public int CustNumber { get; set; }
        public string? CustName { get; set; }
        public string? CustStreet { get; set; }
        public string? CustTelephone { get; set; }
        public decimal? CustBalance { get; set; }
        public decimal? CustAmountPaid { get; set; }
        public int? CustRepId { get; set; }

        public virtual Representative? CustRep { get; set; }
    }
}
