using NegoSUDBack.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

namespace NegoSUDBack
{
    public partial class LoginInterface : Window
    {
        public LoginInterface()
        {
            InitializeComponent();
        }

        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://negoapi.fr:81/api/user/");
                var response = await client.GetAsync(userBox.Text);
                
                if(response.IsSuccessStatusCode)
                {
                    
                    var data = response.Content.ReadAsStringAsync().Result;
                    var json = JObject.Parse(data).ToObject<User>();
                    response.EnsureSuccessStatusCode();

                    if (passwordBox.Password == json.password)
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorect.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox.Password = "";
                    }
                }
                else
                {
                    MessageBox.Show("Utilisateur introuvable. Veuillez entrer un utilisateur valide.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                    userBox.Text = "";
                    passwordBox.Password = "";
                }
            }
        }
    }
}
