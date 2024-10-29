using FootballTeamManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamManagement_DAO
{
    public class FootballPlayerDAO
    {
        private GermanyEuro2024DBContext _context;
        private static FootballPlayerDAO instance = null;

        public FootballPlayerDAO()
        {
            _context = new GermanyEuro2024DBContext();
        }

        public static FootballPlayerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FootballPlayerDAO();
                }
                return instance;
            }
        }

        public FootballPlayer GetProfileById(string id)
        {
            return _context.FootballPlayer.FirstOrDefault(u => u.PlayerId == id);
        }

        public List<FootballPlayer> GetListProfiles()
        {
            return _context.FootballPlayer.ToList();
        }

        public bool AddProfile(FootballPlayer profile)
        {
            bool isSuccess = false;
            try
            {
                if (profile != null)
                {
                    _context.FootballPlayer.Add(profile);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding profile: {ex.Message}");
            }
            return isSuccess;
        }

        public bool DeleteProfile(string profileId)
        {
            bool isSuccess = false;
            try
            {
                var profile = GetProfileById(profileId);
                if (profile != null)
                {
                    _context.FootballPlayer.Remove(profile);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting profile: {ex.Message}");
            }
            return isSuccess;
        }

        public bool UpdateProfile(FootballPlayer profile)
        {
            bool isSuccess = false;
            try
            {
                var existingProfile = GetProfileById(profile.PlayerId);
                if (existingProfile != null)
                {
                    // Update the properties as needed
                    existingProfile.PlayerName = profile.PlayerName;
                    existingProfile.Achievements = profile.Achievements;
                    existingProfile.Award = profile.Award;
                    existingProfile.Birthday = profile.Birthday;
                    existingProfile.FootballTeamId = profile.FootballTeamId;
                    existingProfile.OriginCountry = profile.OriginCountry;

                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating profile: {ex.Message}");
            }
            return isSuccess;
        }
    }
}
