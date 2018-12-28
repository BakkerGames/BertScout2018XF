using System;

using BertScout2018XF.Models;

namespace BertScout2018XF.ViewModels
{
    public class TeamDetailViewModel : BaseViewModel
    {
        public Team Team { get; set; }
        public TeamDetailViewModel(Team team = null)
        {
            Title = team?.Number;
            Team = team;
        }
    }
}
