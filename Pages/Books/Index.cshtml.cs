using Iftimie_Roxana_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Iftimie_Roxana_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Iftimie_Roxana_Lab2.Data.Iftimie_Roxana_Lab2Context _context;

        public IndexModel(Iftimie_Roxana_Lab2.Data.Iftimie_Roxana_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public IEnumerable<Book> BookD { get; set; }

        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string
searchString)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CurrentFilter = searchString;
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Publisher).ToListAsync();
                CurrentFilter = searchString;


            }

            switch (sortOrder)
            {
                case "title_desc":
                    BookD = BookD.OrderByDescending(s =>s.Title);
                    break;
            }
        }
    }
}
