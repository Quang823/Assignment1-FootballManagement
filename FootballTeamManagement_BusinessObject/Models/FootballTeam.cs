﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FootballTeamManagement_BusinessObject.Models;

public partial class FootballTeam
{
    public string FootballTeamId { get; set; }

    public string TeamTitle { get; set; }

    public string Country { get; set; }

    public string ManagerName { get; set; }

    public virtual ICollection<FootballPlayer> FootballPlayer { get; set; } = new List<FootballPlayer>();
}