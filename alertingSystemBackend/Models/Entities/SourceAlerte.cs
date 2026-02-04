namespace Alertes.Models
{
    public class SourceAlerte
    {
        public long Id { get; set; }

        public string Nom { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }

        public bool Active { get; set; }
        public string Configuration { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
