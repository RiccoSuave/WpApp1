using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TeamModel
    {
        public int id;
        public string TeamName;
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
    }
}
