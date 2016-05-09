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
        Image[] deckImages;
        int nextCard = 0;
        string playerText;
        int playerScore = 0;
        int dealerScore = 0;
        string dealerText;
        int playerPoints = 500;
        int betAmount;
        int winType;
        int pAces;
        int dAces;
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
            deckImages = new Image[52];

            for (int i = 0; i < 52; i++)
            {
                deckImages[i] = new Image();
            }

            deckNumber[0] = 11;
            deckNames[0] = "Ace of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));

            deckNumber[1] = 2;
            deckNames[1] = "Two of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[2] = 3;
            deckNames[2] = "Three of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[3] = 4;
            deckNames[3] = "Four of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[4] = 5;
            deckNames[4] = "Five of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[5] = 6;
            deckNames[5] = "Six of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[6] = 7;
            deckNames[6] = "Seven of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[7] = 8;
            deckNames[7] = "Eight of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[8] = 9;
            deckNames[8] = "Nine of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[9] = 10;
            deckNames[9] = "Ten of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[10] = 10;
            deckNames[10] = "Jack of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[11] = 10;
            deckNames[11] = "Queen of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[49] = 10;
            deckNames[49] = "King of Spades";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));




            deckNumber[12] = 11;
            deckNames[12] = "Ace of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[13] = 2;
            deckNames[13] = "Two of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[14] = 3;
            deckNames[14] = "Three of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[15] = 4;
            deckNames[15] = "Four of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[16] = 5;
            deckNames[16] = "Five of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[17] = 6;
            deckNames[17] = "Six of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[18] = 7;
            deckNames[18] = "Seven of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[19] = 8;
            deckNames[19] = "Eight of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[20] = 9;
            deckNames[20] = "Nine of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[21] = 10;
            deckNames[21] = "Ten of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[22] = 10;
            deckNames[22] = "Jack of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[23] = 10;
            deckNames[23] = "Queen of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[48] = 10;
            deckNames[48] = "King of Hearts";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));




            deckNumber[24] = 11;
            deckNames[24] = "Ace of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[25] = 2;
            deckNames[25] = "Two of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[26] = 3;
            deckNames[26] = "Three of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[27] = 4;
            deckNames[27] = "Four of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[28] = 5;
            deckNames[28] = "Five of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[29] = 6;
            deckNames[29] = "Six of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[30] = 7;
            deckNames[30] = "Seven of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[31] = 8;
            deckNames[31] = "Eight of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[32] = 9;
            deckNames[32] = "Nine of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[33] = 10;
            deckNames[33] = "Ten of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[34] = 10;
            deckNames[34] = "Jack of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[35] = 10;
            deckNames[35] = "Queen of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[50] = 10;
            deckNames[50] = "King of Clubs";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));




            deckNumber[36] = 11;
            deckNames[36] = "Ace of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[37] = 2;
            deckNames[37] = "Two of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[38] = 3;
            deckNames[38] = "Three of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[39] = 4;
            deckNames[39] = "Four of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[40] = 5;
            deckNames[40] = "Five of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[41] = 6;
            deckNames[41] = "Six of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[42] = 7;
            deckNames[42] = "Seven of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[43] = 8;
            deckNames[43] = "Eight of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[44] = 9;
            deckNames[44] = "Nine of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[45] = 10;
            deckNames[45] = "Ten of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[46] = 10;
            deckNames[46] = "Jack of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[47] = 10;
            deckNames[47] = "Queen of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


            deckNumber[51] = 10;
            deckNames[51] = "King of Diamonds";
            deckImages[0].Source = new BitmapImage(new Uri("images/ace_spades.png", UriKind.Relative));


        }

        private void Shuffle()
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

        public int HitCalc(string text, int score, TextBlock tBHand, TextBlock tBScore, int aces)
        {
            int card = deck[nextCard];
            string name = deckNames[card];
            int numberScore = deckNumber[card];

            text = tBHand.Text;
            if(score == 0)
            {
                tBHand.Text = name;
            }
            else
            {
                tBHand.Text = text + ", " + name;
            }

            score += numberScore;
            if (card == 0 || card == 12 || card == 24 || card == 36)
            {
                aces++;
            }

            tBScore.Text = "You have a score of: " + score;
            nextCard++;
            return score;
        }

        public void StandCalc()
        {
            buttonHit.IsEnabled = false;
            while (dealerScore < 17)
            {
                dealerScore = HitCalc(dealerText, dealerScore, textBlockDealerHand, textBlockDealerScore, dAces);
                if(dealerScore == 17 && dAces > 0)
                {
                    dealerScore = HitCalc(dealerText, dealerScore, textBlockDealerHand, textBlockDealerScore, dAces);
                }
                if(dealerScore > 21 && dAces > 0)
                {
                    dealerScore -= 10;
                    dAces -= 1;
                    textBlockDealerScore.Text = "The dealer has a score of: " + dealerScore;
                }
            }
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            
            playerScore = HitCalc(playerText, playerScore, textBlockPlayerHand, textBlockPlayerScore, pAces);
            if(playerScore > 21 && pAces > 0)
            {
                playerScore = playerScore - 10;
                pAces -= 1;
                textBlockPlayerScore.Text = "You have a score of: " + playerScore;
            }
            else if ( playerScore > 21 && pAces ==0)
            {
                buttonHit.IsEnabled = false;
            }
        }

        public void Reset()
        {
            buttonHit.IsEnabled = true;
            buttonStand.IsEnabled = true;
            nextCard = 0;
            playerText = "";
            playerScore = 0;
            dealerScore = 0;
            dealerText = "";
            textBlockDealerHand.Text = "Dealer's Hand";
            textBlockDealerScore.Text = "The dealer has a score of:";
            textBlockPlayerHand.Text = "Player hand";
            textBlockPlayerScore.Text = "Player's Hand";
            textBlockValid.Text = "";


        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "" )
            {
                if (ValidInput())
                {
                    if (Convert.ToInt32(textBox.Text) < playerPoints)
                    {
                        Reset();
                        MakeDecks();
                        Shuffle();
                        betAmount = Convert.ToInt32(textBox.Text);
                        playerScore = HitCalc(playerText, playerScore, textBlockPlayerHand, textBlockPlayerScore, pAces);
                        dealerScore = HitCalc(dealerText, dealerScore, textBlockDealerHand, textBlockDealerScore, dAces);
                        playerScore = HitCalc(playerText, playerScore, textBlockPlayerHand, textBlockPlayerScore, pAces);
                        if (playerScore == 21)
                        {
                            winType = 21;
                            BetCalc();
                            buttonHit.IsEnabled = false;
                            buttonStand.IsEnabled = false;
                            buttonStart.IsEnabled = true;
                            textBlock.IsEnabled = true;
                            BetCalc();
                        }
                        buttonStart.IsEnabled = false;
                        textBlock.IsEnabled = false;
                    }
                }
                else
                {
                    //Error
                    textBlockValid.Text = "Please put in a wager with just ints or the program will not work.";

                }

            }
            else
            {
                //Error
                textBlockValid.Text = "Please put in a wager with just ints or the program will not work.";

            }

        }

        private void buttonStand_Click(object sender, RoutedEventArgs e)
        {
            buttonStand.IsEnabled = false;
            StandCalc();
            WinTypeCalc();
            BetCalc();
            buttonStart.IsEnabled = true;
            textBlock.IsEnabled = true;

        }

        public void WinTypeCalc()
        {
            
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
                    winType = 2;                    
                }
            }
            else if (dealerScore > 22 && playerScore > 22)
            {
                winType = 1;
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

        public void BetCalc()
        {
            if (winType == 0)
            {
                playerPoints -= betAmount;
            }
            else if (winType == 2)
            {
                playerPoints += betAmount;
            }
            else if (winType == 21)
            {
                betAmount = betAmount * 3 / 2;
                playerPoints += betAmount;
            }
            textBlockPlayerPoints.Text = "You Have " + playerPoints + " Points Left.";
        }

        public bool ValidInput()
        {
            string text = textBox.Text;
            return text.All(Char.IsDigit);

        }


    }
}
