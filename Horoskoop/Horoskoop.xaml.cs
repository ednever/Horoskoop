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
        List<string> pildid = new List<string> { "capricorn", "aquarius", "pisces", "aries", "taurus", "gemini", "cancer", "leo", "virgo", "libra", "scorpio", "sagittarius" };
        Dictionary<string, string> horoskoop = new Dictionary<string, string>();
        DatePicker datePicker;
        Image image;
        Picker picker;

        public Horoskoop()
        {
            picker = new Picker();

            for (int i = 0; i < months.Count; i++)
            {
                horoskoop.Add(tahtkujud[i], months[i]);
                picker.Items.Add(tahtkujud[i]); 
            }
            picker.PropertyChanged += Picker_PropertyChanged;
                        
            datePicker = new DatePicker
            {
                Format = "dd.MM.yyyy",                
            };
            datePicker.DateSelected += DatePicker_DateSelected;

            image = new Image
            {
                HeightRequest = 200,
                WidthRequest = 200,
            };

            StackLayout st1 = new StackLayout
            {
                Children = { datePicker, picker, image }
            };

            StackLayout st = new StackLayout
            {
                Children = { st1 }
            };
            Content = st;
        }

        async void Picker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (picker.SelectedItem != null)
            {
                await Task.Delay(10);
                datePicker.Date = new DateTime(datePicker.Date.Year, int.Parse("0" + (months.IndexOf(horoskoop[picker.SelectedItem.ToString()]) + 1).ToString()), 01);
            }                                                  
        }

        void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            picker.SelectedIndex = datePicker.Date.Month - 1;
            image.Source = ImageSource.FromFile(pildid[picker.SelectedIndex] + ".png");
        }
    }
}