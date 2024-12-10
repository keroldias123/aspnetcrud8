using aspnetcrud8.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcrud8.Data
{
    public class Tessoacontexto:DbContext
    {
        public Tessoacontexto(DbContextOptions<Tessoacontexto> options):base(options) { }

        public DbSet<Pessoa> pessoas { get; set; }

    }
}
