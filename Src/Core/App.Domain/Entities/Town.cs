using App.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Town:BaseEntity<int>,IAuditEntity
    {
        public int TownId { get; set; }
        public string TownName { get; set; } = default!;
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<FootballField> FootballFields { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
