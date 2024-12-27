using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class FootballField : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public string Location { get; set; } = default!;
        public decimal PricePerHour { get; set; }
        public bool IsAvailable { get; set; }  
        public int TownId { get; set; } = default!;
        public List<Reservation>? Reservations { get; set; } // Navigation property
        public Town Town { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
