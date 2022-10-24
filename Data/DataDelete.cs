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
    public class DataDelete
    {
        public static async void ArticleDelete(Article article)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");
                HttpResponseMessage response = await client.DeleteAsync($"article/{article.id.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"L'article {article.name} a été supprimé.", "Suppression réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"L'article {article.name} n'a pas été supprimé : {response.StatusCode}", "Suppression échoué", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static async void FamilyDelete(Family family)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");
                HttpResponseMessage response = await client.DeleteAsync($"family/{family.id.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"La famille de produit {family.type} a été supprimé.", "Suppression réussite", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"La famille de produit {family.type} n'a pas été supprimé : {response.StatusCode}", "Suppression échoué", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
