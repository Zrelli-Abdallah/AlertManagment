using System.ComponentModel;

public interface IAlerteServicePostgres
{
    // Define methods for alert service operations
    Task addAlerteAsync(Alerte alerte);
    Task updateAlerteAsync(Alerte alerte);
    Task deleteAlerteAsync(long alerteId);
    Task<Alerte> getAlerteByIdAsync(long alerteId);
    Task<List<Alerte>> getAllAlertesAsync();
}