using FootballTeamManagement_BusinessObject.Models;
using FootballTeamManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_REPO
{
    public class FootballTeamRepo : IFootballTeamRepo
    {
        public FootballTeam GetById(string id)
            => FootballTeamDAO.Instance.GetById(id);

        public List<FootballTeam> GetLists()
            => FootballTeamDAO.Instance.GetLists();

    }
}
