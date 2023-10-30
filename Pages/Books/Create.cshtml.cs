using Iftimie_Roxana_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Iftimie_Roxana_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Iftimie_Roxana_Lab2.Data.Iftimie_Roxana_Lab2Context _context;

        public CreateModel(Iftimie_Roxana_Lab2.Data.Iftimie_Roxana_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Book == null || Book == null)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
