using FootballTeamManagement_BusinessObject.Models;
using FootballTeamManagement_DAO;
using FootballTeamManagement_REPO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballTeamManagement_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private int? Role = 0;
        private IFootballTeamRepo footballTeamRepo;
        private IFootballPlayerRepo footballPlayerRepo;
        public ManagementWindow()
        {
            InitializeComponent();
            footballTeamRepo = new FootballTeamRepo();
            footballPlayerRepo = new FootballPlayerRepo();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataInit();
        }

        private void LoadDataInit()
        {
            footballTeamRepo = new FootballTeamRepo();
            footballPlayerRepo = new FootballPlayerRepo();
            this.dtgFootballProfile.ItemsSource = footballPlayerRepo.GetListProfiles();
            this.cmbFootballTeam.ItemsSource = footballTeamRepo.GetLists();
            this.cmbFootballTeam.DisplayMemberPath = "TeamTitle";
            this.cmbFootballTeam.SelectedValuePath = "FootballTeamId";

            txtPlayerID.Text = "";
            txtPlayerName.Text = "";
            txtBirthday.Text = "";
            txtCountry.Text = "";
            txtAchievement.Text = "";
            txtAward.Text = "";
            cmbFootballTeam.SelectedValue = "";
        }
        public ManagementWindow(int? roleID)
        {
            InitializeComponent();
            footballTeamRepo = new FootballTeamRepo();
            footballPlayerRepo = new FootballPlayerRepo();
            this.Role = roleID;
            switch (Role)
            {
                case 1:
                    break;
                case 2:
                    this.btnAdd.IsEnabled = false;
                    this.btnUpdate.IsEnabled = false;
                    this.btnDelete.IsEnabled = false;
                    this.btnSearch.IsEnabled = false;
                    break;
                case 3:
                    break;
                default:
                    this.Close();
                    break;
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtPlayerID.Text) ||
                string.IsNullOrWhiteSpace(txtPlayerName.Text) ||
                string.IsNullOrWhiteSpace(txtBirthday.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                string.IsNullOrWhiteSpace(txtAchievement.Text) ||
                string.IsNullOrWhiteSpace(txtAward.Text) ||
                cmbFootballTeam.SelectedValue == null)
            {
                MessageBox.Show("All fields are required.");
                return false;
            }

            DateTime birthday;
            if (!DateTime.TryParse(txtBirthday.Text, out birthday) || birthday > new DateTime(2004, 1, 1))
            {
                MessageBox.Show("Birthday must be on or before 01/01/2004.");
                return false;
            }

            string playerName = txtPlayerName.Text;
            if (playerName.Length < 3 || playerName.Length > 100)
            {
                MessageBox.Show("PlayerName must be between 3 and 100 characters.");
                return false;
            }
         
            var words = playerName.Split(' ');
            foreach (var word in words)
            {
                if (!char.IsUpper(word[0]) && !char.IsDigit(word[0]))
                {
                    MessageBox.Show("Each word of PlayerName must start with a capital letter or a digit.");
                    return false;
                }

                if (word.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    MessageBox.Show("PlayerName cannot contain special characters.");
                    return false;
                }
            }       
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                if (footballPlayerRepo.GetProfileById(txtPlayerID.Text) != null)
                {
                    MessageBox.Show("Player ID already exists. Please use a different ID.");
                    return;
                }
                FootballPlayer player = new FootballPlayer();
                player.PlayerId = txtPlayerID.Text;
                player.PlayerName = txtPlayerName.Text;
                player.Birthday = DateTime.Parse(txtBirthday.Text);
                player.OriginCountry = txtCountry.Text;
                player.Achievements = txtAchievement.Text;
                player.Award = txtAward.Text;
                player.FootballTeamId = cmbFootballTeam.SelectedValue.ToString();

                if (footballPlayerRepo.AddProfile(player))
                {
                    MessageBox.Show("Add Successful!");
                    LoadDataInit();
                }
                else
                {
                    MessageBox.Show("Add Failed!");
                }
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

            if (row != null)
            {
                DataGridCell rowCell =
                    dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string playerId = ((TextBlock)rowCell.Content).Text;

                FootballPlayer player = footballPlayerRepo.GetProfileById(playerId);
                if (player != null)
                {
                    txtPlayerID.Text = player.PlayerId;
                    txtPlayerName.Text = player.PlayerName;
                    txtBirthday.Text = player.Birthday.ToString();
                    txtCountry.Text = player.OriginCountry;
                    txtAchievement.Text = player.Achievements;
                    txtAward.Text = player.Award;
                    cmbFootballTeam.SelectedValue = player.FootballTeamId;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string playerId = txtPlayerID.Text;
            if (!string.IsNullOrEmpty(playerId) && footballPlayerRepo.DeleteProfile(playerId))
            {
                MessageBox.Show("Delete Successful!");
                LoadDataInit();
            }
            else
            {
                MessageBox.Show("Delete Failed!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string playerId = txtPlayerID.Text;
            if (!string.IsNullOrEmpty(playerId) && ValidateFields())
            {
                FootballPlayer player = footballPlayerRepo.GetProfileById(playerId);

                player.PlayerName = txtPlayerName.Text;
                player.Birthday = DateTime.Parse(txtBirthday.Text);
                player.OriginCountry = txtCountry.Text;
                player.Achievements = txtAchievement.Text;
                player.Award = txtAward.Text;
                player.FootballTeamId = cmbFootballTeam.SelectedValue.ToString();

                if (footballPlayerRepo.UpdateProfile(player))
                {
                    MessageBox.Show("Update Successful!");
                    LoadDataInit();
                }
                else
                {
                    MessageBox.Show("Update Failed!");
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {       
            string playerName = txtSearchPlayerName.Text.Trim();
            string achievement = txtSearchAchievement.Text.Trim();
     
            List<FootballPlayer> allPlayers = footballPlayerRepo.GetListProfiles();

     
            var filteredPlayers = allPlayers.Where(player =>
                (string.IsNullOrEmpty(playerName) || player.PlayerName.Contains(playerName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(achievement) || player.Achievements.Contains(achievement, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            dtgFootballProfile.ItemsSource = filteredPlayers;
        }

    }
}