using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GenericWarehouseWebsite.Data;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Pages.Tools
{
    public class IndexModel : PageModel
    {
        private readonly GenericWarehouseWebsite.Data.WarehouseContext _context;

        public IndexModel(GenericWarehouseWebsite.Data.WarehouseContext context)
        {
            _context = context;
        }

        public PaginatedList<Tool> Tool { get; set; }
        //Adding Sorting and Filtering functionality
        public string NameSort { get; set; }
        public string PartSort { get; set; }
        public string CostSort { get; set; }
        public string BinSort { get; set; }
        public string QTYSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter ,string searchString, int? pageIndex)
        {
            //Sorting
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PartSort = sortOrder == "PartNumber" ? "PartNumber_desc" : "PartNumber";
            CostSort = sortOrder == "Cost" ? "Cost_desc" : "Cost";
            BinSort = sortOrder == "Bin" ? "Bin_desc" : "Bin";
            QTYSort = sortOrder == "QTY" ? "QTY_desc" : "QTY";
            //Filtering
            if (searchString != null)//Decided if you are in the index page or some other page then acts accordingly
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Tool> toolIQ = from s in _context.Tools
                                      select s;

            if(!String.IsNullOrEmpty(searchString))//If the string is valid then tollIQ gets whichever value matches first
            {
                toolIQ = toolIQ.Where(s => s.Name.Contains(searchString)
                                || s.PartNumber.Contains(searchString)
                                || s.Bin.Contains(searchString));
            }


            switch(sortOrder)//Checls the string from the url and deciedes how to sort it
            {
                case "name_desc":
                    toolIQ = toolIQ.OrderByDescending(s => s.Name);
                    break;
                case "PartNumer":
                    toolIQ = toolIQ.OrderBy(s => s.PartNumber);
                    break;
                case "PartNumber_desc":
                    toolIQ = toolIQ.OrderByDescending(s => s.PartNumber);
                    break;
                case "Cost":
                    toolIQ = toolIQ.OrderBy(s => s.Cost);
                    break;
                case "Cost_desc":
                    toolIQ = toolIQ.OrderByDescending(s => s.Cost);
                    break;
                case "Bin":
                    toolIQ = toolIQ.OrderBy(s => s.Bin);
                    break;
                case "Bin_desc":
                    toolIQ = toolIQ.OrderByDescending(s => s.Bin);
                    break;
                case "QTY":
                    toolIQ = toolIQ.OrderBy(s => s.Quantity);
                    break;
                case "QTY_desc":
                    toolIQ = toolIQ.OrderByDescending(s => s.Quantity);
                    break;


                default:
                    toolIQ = toolIQ.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;

            Tool = await PaginatedList<Tool>.CreateAsync(
                toolIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}