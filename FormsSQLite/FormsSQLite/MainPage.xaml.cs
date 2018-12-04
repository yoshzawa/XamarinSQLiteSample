using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FormsSQLite;

namespace FormsSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btn1.Clicked += Btn1clicked;
            btn2.Clicked += Btn2clicked;
            btnView.Clicked += BtnVWclicked;

        }

        private void Btn1clicked(object sender, EventArgs e)
        {
            LocationItem item1 = new LocationItem()
            {
                Latitude = 37.7540613F,
                Longitude = 140.4682551F,
                Name = "キッチンカロリー"
            };
            Save(item1);
        }

        private async void Save(LocationItem item1)
        {
            await App.Database.SaveItemAsync(item1);
            await DisplayAlert("DATA1","RECORDED","OK");
        }

        private void Btn2clicked(object sender, EventArgs e)
        {
            LocationItem item2 = new LocationItem()
            {
                Latitude = 38.2192076F,
                Longitude = 140.868182F,
                Name = "ビストロ アンプル"
            };
            Save(item2);
        }

        private void BtnVWclicked(object sender, EventArgs e)
        {
                        Navigation.PushModalAsync(new NavigationPage(new ResultPage()));

        }
    }
}
