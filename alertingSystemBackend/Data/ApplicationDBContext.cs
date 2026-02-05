using alertingSystemBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(
        DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public DbSet<Alert> Alertes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Historique> Historiques { get; set; }
    public DbSet<Escalade> Escalades { get; set; }
    public DbSet<RegleEscalade> ReglesEscalade { get; set; }
    public DbSet<ConfigurationEscalade> ConfigurationsEscalade { get; set; }
    public DbSet<Planificateur> Planificateurs { get; set; }
}
