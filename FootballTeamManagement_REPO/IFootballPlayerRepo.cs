using FootballTeamManagement_BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_REPO
{
    public interface IFootballPlayerRepo
    {
        public FootballPlayer GetProfileById(string id);

        public List<FootballPlayer> GetListProfiles();

        public bool AddProfile(FootballPlayer profile);

        public bool DeleteProfile(string profileId);

        public bool UpdateProfile(FootballPlayer profile);
    }
}
