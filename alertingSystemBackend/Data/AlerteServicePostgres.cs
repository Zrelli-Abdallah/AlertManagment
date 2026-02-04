public class AlerteServicePostgres : IAlerteServicePostgres
{
    private readonly ApplicationDBContext _dbContext;

    public AlerteServicePostgres(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task addAlerteAsync(Alerte alerte)
    {
        await _dbContext.Alertes.AddAsync(alerte);
        await _dbContext.SaveChangesAsync();
    }

}