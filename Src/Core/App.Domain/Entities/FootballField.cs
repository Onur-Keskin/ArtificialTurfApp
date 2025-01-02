using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class FootballField : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public decimal HourlyPricePerPerson { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; } = default!;
        public List<FieldSituation> FieldSituations { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
