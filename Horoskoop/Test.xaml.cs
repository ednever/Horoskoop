using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Horoskoop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        Label lbl;
        BoxView box;
        bool tapped = true;
        public Test()
        {
            AbsoluteLayout abs = new AbsoluteLayout();
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

            BoxView box2 = new BoxView
            {
                Color = Color.Black,
                CornerRadius = 100,
                WidthRequest = 159,
                HeightRequest = 159,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);

            AbsoluteLayout.SetLayoutBounds((BindableObject)box2, new Rectangle(0.1, 0.1, 200, 200));
            AbsoluteLayout.SetLayoutFlags((BindableObject)box2, AbsoluteLayoutFlags.PositionProportional);
            abs.Children.Add((View)box2);

            StackLayout st2 = new StackLayout { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Children = { abs, box }};
            StackLayout st1 = new StackLayout { Children = { label, lbl, st2 }, HorizontalOptions = LayoutOptions.Center };
            StackLayout st = new StackLayout { Children = { st1 } };
            Content = st;

            
        }

        async void Tap_Tapped(object sender, EventArgs e)
        {
            if (tapped)
            {
                box.IsEnabled = false;
                lbl.Text = "Hinga";
                for (int i = 59; i >= 0; i--)
                {                    
                    box.WidthRequest += 1;
                    box.HeightRequest += 1;
                    await Task.Delay(15);                    
                }
                box.IsEnabled = true;
                tapped = false;
            }
            else
            {
                box.IsEnabled = false;
                lbl.Text = "Ära hinga";
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