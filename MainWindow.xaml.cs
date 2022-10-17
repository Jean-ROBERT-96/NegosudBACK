using NegoSUDBack.WindowInterfaces.Frames;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace NegoSUDBack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityFrame frame;

        public MainWindow()
        {
            InitializeComponent();
            frame = new EntityFrame();
            Display();
        }

        void Display()
        {
            scrollFrame.Children.Add(new Frame { Margin = new Thickness(2, 5, 2, 5), Content = frame });
        }
    }
}
