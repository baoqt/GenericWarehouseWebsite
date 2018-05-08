using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Components
{
    public class IndexModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public IndexModel(GenericWarehouseWebsite.Data.WarehouseContext context)
        {
            _context = context;
        }

        public PaginatedList<Component> Component { get; set; }
        //Adding Sorting and Filtering functionality
        public string NameSort { get; set; }
        public string PartSort { get; set; }
        public string CostSort { get; set; }
        public string BinSort { get; set; }
        public string QTYSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
    string currentFilter, string searchString, int? pageIndex)
        {
            //Sorting
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PartSort = sortOrder == "PartNumber" ? "PartNumber_desc" : "PartNumber";
            CostSort = sortOrder == "Cost" ? "Cost_desc" : "Cost";
            BinSort = sortOrder == "Bin" ? "Bin_desc" : "Bin";
            QTYSort = sortOrder == "QTY" ? "QTY_desc" : "QTY";
            //Filtering
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Component> componentIQ = from s in _context.Components
                                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                componentIQ = componentIQ.Where(s => s.Name.Contains(searchString)
                                || s.PartNumber.Contains(searchString)
                                || s.Bin.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    componentIQ = componentIQ.OrderByDescending(s => s.Name);
                    break;
                case "PartNumer":
                    componentIQ = componentIQ.OrderBy(s => s.PartNumber);
                    break;
                case "PartNumber_desc":
                    componentIQ = componentIQ.OrderByDescending(s => s.PartNumber);
                    break;
                case "Cost":
                    componentIQ = componentIQ.OrderBy(s => s.Cost);
                    break;
                case "Cost_desc":
                    componentIQ = componentIQ.OrderByDescending(s => s.Cost);
                    break;
                case "Bin":
                    componentIQ = componentIQ.OrderBy(s => s.Bin);
                    break;
                case "Bin_desc":
                    componentIQ = componentIQ.OrderByDescending(s => s.Bin);
                    break;
                case "QTY":
                    componentIQ = componentIQ.OrderBy(s => s.Quantity);
                    break;
                case "QTY_desc":
                    componentIQ = componentIQ.OrderByDescending(s => s.Quantity);
                    break;


                default:
                    componentIQ = componentIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            Component = await PaginatedList<Component>.CreateAsync(
                componentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}