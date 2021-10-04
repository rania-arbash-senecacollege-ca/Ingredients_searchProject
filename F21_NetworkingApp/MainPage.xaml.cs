using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace F21_NetworkingApp
{
    public partial class MainPage : ContentPage
    {
        String query;
        ObservableCollection<IngredientClass> ingredients;
        NetworkingManager manager = new NetworkingManager();
        public MainPage()
        {
            InitializeComponent();
           // 

        }


        protected  override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        async void  SearchBar_SearchButtonPressed(System.Object sender,
            System.EventArgs e)
        {

           var listFromAPI = await manager.getInredient(query);
           ingredients = new ObservableCollection<IngredientClass>();
            foreach (IngredientClass i in listFromAPI)
            {
                var imageURL = "https://spoonacular.com/cdn/ingredients_100x100/" + i.image;
                ingredients.Add(new IngredientClass(i.id,i.name,i.image,imageURL));
            }
            ingredintList.ItemsSource = ingredients;

        }


        void SearchBar_TextChanged(System.Object sender,
            Xamarin.Forms.TextChangedEventArgs e)
        {
           query = e.NewTextValue;
        }


    }
}
