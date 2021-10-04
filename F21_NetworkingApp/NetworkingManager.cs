using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace F21_NetworkingApp
{
    public class NetworkingManager
    {

        private string url = "https://api.spoonacular.com";
        private string key = "8116c82ba63a49ba86bd5145aa25b245";
        private string restOfURL1 = "/food/ingredients/search?query=";
        private string restOfURL2 = "&apiKey=";


        HttpClient client = new HttpClient();
        public NetworkingManager()
        {
        }


        public async Task<List<IngredientClass>> getInredient(string query)
        {
            string completeURL = url + restOfURL1 + query + restOfURL2 + key;
            var response = await client.GetAsync(completeURL);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<IngredientClass>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (jsonString);
                var array = dic.ElementAt(0).Value;
                var finalList = JsonConvert.DeserializeObject<List<IngredientClass>>
                     (array.ToString());
                return finalList;
            }
        }
    }
}
