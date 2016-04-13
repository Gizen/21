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

namespace _21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int dealerCard1;
        int dealerCard2;
        int playerCard1;
        int playerCard2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Card()
        {

        }

        private void RandomNumber(int number)
        {
            number = rnd.Next(1, 54);
        }
    }
}
