using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class PrizeModel
    {
        int id;
        List<MatchupEntryModel> Enteries = new List<MatchupEntryModel>();
        TeamModel Winner;
        int MatchupRound;
    }
}
