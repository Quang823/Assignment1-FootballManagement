using FootballTeamManagement_BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_REPO
{
    public interface IFootballTeamRepo
    {
        public FootballTeam GetById(string id);
        public List<FootballTeam> GetLists();
    }
}
