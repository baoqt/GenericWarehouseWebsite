﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericWarehouseWebsite.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {            
            Message = "For Help please contract\nTaha Kittani\nBao Tran\nJack Tran\nGiovanni\n";
        }
    }
}
