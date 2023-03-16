using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Horoskoop
{
    public partial class MainPage : ContentPage
    {
        List<ContentPage> contentPages = new List<ContentPage>() { new Test() };
        List<string> tekstid = new List<string> { "Test" };

        public MainPage()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Beige,
                Children = { }
            };

            for (int i = 0; i < tekstid.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.CornflowerBlue,
                    TextColor = Color.Black,
                };
                button.Clicked += Button_Clicked;
                st.Children.Add(button);
            }
            Content = st;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            await Navigation.PushAsync(contentPages[b.TabIndex]);
        }
    }
}
