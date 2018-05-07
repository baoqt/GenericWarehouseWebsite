using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericWarehouseWebsite.Models
{
    public class Component
    {
        public int ID { get; set; }

        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Bin { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
