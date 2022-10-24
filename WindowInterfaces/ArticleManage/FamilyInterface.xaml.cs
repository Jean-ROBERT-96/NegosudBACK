using NegoSUDBack.Data;
using NegoSUDBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Logique d'interaction pour FamilyInterface.xaml
    /// </summary>
    public partial class FamilyInterface : Window
    {
        private static FamilyInterface _instance;
        Family family;
        bool edit = false;

        private FamilyInterface()
        {
            InitializeComponent();
            familyBlock.Text = "Création de famille";
            nameBox.IsReadOnly = false;
            descriptionBlock.IsReadOnly = false;
            validButton.Visibility = Visibility.Visible;
        }

        private FamilyInterface(Family f)
        {
            InitializeComponent();
            family = f;
            Display();
        }

        private FamilyInterface(Family f, string? type) : this()
        {
            family = f;
            edit = true;
            Display();
        }

        public static FamilyInterface GetInstance(Family f, string? type = null)
        {
            if(_instance == null && type == null)
                _instance = new FamilyInterface(f);

            if (_instance == null && type == "add")
                _instance = new FamilyInterface();

            if (_instance == null && type == "edit")
                _instance = new FamilyInterface(f, type);

            _instance.Show();
            return _instance;
        }

        void Display()
        {
            familyBlock.Text = $"Famille : {family.type}";
            nameBox.Text = family.type;
            descriptionBlock.Text = family.description;
        }

        private void validButton_Click(object sender, RoutedEventArgs e)
        {
            if(family == null)
            {
                DataPost.FamilyPost(new Family
                {
                    type = nameBox.Text,
                    description = descriptionBlock.Text
                });
            }

            if(edit)
            {
                family.type = nameBox.Text;
                family.description = descriptionBlock.Text;
                DataPut.FamilyPut(family);
            }
            _instance = null;
            Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            _instance = null;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instance = null;
        }
    }
}
