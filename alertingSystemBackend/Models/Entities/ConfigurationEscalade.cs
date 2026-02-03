namespace Alertes.Models
{
    public class ConfigurationEscalade
    {
        public long Id { get; set; }

        public int DelaiNiveau0VersNiveau1 { get; set; }
        public int DelaiNiveau1VersNiveau2 { get; set; }

        public int FrequenceVerification { get; set; }
        public int NombreRappelsMax { get; set; }
        public int IntervalleRappel { get; set; }
    }
}