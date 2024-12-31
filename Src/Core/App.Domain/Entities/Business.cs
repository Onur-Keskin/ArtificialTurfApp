using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Business : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;

        public int TownId { get; set; }
        public Town Town { get; set; } = default!;

        public List<FootballField> FootballFields { get; set; } = default!;

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
