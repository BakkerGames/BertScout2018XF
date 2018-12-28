using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BertScout2018XF.Models;
using BertScout2018XF.Views;
using BertScout2018XF.ViewModels;

namespace BertScout2018XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsPage : ContentPage
    {
        TeamsViewModel viewModel;

        public TeamsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TeamsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Team;
            if (item == null)
                return;

            await Navigation.PushAsync(new TeamDetailPage(new TeamDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTeamPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Teams.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}