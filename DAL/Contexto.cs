using Microsoft.EntityFrameworkCore;

public class Contexto:DbContext{

    public DbSet<Personas> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
          
            optionsBuilder.UseSqlite(@"Data Source=Personas.db");
        }


}


