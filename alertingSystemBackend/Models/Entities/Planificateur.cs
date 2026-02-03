namespace Alertes.Models
{
    public class Planificateur
    {
        public int IntervalVerification { get; set; }
        public bool Actif { get; set; }
        public DateTime DerniereExecution { get; set; }
    }
}
