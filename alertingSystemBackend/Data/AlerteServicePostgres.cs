using alertingSystemBackend.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class AlerteServicePostgres : IAlerteServicePostgres
{
    private readonly ApplicationDBContext _dbContext;

    public AlerteServicePostgres(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task addAlerteAsync(Alert alerte)
    {
        await _dbContext.Alertes.AddAsync(alerte);
        await _dbContext.SaveChangesAsync();
    }

    public async Task updateAlerteAsync(Alert alerte)
    {
        _dbContext.Alertes.Update(alerte);
        await _dbContext.SaveChangesAsync();
    }

    public async Task deleteAlerteAsync(long alerteId)
    {
        var alerte = await _dbContext.Alertes.FindAsync(alerteId);
        if (alerte != null)
        {
            _dbContext.Alertes.Remove(alerte);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Alert> getAlerteByIdAsync(long alerteId)
    {
        return await _dbContext.Alertes.FindAsync(alerteId);
    }

    public async Task<List<Alert>> getAllAlertesAsync()
    {
        return await _dbContext.Alertes.ToListAsync();
    }
}