using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tikklok.Models;

namespace Tikklok.Data
{
    public class TiklineDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime Time { get; set; }
        public TikAction Action { get; set; }
    }
}
