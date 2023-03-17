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
    public partial class Horoskoop : ContentPage
    {
        List<string> months = new List<string> { "Jaanuar", "Veebruar", "Märts", "Aprill", "Mai", "Juuni", "Juuli", "August", "September", "Oktoober", "November", "Detsember" };
        List<string> tahtkujud = new List<string> { "Kaljukits", "Veevalaja", "Kalad", "Jäär", "Sõnn", "Kaksikud", "Vähk", "Lõvi", "Neitsi", "Kaalud", "Skorpion", "Ambur" };
        Dictionary<string, string> horoskoop = new Dictionary<string, string>();
        DatePicker datePicker;
        Image image;

        public Horoskoop()
        {
            //InitializeComponent();
            for (int i = 0; i < months.Count; i++)
            {
                horoskoop.Add(tahtkujud[i], months[i]);
            }

            datePicker = new DatePicker
            {
                Format = "dd.MM.yyyy",
            };
            datePicker.DateSelected += DatePicker_DateSelected;

            image = new Image
            {
                Source = "Aries.png",
                HeightRequest= 200,
                WidthRequest= 200,
                
                BackgroundColor = Color.Beige,
            };
            

            StackLayout st = new StackLayout
            {
                Children = { datePicker, image }
            };
            Content = st;
        }

        void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            image.Source = "Aquarius.png";
        }
    }
}