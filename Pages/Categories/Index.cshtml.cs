using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoRazor.Data;
using DemoRazor.Entities;

namespace DemoRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DemoRazor.Data.DemoContext _context;

        public IndexModel(DemoRazor.Data.DemoContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
