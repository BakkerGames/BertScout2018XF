using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BertScout2018XF.Models;

namespace BertScout2018XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Team Team { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Team = new Team
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Team);
            await Navigation.PopModalAsync();
        }
    }
}