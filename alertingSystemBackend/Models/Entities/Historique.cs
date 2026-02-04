using Alertes.Models.Enums;

namespace Alertes.Models
{
    public class Historique
    {
        public long Id { get; set; }
        public Alert Alerte { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public string Action { get; set; }
        public StatutAlerte AncienStatut { get; set; }
        public StatutAlerte NouveauStatut { get; set; }

        public string Commentaire { get; set; }
        public DateTime DateAction { get; set; }

        public string Metadata { get; set; }
    }
}
