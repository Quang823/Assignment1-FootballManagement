
using FootballTeamManagement_BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_DAO
{
    public class AccountDAO
    {
        private GermanyEuro2024DBContext _context;
        private static AccountDAO instance = null; 

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            _context = new GermanyEuro2024DBContext();
        }

        public Uefaaccount GetAccountByEmail(string email)
        {
            return _context.Uefaaccount.Where(u => u.AccountEmail == email).FirstOrDefault();
        }

        public List<Uefaaccount> GetUsers()
        {
            return _context.Uefaaccount.ToList();
        }
    }
}
