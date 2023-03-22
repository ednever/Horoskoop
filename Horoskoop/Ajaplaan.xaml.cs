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
    public partial class Ajaplaan : ContentPage
    {
        Label lbl;
        List<string> tegevused = new List<string> { "Soojendus", "Hommikusöök", "Eesti keel", "Matemaatika", "Vene keel", "Lõuna", "Füüsika", "Keemia", "Lillede kastmine", "Trenn", "Õhtusöök", "Kodutöö tegemine" };
        List<string> pildid = new List<string> { "warmup", "muna", "eesti", "matem", "vene", "loun", "fuusika", "keemia", "lill", "gym", "ohtusook", "kodutoo" };

        public Ajaplaan()
        {            
            StackLayout st1 = new StackLayout { Orientation = StackOrientation.Vertical };

            lbl = new Label
            {
                Text = "Ajaplaan",
                FontSize = 24,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for (int i = 1; i <= 12; i++)
            {                
                Image image = new Image
                {
                    AutomationId = (i - 1).ToString(),
                    Source = ImageSource.FromFile(pildid[i - 1] + ".jpg"),
                    Aspect = Aspect.AspectFit,
                    WidthRequest = 100,
                    HeightRequest = 100,
                };                
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                image.GestureRecognizers.Add(tap);

                TimePicker timePicker = new TimePicker { Time = new TimeSpan(i + 7, 0, 0), FontSize = 16 };

                Frame frame1 = new Frame
                {                        
                    BorderColor = Color.Black,
                    BackgroundColor = Color.Transparent,
                    CornerRadius = 5,
                    WidthRequest = 75, 
                    Content = timePicker
                };

                Label label = new Label
                {
                    Text = tegevused[i - 1],
                    FontSize = 15,
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                StackLayout stackLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { image, frame1, label } };
                Frame frame = new Frame
                {
                    BorderColor = Color.Black,
                    BackgroundColor = Color.Transparent,
                    CornerRadius = 5,
                    Content = stackLayout
                };
                st1.Children.Add(frame);
            }

            StackLayout st = new StackLayout { Children = { lbl, st1 } };
            ScrollView scrollView = new ScrollView { Content = st };
            Content = scrollView;
        }

        void Tap_Tapped(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            ContentPage contentPage = new ContentPage
            {
                //IsVisible = false,
                WidthRequest = 300,
                HeightRequest= 200,
            };
            //contentPage.
                        
        }
    }
}