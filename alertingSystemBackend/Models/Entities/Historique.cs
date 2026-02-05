using Alertes.Models.Enums;

namespace Alertes.Models
{
    public class Historique
    {
        public long Id { get; set; }
        public long AlerteId { get; set; }
        public Alert Alerte { get; set; }
        public long UtilisateurId { get; set; }
        public User Utilisateur { get; set; }

        public string Action { get; set; }
        public StatutAlerte AncienStatut { get; set; }
        public StatutAlerte NouveauStatut { get; set; }

        public string Commentaire { get; set; }
        public DateTime DateAction { get; set; }

        public string Metadata { get; set; }
    }
}
