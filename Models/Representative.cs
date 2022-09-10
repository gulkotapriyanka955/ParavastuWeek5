using System;
using System.Collections.Generic;

namespace ParavastuWeek5.Models
{
    public partial class Representative
    {
        public Representative()
        {
            Customers = new HashSet<Customer>();
        }

        public int RepId { get; set; }
        public string RepFirstName { get; set; } = null!;
        public string RepLastName { get; set; } = null!;
        public decimal? RepSalary { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
