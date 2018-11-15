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
    public class DeleteModel : PageModel
    {
        private readonly MegaDesk9Group.Models.MegaDesk9GroupContext _context;

        public DeleteModel(MegaDesk9Group.Models.MegaDesk9GroupContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deskQuote = await _context.DeskQuote
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (DeskQuote == null)
            {
                return NotFound();
            }
            try
            { 
                _context.DeskQuote.Remove(DeskQuote);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch
            {
                //Log error
                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }


        }
    }
}
