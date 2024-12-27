using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Reservation:BaseEntity<int>,IAuditEntity
    {
        public string Name { get; set; } = default!;
        public int UserId { get; set; } // Foreign key to User
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int FootballFieldId { get; set; }
        public FootballField FootballField { get; set; } = default!;
        public User User { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
