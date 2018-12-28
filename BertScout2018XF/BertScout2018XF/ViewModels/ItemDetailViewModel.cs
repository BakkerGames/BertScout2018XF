using System;

using BertScout2018XF.Models;

namespace BertScout2018XF.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Team Team { get; set; }
        public ItemDetailViewModel(Team item = null)
        {
            Title = item?.Number;
            Team = item;
        }
    }
}
