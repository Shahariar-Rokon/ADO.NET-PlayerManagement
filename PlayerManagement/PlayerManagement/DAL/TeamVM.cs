using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagement.DAL
{
    public class TeamVM
    {
        public int TeamPlayerId { get; set; }
        public int? TeamMasterId { get; set; }
        public int? PlayerId { get; set; }
        public decimal? Salary { get; set; }
        public decimal? NumberOfPlayers { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PlayerCategory { get; set; }
    }
}
