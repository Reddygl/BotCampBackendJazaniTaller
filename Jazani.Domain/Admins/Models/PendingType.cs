using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Models
{
    public class PendingType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool State { get; set; }
    }
}
