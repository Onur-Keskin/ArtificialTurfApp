using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Reservation:BaseEntity<int>,IAuditEntity
    {
        public string Name { get; set; }
        public int FieldId { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public FootballField FootballField { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
