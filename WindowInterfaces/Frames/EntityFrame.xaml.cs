using NegoSUDBack.Data;
using NegoSUDBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NegoSUDBack.WindowInterfaces.Frames
{
    /// <summary>
    /// Logique d'interaction pour EntityFrame.xaml
    /// </summary>
    public partial class EntityFrame : Page
    {
        Article? article;
        Family? family;
        MainWindow main;

        public EntityFrame()
        {
            InitializeComponent();
            main = (MainWindow)Application.Current.MainWindow;
        }

        public EntityFrame(Article a) : this()
        {
            article = a;
            nameBlock.Text = $"Nom : {article.name}";
            lastnameBlock.Text = $"Année : {article.year}";
            descriptionBlock.Text = article.description;
            phoneBlock.Text = $"Prix : {article.price}€";
            mailBlock.Text = $"Quantité : {article.quantity}";
            addressBlock.Text = $"Famille : {article.idFamily}";
        }

        public EntityFrame(Family f) : this()
        {
            family = f;
            nameBlock.Text = $"Nom : {family.type}";
            descriptionBlock.Text = family.description;
        }

        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            if (article != null)
                ArticleInterface.GetInstance(article);
            else if (family != null)
                FamilyInterface.GetInstance(family);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (article != null)
                ArticleInterface.GetInstance(article, "edit");
            else if (family != null)
                FamilyInterface.GetInstance(family, "edit");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var rep = MessageBox.Show("Voullez vous supprimer cette item? L'action sera irréversible.", "Supprimer l'objet", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (article != null)
            {
                if(rep == MessageBoxResult.Yes)
                    DataDelete.ArticleDelete(article);
            }
            else if (family != null)
            {
                if (rep == MessageBoxResult.Yes)
                    DataDelete.FamilyDelete(family);
            }
            Reload();
        }

        void Reload()
        {
            main.scrollFrame.Children.Clear();
            if (main.listArticle != null && article != null)
            {
                main.listArticle.Clear();
                main.Initialization("article");
            }

            if (main.listFamily != null && family != null)
            {
                main.listFamily.Clear();
                main.Initialization("family");
            }
        }
    }
}
