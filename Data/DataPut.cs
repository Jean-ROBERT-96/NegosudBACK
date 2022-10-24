using NegoSUDBack.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NegoSUDBack.Data
{
    public class DataPut
    {
        public static async void ArticlePut(Article article)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");

                var put = new
                {
                    id = article.id,
                    name = article.name,
                    year = article.year,
                    price = article.price,
                    quantity = article.quantity,
                    idFamily = article.idFamily,
                    description = article.description,
                    image = "url"
                };

                var content = new StringContent(JsonConvert.SerializeObject(put), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"article/{article.id.ToString()}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"L'article {article.name} a été modifié.", "Modification réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"L'article {article.name} n'a pas été modifié : {response.StatusCode}", "Modification échoué", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static async void FamilyPut(Family family)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");

                var put = new
                {
                    id = family.id,
                    type = family.type,
                    description = family.description
                };

                var content = new StringContent(JsonConvert.SerializeObject(put), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"family/{family.id.ToString()}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"La famille de produit {family.type} a été modifié.", "Modification réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"La famille de produit {family.type} n'a pas été modifié : {response.StatusCode}", "Modification échoué", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
