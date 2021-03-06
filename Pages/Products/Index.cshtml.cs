using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoRazor.Data;
using DemoRazor.Entities;

namespace DemoRazor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly DemoRazor.Data.DemoContext _context;

        public IndexModel(DemoRazor.Data.DemoContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
        }
    }
}
