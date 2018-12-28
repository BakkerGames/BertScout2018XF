using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using BertScout2018XF.Models;
using BertScout2018XF.Views;

namespace BertScout2018XF.ViewModels
{
    public class TeamsViewModel : BaseViewModel
    {
        public ObservableCollection<Team> Teams { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TeamsViewModel()
        {
            Title = "Browse";
            Teams = new ObservableCollection<Team>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewTeamPage, Team>(this, "AddItem", async (obj, team) =>
            {
                var newItem = team as Team;
                Teams.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Teams.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Teams.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}