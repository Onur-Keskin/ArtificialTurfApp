using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class User: BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Role { get; set; } = default!; // Role: 'Admin' or 'User'
        public List<Reservation> Reservations { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
