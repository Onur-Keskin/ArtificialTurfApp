using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Reservation:BaseEntity<int>,IAuditEntity
    {
        public string Name { get; set; } = default!; //Rezervasyon adı
        public int UserId { get; set; }
        public bool IsCancel { get; set; } //Rezervazyon iptal mi
        public int FieldSituationId { get; set; }
        public FieldSituation FieldSituation { get; set; } = default!;
        public User User { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
