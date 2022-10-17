using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace NegoSUDBack.WindowInterfaces
{
    /// <summary>
    /// Logique d'interaction pour ArticleInterface.xaml
    /// </summary>
    public partial class ArticleInterface : Window
    {
        private static ArticleInterface _interface;
        private ArticleInterface()
        {
            InitializeComponent();
        }

        public static ArticleInterface GetInstance()
        {
            if(_interface == null)
                _interface = new ArticleInterface();

            return _interface;
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            _interface = null;
        }
    }
}
