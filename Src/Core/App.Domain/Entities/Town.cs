using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Town:BaseEntity<int>,IAuditEntity
    {
        public string TownName { get; set; } = default!;
        public int CityId { get; set; }
        public City City { get; set; } = default!;
        public List<Business>? Businesses { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
