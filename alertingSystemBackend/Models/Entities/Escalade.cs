using Alertes.Models.Enums;

namespace Alertes.Models
{
    public class Escalade
    {
        public long Id { get; set; }
        public long AlerteId { get; set; }

        public NiveauEscalade NiveauDepart { get; set; }
        public NiveauEscalade NiveauArrivee { get; set; }

        public bool DeclenchementAutomatique { get; set; }
        public string Raison { get; set; }

        public DateTime DateEscalade { get; set; }
        public long NotificationId { get; set; }
    }
}
