using Alertes.Models.Enums;

namespace Alertes.Models
{
    public class RegleEscalade
    {
        public long Id { get; set; }

        public string Nom { get; set; }
        public TypeAlerte TypeAlerte { get; set; }
        public Criticite Criticite { get; set; }

        public NiveauEscalade NiveauSource { get; set; }
        public NiveauEscalade NiveauCible { get; set; }

        public int DelaiAvantEscalade { get; set; }
        public bool Active { get; set; }

        public string HorairesApplication { get; set; }
    }
}
