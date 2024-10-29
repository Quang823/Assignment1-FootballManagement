using FootballTeamManagement_BusinessObject.Models;
using FootballTeamManagement_DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_REPO
{
    public class AccountRepo : IAccountRepo
    {
        public Uefaaccount GetAccountByEmail(string email)
            => AccountDAO.Instance.GetAccountByEmail(email);

        public List<Uefaaccount> GetUsers()
            => AccountDAO.Instance.GetUsers();
    }
}
