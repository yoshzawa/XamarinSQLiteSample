using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsSQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsSQLite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
		public ResultPage ()
		{
			InitializeComponent ();
		}

        protected  override async void OnAppearing()
        {
            base.OnAppearing();
            var result = await App.Database.GetItemsAsync();

            int size = result.Count;
            await DisplayAlert("ResultPage", "record=" + size , "OK");

            var layout2 = new StackLayout() { Spacing = 10 };

            foreach(var location in result)
            {
                var layout3 = new StackLayout() ;
                layout3.Children.Add(new Label() { Text = "name:" + location.Name });
                layout3.Children.Add(new Label() { Text = "Latitude:" + location.Latitude });
                layout3.Children.Add(new Label() { Text = "Longitude:" + location.Longitude });
                layout2.Children.Add(layout3);
            }

            layout.Children.Add( layout2);


        }
    }


}