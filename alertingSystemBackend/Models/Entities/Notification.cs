using Alertes.Models.Enums;

namespace Alertes.Models
{
    public class Notification
    {
        public long Id { get; set; }

        public Alert Alerte { get; set; }
        public Utilisateur Destinataire { get; set; }

        public TypeNotification TypeNotification { get; set; }
        public CanalNotification Canal { get; set; }

        public string Titre { get; set; }
        public string Message { get; set; }

        public int Priorite { get; set; }
        public bool Envoyee { get; set; }
        public bool Lue { get; set; }

        public DateTime DateEnvoi { get; set; }
        public DateTime? DateLecture { get; set; }

        public string Metadata { get; set; }
    }
}

