using App.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Reservation:BaseEntity<int>,IAuditEntity
    {
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
