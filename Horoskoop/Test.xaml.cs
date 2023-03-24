using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horoskoop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        Label lbl, lbl2;
        BoxView box;
        bool tapped = true;
        public Test()
        {
            Label label = new Label { Text = "Vajuta nuppu ja hoia hinge", FontSize = 20 };
            lbl = new Label { Text = string.Empty, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontSize = 20 };
            box = new BoxView 
            { 
                Color = Color.Red, 
                CornerRadius = 100, 
                WidthRequest= 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            lbl2 = new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontSize = 20 };
            StackLayout st1 = new StackLayout { Children = { label, lbl, box, lbl2 }, HorizontalOptions = LayoutOptions.Center };
            StackLayout st = new StackLayout { Children = { st1 } };
            Content = st;
        }

        async void Tap_Tapped(object sender, EventArgs e)
        {
            if (tapped)
            {
                box.IsEnabled = false;
                lbl.Text = "Дышите";
                for (int i = 59; i >= 0; i--)
                {                    
                    box.WidthRequest += 1;
                    box.HeightRequest += 1;
                    await Task.Delay(15);                    
                }
                box.IsEnabled = true;
                tapped= false;
            }
            else
            {
                box.IsEnabled = false;
                lbl.Text = "Не дышите";
                for (int i = 59; i >= 0; i--)
                {                    
                    box.WidthRequest -= 1;
                    box.HeightRequest -= 1;
                    await Task.Delay(15);
                }
                box.IsEnabled = true;
                tapped = true;
            }
            
        }
    }
}