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
        public EntityFrame()
        {
            InitializeComponent();
            Display();
        }

        void Display()
        {
            nameBlock.Text = "Théo";
            lastnameBlock.Text = "Normand";
            mailBlock.Text = "tnormand@albi.fr";
            phoneBlock.Text = "0610101010";
            addressBlock.Text = "18, avenue de la touze";
            complementBlock.Text = null;
            zipcodeBlock.Text = "33000";
            cityBlock.Text = "Bordeaux";
            descriptionBlock.Text = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.";
            
        }
    }
}
