using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk9Group.Models;

namespace MegaDesk9Group.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk9Group.Models.MegaDesk9GroupContext _context;

        public IndexModel(MegaDesk9Group.Models.MegaDesk9GroupContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote.ToListAsync();
        }
    }
}
