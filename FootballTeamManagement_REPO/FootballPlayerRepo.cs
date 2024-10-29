using FootballTeamManagement_BusinessObject.Models;
using FootballTeamManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagement_REPO
{
    public class FootballPlayerRepo : IFootballPlayerRepo
    {
        public bool AddProfile(FootballPlayer profile)
        => FootballPlayerDAO.Instance.AddProfile(profile);

        public bool DeleteProfile(string profileId)
        => FootballPlayerDAO.Instance.DeleteProfile(profileId);

        public List<FootballPlayer> GetListProfiles()
        => FootballPlayerDAO.Instance.GetListProfiles();

        public FootballPlayer GetProfileById(string id)
        => FootballPlayerDAO.Instance.GetProfileById(id);

        public bool UpdateProfile(FootballPlayer profile)
        => FootballPlayerDAO.Instance.UpdateProfile(profile);
    }
}
