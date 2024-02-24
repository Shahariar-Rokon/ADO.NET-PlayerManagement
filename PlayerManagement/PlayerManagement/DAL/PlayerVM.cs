using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagement.DAL
{
    public class PlayerVM
    {
        public int PlayerId { get; set; }
        public string PlayerCategory { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Tax { get; set; }
    }
}
