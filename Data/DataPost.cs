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
    public class DataPost
    {
        public static async void ArticlePost(Article article)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");

                var post = new
                {
                    name = article.name,
                    year = article.year,
                    price = article.price,
                    quantity = article.quantity,
                    idFamily = article.idFamily,
                    description = article.description,
                    image = "url"
                };

                var content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("article", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"L'article {article.name} a été créé.", "Création réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"L'article {article.name} n'a pas été créé : {response.StatusCode}", "Création échoué", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static async void FamilyPost(Family family)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");

                var post = new
                {
                    type = family.type,
                    description = family.description
                };

                var content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("family", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"La famille de produit {family.type} a été créé.", "Création réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"La famille de produit {family.type} n'a pas été créé : {response.StatusCode}", "Création échoué", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
