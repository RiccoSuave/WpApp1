using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTournament("SummerFun");
            MessageBox.Show("Yupikaye");
            List<List<MatchupModel>> list = new List<List<MatchupModel>>();
            List<MatchupModel> mylist = new List<MatchupModel>();
        }
        public TournamentModel CreateTournament(string tournamentName)
        {
            TournamentModel tournament = new TournamentModel();
            string temp = "dummi";
            tournament.TournamentName = tournamentName;
            tournament.EnteredTeams = CreateTeams(temp);
            // Create a list of string type called teamNames, and display them in the listbox 
            List<string> teamNames = new List<string>();
            teamNames = tournament.EnteredTeams.Select(x => x.TeamName).ToList();
            MyListBox.ItemsSource = teamNames;
            return tournament;
        }
        public List<TeamModel> CreateTeams(string teamName)
        {
            List<TeamModel> teams = new List<TeamModel>();
            StreamReader sr = new StreamReader(@".\TeamMembers.txt");
            // go through the file read each line, and build teams
            string Line = sr.ReadLine();
            TeamModel team = new TeamModel();
            PersonModel teamMember = new PersonModel();
            while (Line != null)
            {
                string [] result = Line.Split(',');
                teamMember.id = int.Parse(result[0]);
                teamMember.FirstName = result[2];
                teamMember.LastName = result[3];
                teamMember.CellPhoneNumber = result[4];
                teamMember.EmailAddress = result[5];    
                if (team.TeamName != result [1] )
                {
                    team.id += 1;
                    team.TeamName = result[1];
                    teams.Add(team);
                    team = new TeamModel();
                }
                if (team.TeamName == result[1])
                {
                    team.TeamMembers.Add(teamMember);
                }
                Line = sr.ReadLine();
            }
            sr.Close();
            return teams;
        }
    }
}
