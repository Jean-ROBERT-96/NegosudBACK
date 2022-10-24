using NegoSUDBack.Data;
using NegoSUDBack.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NegoSUDBack.WindowInterfaces
{
    /// <summary>
    /// Logique d'interaction pour ArticleInterface.xaml
    /// </summary>
    public partial class ArticleInterface : Window
    {
        private static ArticleInterface _instance;
        Article article;
        bool edit = false;

        private ArticleInterface()
        {
            InitializeComponent();
            typeBlock.Text = "Création d'article";
            nameBlock.IsReadOnly = false;
            yearBlock.IsReadOnly = false;
            priceBlock.IsReadOnly = false;
            quantityBlock.IsReadOnly = false;
            familyBlock.IsReadOnly = false;
            descriptionBlock.IsReadOnly = false;
        }
        private ArticleInterface(Article a)
        {
            InitializeComponent();
            article = a;
            uploadButton.Visibility = Visibility.Hidden;
            Display();
        }

        private ArticleInterface(Article a, string type = null) : this()
        {
            article = a;
            edit = true;
            Display();
            validButton.Content = "Valider";
            priceBlock.Text = $"{article.price}";
        }

        public static ArticleInterface GetInstance(Article a, string? type = null)
        {
            if(_instance == null && type == null)
                _instance = new ArticleInterface(a);

            if (_instance == null && type == "add")
                _instance = new ArticleInterface();

            if (_instance == null && type == "edit")
                _instance = new ArticleInterface(a, "edit");

            _instance.Show();
            return _instance;
        }

        void Display()
        {
            typeBlock.Text = $"Article : {article.name}";
            nameBlock.Text = article.name;
            yearBlock.Text = article.year;
            priceBlock.Text = $"{article.price}€";
            quantityBlock.Text = article.quantity.ToString();
            familyBlock.Text = article.idFamily.ToString();
            descriptionBlock.Text = article.description;
            validButton.Content = "Commander";
            validButton.Tag = "order";
        }

        private async void validButton_Click(object sender, RoutedEventArgs e)
        {
            if (validButton.Tag == "order")
            {
                //TODO : Afficher la fenetre de commande
            }

            if(article == null)
            {
                DataPost.ArticlePost(new Article
                {
                    name = nameBlock.Text,
                    year = yearBlock.Text,
                    description = descriptionBlock.Text,
                    price = float.Parse(priceBlock.Text),
                    quantity = int.Parse(quantityBlock.Text),
                    idFamily = int.Parse(familyBlock.Text)
                });
            }

            if(edit)
            {
                article.name = nameBlock.Text;
                article.year = yearBlock.Text;
                article.description = descriptionBlock.Text;
                article.price = float.Parse(priceBlock.Text);
                article.quantity = int.Parse(quantityBlock.Text);
                article.idFamily = int.Parse(familyBlock.Text);
                DataPut.ArticlePut(article);
            }
            _instance = null;
            Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            _instance = null;
            Close();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            _instance = null;
        }
    }
}
