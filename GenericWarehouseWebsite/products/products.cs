using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericWarehouseWebsite.NewFolder
{
    public class products
    {
        public int ID { get; set; }
        public int supplierID { get; set; }
        public string proName { get; set; }
        public DateTime ManufucturDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
