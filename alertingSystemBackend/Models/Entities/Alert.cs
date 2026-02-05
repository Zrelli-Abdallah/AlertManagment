using Alertes.Models.Enums;


public class Alert
{
    public long Id { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public TypeAlerte TypeAlerte { get; set; }
    public Criticite Criticite { get; set; }
    public StatutAlerte StatutAlert { get; set; }
    public NiveauEscalade NiveauEscaladeActuel { get; set; }
    
    // Lifecycle dates
    public DateTime DateCreation { get; set; }
    public DateTime? DateNotification { get; set; }
    public DateTime? DateEscaladeN1 { get; set; }
    public DateTime? DateEscaladeN2 { get; set; }
    public DateTime? DatePriseEnCharge { get; set; }
    public DateTime? DateResolution { get; set; }
    
    public string Metadata { get; set; }  // JSON
    public long SourceId { get; set; }
    public long? ResponsableActuel { get; set; }  // FK matches DB type
}