using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class FieldSituation : BaseEntity<int>, IAuditEntity
    {
        public int FootballFieldId { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } //Start ve End time arası
        public bool IsReserv { get; set; }
        public int ReservationId { get; set; }
        public FootballField FootballField { get; set; } = default!;
        public Reservation Reservation { get; set; } = default!;
        public DateTime Created {  get; set; }
        public DateTime? Updated {  get; set; }
    }
}
