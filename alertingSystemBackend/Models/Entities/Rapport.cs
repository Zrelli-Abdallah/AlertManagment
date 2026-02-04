namespace Alertes.Models
{
    public class Rapport
    {
        public long Id { get; set; }

        public string Titre { get; set; }
        public string Type { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public string Contenu { get; set; }
        public long GenereParId { get; set; }
        public DateTime DateGeneration { get; set; }
    }
}
