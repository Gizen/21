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
        int[] deck;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeDeck()
        {
            deck = new int[52];
            for (int i = 0; i < 52; i++)
            {
                deck[i] = i + 1;
            }
        }
        private void Shuffle(int number)
        {
            for (int i = 0; i < 1000000; i++)
            {
                int slot1 = rnd.Next(0, 52);
                int slot2 = slot1 - 1;
                if (slot2 == -1)
                {
                    slot2 = 51;
                }
                int number1 = deck[slot1];
                int number2 = deck[slot2];
                deck[slot1] = number2;
                deck[slot2] = number1;
            }
        }


    }
}
