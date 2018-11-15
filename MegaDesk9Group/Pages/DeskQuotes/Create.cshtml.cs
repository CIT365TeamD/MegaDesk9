using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk9Group.Models;

namespace MegaDesk9Group.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk9Group.Models.MegaDesk9GroupContext _context;

        public CreateModel(MegaDesk9Group.Models.MegaDesk9GroupContext context)
        {
            _context = context;
        }
        public List<Material> MaterialList = Enum.GetValues(typeof(Material)).Cast<Material>().ToList();
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var emptyDeskQuote = new DeskQuote();
          
            
        
    
            if (await TryUpdateModelAsync<DeskQuote>(
                emptyDeskQuote,
                "deskQuote",
                s => s.FirstName, s => s.LastName, s => s.QuoteDate, s => s.RushOrder, s => s.Width, s => s.Depth,
                s => s.DrawerCount, s => s.SurfaceMaterial))
            {
                _context.DeskQuote.Add(emptyDeskQuote);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Details", new { id = emptyDeskQuote.ID });
            }

            return null;
        }
    }
}