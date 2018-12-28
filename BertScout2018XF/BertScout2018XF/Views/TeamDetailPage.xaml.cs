using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BertScout2018XF.Models;
using BertScout2018XF.ViewModels;

namespace BertScout2018XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetailPage : ContentPage
    {
        TeamDetailViewModel viewModel;

        public TeamDetailPage(TeamDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TeamDetailPage()
        {
            InitializeComponent();

            var item = new Team
            {
                Number = "0001",
                Name = "Team Name"
            };

            viewModel = new TeamDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}