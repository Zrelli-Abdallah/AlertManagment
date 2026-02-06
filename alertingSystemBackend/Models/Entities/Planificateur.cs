using System.ComponentModel.DataAnnotations;

namespace alertingSystemBackend.Models.Entities
{
    public class Planificateur
    {
        [Key]
        public int Id { get; set; }
        public int IntervalVerification { get; set; }
        public bool Actif { get; set; }
        public DateTime DerniereExecution { get; set; }
    }
}
