using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagement.DAL
{
    public class TeamMasterVM
    {

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamOrigin { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
       
    
    }
}
