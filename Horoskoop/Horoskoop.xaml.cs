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
                Source = ImageSource.FromFile("muna.jpg"),
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

        void Picker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Picker pckr = (Picker)sender;
            //string a = horoskoop[pckr.SelectedItem.ToString()]; //Исправить ошибку

            //int month = months.IndexOf(horoskoop[pckr.SelectedItem.ToString()]) + 1;
            //datePicker.Date = new DateTime(0000, month, 00);
                                        
        }

        void DatePicker_DateSelected(object sender, DateChangedEventArgs e) //менять картинку в зависимости от месяца
        {
            image.Source = ImageSource.FromFile("scorpio.jpg");
        }
    }
}