using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class City:BaseEntity<int>,IAuditEntity
    {
        public string CityName { get; set; } = default!;
        public int CityPlateNumber { get; set; } = default!;
        public List<Town> Towns { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
