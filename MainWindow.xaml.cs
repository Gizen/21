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
        int[] deckNumber;
        string[] deckNames;
        int nextCard = 0;
        string playerText;
        int playerScore = 0;
        int dealerScore = 0;
        string dealerText;
        int playerMoney = 500;
        int betAmount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeDecks()
        {
            deck = new int[52];
            for (int i = 0; i < 52; i++)
            {
                deck[i] = i + 1;               
            }
            deckNumber = new int[52];
            deckNames = new string[52];
            deckNumber[0] = 1;
            deckNames[0] = "Ace of Spades";
            deckNumber[1] = 2;
            deckNames[1] = "Two of Spades";
            deckNumber[2] = 3;
            deckNames[2] = "Three of Spades";
            deckNumber[3] = 4;
            deckNames[3] = "Four of Spades";
            deckNumber[4] = 5;
            deckNames[4] = "Five of Spades";
            deckNumber[5] = 6;
            deckNames[5] = "Six of Spades";
            deckNumber[6] = 7;
            deckNames[6] = "Seven of Spades";
            deckNumber[7] = 8;
            deckNames[7] = "Eight of Spades";
            deckNumber[8] = 9;
            deckNames[8] = "Nine of Spades";
            deckNumber[9] = 10;
            deckNames[9] = "Ten of Spades";
            deckNumber[10] = 10;
            deckNames[10] = "Jack of Spades";
            deckNumber[11] = 10;
            deckNames[11] = "Queen of Spades";
            deckNumber[49] = 10;
            deckNames[49] = "King of Spades";


            deckNumber[12] = 1;
            deckNames[12] = "Ace of Hearts";
            deckNumber[13] = 2;
            deckNames[13] = "Two of Hearts";
            deckNumber[14] = 3;
            deckNames[14] = "Three of Hearts";
            deckNumber[15] = 4;
            deckNames[15] = "Four of Hearts";
            deckNumber[16] = 5;
            deckNames[16] = "Five of Hearts";
            deckNumber[17] = 6;
            deckNames[17] = "Six of Hearts";
            deckNumber[18] = 7;
            deckNames[18] = "Seven of Hearts";
            deckNumber[19] = 8;
            deckNames[19] = "Eight of Hearts";
            deckNumber[20] = 9;
            deckNames[20] = "Nine of Hearts";
            deckNumber[21] = 10;
            deckNames[21] = "Ten of Hearts";
            deckNumber[22] = 10;
            deckNames[22] = "Jack of Hearts";
            deckNumber[23] = 10;
            deckNames[23] = "Queen of Hearts";
            deckNumber[48] = 10;
            deckNames[48] = "King of Hearts";


            deckNumber[24] = 1;
            deckNames[24] = "Ace of Clubs";
            deckNumber[25] = 2;
            deckNames[25] = "Two of Clubs";
            deckNumber[26] = 3;
            deckNames[26] = "Three of Clubs";
            deckNumber[27] = 4;
            deckNames[27] = "Four of Clubs";
            deckNumber[28] = 5;
            deckNames[28] = "Five of Clubs";
            deckNumber[29] = 6;
            deckNames[29] = "Six of Clubs";
            deckNumber[30] = 7;
            deckNames[30] = "Seven of Clubs";
            deckNumber[31] = 8;
            deckNames[31] = "Eight of Clubs";
            deckNumber[32] = 9;
            deckNames[32] = "Nine of Clubs";
            deckNumber[33] = 10;
            deckNames[33] = "Ten of Clubs";
            deckNumber[34] = 10;
            deckNames[34] = "Jack of Clubs";
            deckNumber[35] = 10;
            deckNames[35] = "Queen of Clubs";
            deckNumber[50] = 10;
            deckNames[50] = "King of Clubs";


            deckNumber[36] = 1;
            deckNames[36] = "Ace of Diamonds";
            deckNumber[37] = 2;
            deckNames[37] = "Two of Diamonds";
            deckNumber[38] = 3;
            deckNames[38] = "Three of Diamonds";
            deckNumber[39] = 4;
            deckNames[39] = "Four of Diamonds";
            deckNumber[40] = 5;
            deckNames[40] = "Five of Diamonds";
            deckNumber[41] = 6;
            deckNames[41] = "Six of Diamonds";
            deckNumber[42] = 7;
            deckNames[42] = "Seven of Diamonds";
            deckNumber[43] = 8;
            deckNames[43] = "Eight of Diamonds";
            deckNumber[44] = 9;
            deckNames[44] = "Nine of Diamonds";
            deckNumber[45] = 10;
            deckNames[45] = "Ten of Diamonds";
            deckNumber[46] = 10;
            deckNames[46] = "Jack of Diamonds";
            deckNumber[47] = 10;
            deckNames[47] = "Queen of Diamonds";
            deckNumber[51] = 10;
            deckNames[51] = "King of Diamonds";


        }

        private void Shuffle()
        {
            for (int i = 0; i < 99999999; i++)
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

        public int HitCalc(string text, int score, TextBlock tBHand, TextBlock tBScore)
        {
            int card = deck[nextCard];
            string name = deckNames[card];
            int numberScore = deckNumber[card];

            text = tBHand.Text;
            if(score ==0)
            {
                tBHand.Text = name;
            }
            else
            {
                tBHand.Text = text + ", " + name;
            }
           
            
            score += numberScore;
            tBScore.Text = "You have a score of: " + score;
            nextCard++;
            return score;
        }

        public void StandCalc()
        {
            buttonHit.IsEnabled = false;
            while (dealerScore < 17)
            {
                dealerScore = HitCalc(dealerText, dealerScore, textBlockDealerHand, textBlockDealerScore);
            }
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            
            playerScore = HitCalc(playerText, playerScore, textBlockPlayerHand, textBlockPlayerScore);
            if ( playerScore > 21)
            {
                buttonHit.IsEnabled = false;
            }
        }

        public void Reset()
        {
            buttonHit.IsEnabled = true;
            nextCard = 0;
            playerText = "";
            playerScore = 0;
            dealerScore = 0;
            dealerText = "";
            textBlockDealerHand.Text = "";
            textBlockDealerScore.Text = "";
            textBlockPlayerHand.Text = "";
            textBlockPlayerScore.Text = "";


        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            MakeDecks();
            Shuffle();
            betAmount = Convert.ToInt32(textBox.Text);

        }

        private void buttonStand_Click(object sender, RoutedEventArgs e)
        {
            StandCalc();
            BettingCalc();
        }

        public void BettingCalc()
        {
            int winType;
            if (dealerScore < 22 && playerScore < 22)
            {
                if (dealerScore > playerScore)
                {
                    winType = 0;
                }
                else if(dealerScore == playerScore)
                {
                    winType = 1;
                }
                else if(playerScore > dealerScore)
                {
                    if(playerScore == 21)
                    {
                        winType = 21;
                    }
                    else
                    {
                        winType = 2;
                    }
                    
                }
            }
            else if (dealerScore > 22)
            {
                winType = 2;
            }
            else if ( playerScore > 22)
            {
                winType = 0;
            }




        }

    }
}
