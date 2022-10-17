using NegoSUDBack.Models;
using NegoSUDBack.WindowInterfaces.Frames;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NegoSUDBack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client;
        List<Article> listArticle;
        List<Family> listFamily;

        public MainWindow()
        {
            InitializeComponent();
            client = new HttpClient();
            Initialization("article");
        }

        async void Initialization(string type)
        {
            using(client)
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");
                HttpResponseMessage response;
                switch(type)
                {
                    case "article":
                        response = await client.GetAsync("article");
                        break;
                    case "family":
                        response = await client.GetAsync("family");
                        break;
                    case "client":
                        response = await client.GetAsync("client");
                        break;
                    case "vendor":
                        response = await client.GetAsync("vendor");
                        break;
                    default:
                        response = null;
                        break;
                }
                
                if(response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    switch(type)
                    {
                        case "article":
                            listArticle = JObject.Parse(data).ToObject<List<Article>>();
                            break;
                        case "family":
                            listFamily = JObject.Parse(data).ToObject<List<Family>>();
                            break;
                        default:
                            scrollFrame.Children.Add(new TextBlock { Margin = new Thickness(2, 5, 2, 5), Text = "Non disponible.", TextAlignment = TextAlignment.Center });
                            break;
                    }
                }
                else
                {
                    scrollFrame.Children.Add(new TextBlock { Margin = new Thickness(2, 5, 2, 5), Text = "Erreur de requête", TextAlignment = TextAlignment.Center });
                }
            }

            if(type == "article")
            {
                foreach(Article a in listArticle)
                {
                    scrollFrame.Children.Add(new Frame { Margin = new Thickness(2, 5, 2, 5), Content = new EntityFrame() });
                }
            }
            else if(type == "family")
            {
                foreach (Family f in listFamily)
                {
                    scrollFrame.Children.Add(new Frame { Margin = new Thickness(2, 5, 2, 5), Content = new EntityFrame() });
                }
            }
        }
    }
}
