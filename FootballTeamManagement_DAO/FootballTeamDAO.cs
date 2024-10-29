using FootballTeamManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_DAO
{
    public class FootballTeamDAO
    {
        private GermanyEuro2024DBContext _context;
        private static FootballTeamDAO instance = null;

        public FootballTeamDAO()
        {
            _context = new GermanyEuro2024DBContext();
        }

        public static FootballTeamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FootballTeamDAO();
                }
                return instance;
            }
        }

        public FootballTeam GetById(string id)
        {
            return _context.FootballTeam.Where(u => u.FootballTeamId == id).FirstOrDefault();
        }

        public List<FootballTeam> GetLists()
        {
            return _context.FootballTeam.ToList();
        }
    }
}
