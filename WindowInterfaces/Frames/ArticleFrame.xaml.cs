using NegoSUDBack.WindowInterfaces.Frames;
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

namespace NegoSUDBack.WindowInterfaces
{
    /// <summary>
    /// Logique d'interaction pour ArticleFrame.xaml
    /// </summary>
    public partial class ArticleFrame : Page
    {
        EntityFrame frame;
        public ArticleFrame()
        {
            InitializeComponent();
            frame = new EntityFrame();
            Display();
        }

        void Display()
        {
            articleScroll.Children.Add(new Frame { Margin = new Thickness(2, 5, 2, 5), Content = frame });
        }
    }
}
