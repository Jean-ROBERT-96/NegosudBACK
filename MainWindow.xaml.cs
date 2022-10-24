using NegoSUDBack.Models;
using NegoSUDBack.WindowInterfaces;
using NegoSUDBack.WindowInterfaces.Frames;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
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
        public List<Article> listArticle { get; set; }
        public List<Family> listFamily { get; set; }

        public MainWindow()
        {
            Application.Current.MainWindow = this;
            InitializeComponent();
            client = new HttpClient();
            listArticle = new List<Article>();
            listFamily = new List<Family>();
            Initialization("article");
        }

        public async void Initialization(string type)
        {
            string data = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/");
                HttpResponseMessage response;
                switch (type)
                {
                    case "article":
                        response = await client.GetAsync("article");
                        addButton.Tag = type;
                        addButton.Content = "Ajouter un article";
                        break;
                    case "family":
                        response = await client.GetAsync("family");
                        addButton.Tag = type;
                        addButton.Content = "Ajouter une famille";
                        break;
                    case "client":
                        response = await client.GetAsync("client");
                        addButton.Tag = type;
                        addButton.Content = "Ajouter un client";
                        break;
                    case "vendor":
                        response = await client.GetAsync("vendor");
                        addButton.Tag = type;
                        addButton.Content = "Ajouter un fournisseur";
                        break;
                    default:
                        response = null;
                        break;
                }

                data = response.Content.ReadAsStringAsync().Result;
            }

            if (data != "[]")
            {
                switch (type)
                {
                    case "article":
                        listArticle = JsonConvert.DeserializeObject<List<Article>>(data).ToList();
                        break;
                    case "family":
                        listFamily = JsonConvert.DeserializeObject<List<Family>>(data).ToList();
                        break;
                    default:
                        scrollFrame.Children.Add(new TextBlock { Margin = new Thickness(2, 5, 2, 5), Text = "Non disponible.", TextAlignment = TextAlignment.Center });
                        break;
                }
                Display(type);
            }
            else
            {
                scrollFrame.Children.Add(new TextBlock { Margin = new Thickness(2, 5, 2, 5), Text = "Aucun résultat.", TextAlignment = TextAlignment.Center });
            }
        }

        void Display(string type)
        {
            if (type == "article")
            {
                foreach (Article a in listArticle)
                {
                    scrollFrame.Children.Add(new Frame { Margin = new Thickness(2, 5, 2, 5), Content = new EntityFrame(a) });
                }
            }
            else if (type == "family")
            {
                foreach (Family f in listFamily)
                {
                    scrollFrame.Children.Add(new Frame { Margin = new Thickness(2, 5, 2, 5), Content = new EntityFrame(f) });
                }
            }
        }

        private void articleFrameButton_Click(object sender, RoutedEventArgs e)
        {
            scrollFrame.Children.Clear();
            if(listArticle != null)
                listArticle.Clear();
            Initialization("article");
        }

        private void familyFrameButton_Click(object sender, RoutedEventArgs e)
        {
            scrollFrame.Children.Clear();
            if(listArticle != null)
                listFamily.Clear();
            Initialization("family");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (addButton.Tag == "article")
                ArticleInterface.GetInstance(null, "add").Show();
            else if (addButton.Tag == "family")
                FamilyInterface.GetInstance(null, "add").Show();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            var rep = MessageBox.Show("Voulez vous quitter? Toutes informations non sauvegadé sera perdu.", "Quitter le logiciel", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(rep == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
