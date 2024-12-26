using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class City:BaseEntity<int>,IAuditEntity
    {
        public string CityName { get; set; } = default!;
        public ICollection<Town> Towns { get; set; }
        public ICollection<FootballField> FootballFields { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
