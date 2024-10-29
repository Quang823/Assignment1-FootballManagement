using FootballTeamManagement_BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_REPO
{
    public interface IAccountRepo
    {
        public Uefaaccount GetAccountByEmail(string email);
        public List<Uefaaccount> GetUsers();
    }
}
