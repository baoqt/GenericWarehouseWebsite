using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericWarehouseWebsite.Models
{
    public class Account
    {
        public int ID { get; set; }

        [Display(Name = "Employee Number")]
        public int EmployeeNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Manager Status")]
        public bool IsManager { get; set; }
    }
}
