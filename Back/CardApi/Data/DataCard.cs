using CardApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Data
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {

        }
        //Dbset
        public DbSet<Card> Cards { set; get; }


    }
}
