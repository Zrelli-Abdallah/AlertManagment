using System.ComponentModel;
using alertingSystemBackend.Models.Entities;

public interface IAlerteServicePostgres
{
    // Define methods for alert service operations
    Task addAlerteAsync(Alert alerte);
    Task updateAlerteAsync(Alert alerte);
    Task deleteAlerteAsync(long alerteId);
    Task<Alert> getAlerteByIdAsync(long alerteId);
    Task<List<Alert>> getAllAlertesAsync();
}