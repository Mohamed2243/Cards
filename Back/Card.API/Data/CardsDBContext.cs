using Card.API.Model;
using Microsoft.EntityFrameworkCore;


namespace Card.API.Data;
public class CardsDbContext : DbContext
{
    public CardsDbContext(DbContextOptions options) : base(options)
    {

    }
    //Dbset
    public DbSet<Model.Card> Cards { set; get; }


}
