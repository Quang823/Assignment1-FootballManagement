using FootballTeamManagement_BusinessObject.Models;
using FootballTeamManagement_REPO;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FootballTeamManagement_WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IAccountRepo accountRepo ;
        public LoginWindow()
        {
            InitializeComponent();
            accountRepo = new AccountRepo();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Uefaaccount account = accountRepo.GetAccountByEmail(txtEmail.Text);
            if (account != null && account.AccountPassword.Equals(txtPassword.Password))
            {
                int? roleId = account.Role;
                if (roleId == 1 || roleId == 4)
                {
                    MessageBox.Show("You have no permission to access this function!");
                }
                else
                {
                    ManagementWindow managementWindow = new ManagementWindow(roleId);
                    managementWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Account not found");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

