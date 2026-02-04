public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Alerte> Alertes { get; set; } //Create a DbSet for Alert entities (Table in the database)


    //...........

    }