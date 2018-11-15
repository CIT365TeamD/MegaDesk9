using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDesk9Group.Models;

namespace MegaDesk9Group.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDesk9Group.Models.MegaDesk9GroupContext _context;

        public EditModel(MegaDesk9Group.Models.MegaDesk9GroupContext context)
        {
            _context = context;
        }
        public List<Material> MaterialList = Enum.GetValues(typeof(Material)).Cast<Material>().ToList();

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FindAsync(id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var deskQuoteToUpdate = await _context.DeskQuote.FindAsync(id);

            if (await TryUpdateModelAsync<DeskQuote>(
                deskQuoteToUpdate,
                "deskQuote",
                s => s.FirstName, s => s.LastName, s => s.QuoteDate, s => s.RushOrder, s => s.Width, s => s.Depth,
                s => s.DrawerCount, s => s.SurfaceMaterial))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Details", new { id = deskQuoteToUpdate.ID });
            }
              

            return Page();
        }
    }
}
