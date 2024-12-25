using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class User: BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Role { get; set; } = default!; // Role: 'Admin' or 'User'
        public ICollection<Reservation> Reservations { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
