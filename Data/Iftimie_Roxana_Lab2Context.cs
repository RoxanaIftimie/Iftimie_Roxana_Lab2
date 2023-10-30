using Microsoft.EntityFrameworkCore;
using Iftimie_Roxana_Lab2.Models;

namespace Iftimie_Roxana_Lab2.Data
{
    public class Iftimie_Roxana_Lab2Context : DbContext
    {
        public Iftimie_Roxana_Lab2Context(DbContextOptions<Iftimie_Roxana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Iftimie_Roxana_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Iftimie_Roxana_Lab2.Models.Publisher>? Publisher { get; set; }
    }
}
