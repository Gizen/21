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


        //BUTTONS

        //Start
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            //Check if there is a wager
            if (textBox.Text != "")
            {

                //Check if the wager is all ints 
                if (ValidInput())
                {

                    //Check if the wager is <= points left
                    if (Convert.ToInt32(textBox.Text) <= playerPoints)
                    {

                        //Reset
                        Reset();

                        //Make Decks
                        MakeDecks();

                        //Shuffle the shuffle deck
                        Shuffle();

                        //Get wager amount
                        betAmount = Convert.ToInt32(textBox.Text);

                        //Give the starting cards
                        playerScore = HitCalc(playerText, playerScore, playerStack, textBlockPlayerScore, ref pAces, true);
                        dealerScore = HitCalc(dealerText, dealerScore, dealersStack, textBlockDealerScore, ref dAces, false);
                        playerScore = HitCalc(playerText, playerScore, playerStack, textBlockPlayerScore, ref pAces, true);

                        //Check for Blackjack
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
                        else
                        {
                            buttonStart.IsEnabled = false;
                            textBlock.IsEnabled = false;
                        }
                    }
                    else
                    //Give Error
                    {
                        textBlockValid.Text = "Please put in a wager smaller or equal to your points left.";

                    }
                }
                else
                //Give Error
                {
                    textBlockValid.Text = "Please put in a wager with just ints or the program will not work.";

                }

            }
            else
            //Give Error
            {
                textBlockValid.Text = "Please put in a wager.";

            }

        }


        //Hit
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            //Give player another card
            playerScore = HitCalc(playerText, playerScore, playerStack, textBlockPlayerScore, ref pAces, true);

            //See if an ace should be a 1
            if (playerScore > 21 && pAces > 0)
            {
                playerScore = playerScore - 10;
                pAces -= 1;
                textBlockPlayerScore.Text = "You have a score of: " + playerScore;
            }

            //Disable Hit button if the score is a bust
            else if (playerScore > 21 && pAces == 0)
            {
                buttonHit.IsEnabled = false;
            }
        }
 

        //Stand
        private void buttonStand_Click(object sender, RoutedEventArgs e)
        {
            //Disable stand
            buttonStand.IsEnabled = false;

            //Run the stand method
            StandCalc();

            //See how the game was won
            WinTypeCalc();

            //Calc the player points based on the game outcome
            BetCalc();

            //Enable butons
            buttonStart.IsEnabled = true;
            textBlock.IsEnabled = true;

        }



        //METHODS

        //Start Methods
        public void Reset()
        {
            buttonHit.IsEnabled = true;
            buttonStand.IsEnabled = true;
            nextCard = 0;
            playerText = "";
            playerScore = 0;
            dealerScore = 0;
            dealerText = "";
            dealersStack.Children.Clear();
            textBlockDealerScore.Text = "The dealer has a score of:";
            playerStack.Children.Clear();
            textBlockPlayerScore.Text = "Player's Hand";
            textBlockValid.Text = "";
            pAces = 0;
            dAces = 0;


        }
        private void MakeDecks()
        {
            deck = new int[52];
            for (int i = 0; i < 51; i++)
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
            deckImages[1].Source = new BitmapImage(new Uri("images/spade2.png", UriKind.Relative));


            deckNumber[2] = 3;
            deckNames[2] = "Three of Spades";
            deckImages[2].Source = new BitmapImage(new Uri("images/spade3.png", UriKind.Relative));


            deckNumber[3] = 4;
            deckNames[3] = "Four of Spades";
            deckImages[3].Source = new BitmapImage(new Uri("images/spade4.png", UriKind.Relative));


            deckNumber[4] = 5;
            deckNames[4] = "Five of Spades";
            deckImages[4].Source = new BitmapImage(new Uri("images/spade5.png", UriKind.Relative));


            deckNumber[5] = 6;
            deckNames[5] = "Six of Spades";
            deckImages[5].Source = new BitmapImage(new Uri("images/spade6.png", UriKind.Relative));


            deckNumber[6] = 7;
            deckNames[6] = "Seven of Spades";
            deckImages[6].Source = new BitmapImage(new Uri("images/spade7.png", UriKind.Relative));


            deckNumber[7] = 8;
            deckNames[7] = "Eight of Spades";
            deckImages[7].Source = new BitmapImage(new Uri("images/spade8.png", UriKind.Relative));


            deckNumber[8] = 9;
            deckNames[8] = "Nine of Spades";
            deckImages[8].Source = new BitmapImage(new Uri("images/spade9.png", UriKind.Relative));


            deckNumber[9] = 10;
            deckNames[9] = "Ten of Spades";
            deckImages[9].Source = new BitmapImage(new Uri("images/spade10.png", UriKind.Relative));


            deckNumber[10] = 10;
            deckNames[10] = "Jack of Spades";
            deckImages[10].Source = new BitmapImage(new Uri("images/spadeJ.png", UriKind.Relative));


            deckNumber[11] = 10;
            deckNames[11] = "Queen of Spades";
            deckImages[11].Source = new BitmapImage(new Uri("images/spadeQ.png", UriKind.Relative));


            deckNumber[49] = 10;
            deckNames[49] = "King of Spades";
            deckImages[49].Source = new BitmapImage(new Uri("images/spadeK.png", UriKind.Relative));




            deckNumber[12] = 11;
            deckNames[12] = "Ace of Hearts";
            deckImages[12].Source = new BitmapImage(new Uri("images/heartA.png", UriKind.Relative));


            deckNumber[13] = 2;
            deckNames[13] = "Two of Hearts";
            deckImages[13].Source = new BitmapImage(new Uri("images/heart2.png", UriKind.Relative));


            deckNumber[14] = 3;
            deckNames[14] = "Three of Hearts";
            deckImages[14].Source = new BitmapImage(new Uri("images/heart3.png", UriKind.Relative));


            deckNumber[15] = 4;
            deckNames[15] = "Four of Hearts";
            deckImages[15].Source = new BitmapImage(new Uri("images/heart4.png", UriKind.Relative));


            deckNumber[16] = 5;
            deckNames[16] = "Five of Hearts";
            deckImages[16].Source = new BitmapImage(new Uri("images/heart5.png", UriKind.Relative));


            deckNumber[17] = 6;
            deckNames[17] = "Six of Hearts";
            deckImages[17].Source = new BitmapImage(new Uri("images/heart6.png", UriKind.Relative));


            deckNumber[18] = 7;
            deckNames[18] = "Seven of Hearts";
            deckImages[18].Source = new BitmapImage(new Uri("images/heart7.png", UriKind.Relative));


            deckNumber[19] = 8;
            deckNames[19] = "Eight of Hearts";
            deckImages[19].Source = new BitmapImage(new Uri("images/heart8.png", UriKind.Relative));


            deckNumber[20] = 9;
            deckNames[20] = "Nine of Hearts";
            deckImages[20].Source = new BitmapImage(new Uri("images/heart9.png", UriKind.Relative));


            deckNumber[21] = 10;
            deckNames[21] = "Ten of Hearts";
            deckImages[21].Source = new BitmapImage(new Uri("images/heart10.png", UriKind.Relative));


            deckNumber[22] = 10;
            deckNames[22] = "Jack of Hearts";
            deckImages[22].Source = new BitmapImage(new Uri("images/heartJ.png", UriKind.Relative));


            deckNumber[23] = 10;
            deckNames[23] = "Queen of Hearts";
            deckImages[23].Source = new BitmapImage(new Uri("images/heartQ.png", UriKind.Relative));


            deckNumber[48] = 10;
            deckNames[48] = "King of Hearts";
            deckImages[48].Source = new BitmapImage(new Uri("images/heartK.png", UriKind.Relative));




            deckNumber[24] = 11;
            deckNames[24] = "Ace of Clubs";
            deckImages[24].Source = new BitmapImage(new Uri("images/clubA.png", UriKind.Relative));


            deckNumber[25] = 2;
            deckNames[25] = "Two of Clubs";
            deckImages[25].Source = new BitmapImage(new Uri("images/club2.png", UriKind.Relative));


            deckNumber[26] = 3;
            deckNames[26] = "Three of Clubs";
            deckImages[26].Source = new BitmapImage(new Uri("images/club3.png", UriKind.Relative));


            deckNumber[27] = 4;
            deckNames[27] = "Four of Clubs";
            deckImages[27].Source = new BitmapImage(new Uri("images/club4.png", UriKind.Relative));


            deckNumber[28] = 5;
            deckNames[28] = "Five of Clubs";
            deckImages[28].Source = new BitmapImage(new Uri("images/club5.png", UriKind.Relative));


            deckNumber[29] = 6;
            deckNames[29] = "Six of Clubs";
            deckImages[29].Source = new BitmapImage(new Uri("images/club6.png", UriKind.Relative));


            deckNumber[30] = 7;
            deckNames[30] = "Seven of Clubs";
            deckImages[30].Source = new BitmapImage(new Uri("images/club7.png", UriKind.Relative));


            deckNumber[31] = 8;
            deckNames[31] = "Eight of Clubs";
            deckImages[31].Source = new BitmapImage(new Uri("images/club8.png", UriKind.Relative));


            deckNumber[32] = 9;
            deckNames[32] = "Nine of Clubs";
            deckImages[32].Source = new BitmapImage(new Uri("images/club9.png", UriKind.Relative));


            deckNumber[33] = 10;
            deckNames[33] = "Ten of Clubs";
            deckImages[33].Source = new BitmapImage(new Uri("images/club10.png", UriKind.Relative));


            deckNumber[34] = 10;
            deckNames[34] = "Jack of Clubs";
            deckImages[34].Source = new BitmapImage(new Uri("images/clubJ.png", UriKind.Relative));


            deckNumber[35] = 10;
            deckNames[35] = "Queen of Clubs";
            deckImages[35].Source = new BitmapImage(new Uri("images/clubQ.png", UriKind.Relative));


            deckNumber[50] = 10;
            deckNames[50] = "King of Clubs";
            deckImages[50].Source = new BitmapImage(new Uri("images/clubK.png", UriKind.Relative));




            deckNumber[36] = 11;
            deckNames[36] = "Ace of Diamonds";
            deckImages[36].Source = new BitmapImage(new Uri("images/diamondA.png", UriKind.Relative));


            deckNumber[37] = 2;
            deckNames[37] = "Two of Diamonds";
            deckImages[37].Source = new BitmapImage(new Uri("images/diamond2.png", UriKind.Relative));


            deckNumber[38] = 3;
            deckNames[38] = "Three of Diamonds";
            deckImages[38].Source = new BitmapImage(new Uri("images/diamond3.png", UriKind.Relative));


            deckNumber[39] = 4;
            deckNames[39] = "Four of Diamonds";
            deckImages[39].Source = new BitmapImage(new Uri("images/diamond4.png", UriKind.Relative));


            deckNumber[40] = 5;
            deckNames[40] = "Five of Diamonds";
            deckImages[40].Source = new BitmapImage(new Uri("images/diamond5.png", UriKind.Relative));


            deckNumber[41] = 6;
            deckNames[41] = "Six of Diamonds";
            deckImages[41].Source = new BitmapImage(new Uri("images/diamond6.png", UriKind.Relative));


            deckNumber[42] = 7;
            deckNames[42] = "Seven of Diamonds";
            deckImages[42].Source = new BitmapImage(new Uri("images/diamond7.png", UriKind.Relative));


            deckNumber[43] = 8;
            deckNames[43] = "Eight of Diamonds";
            deckImages[43].Source = new BitmapImage(new Uri("images/diamond8.png", UriKind.Relative));


            deckNumber[44] = 9;
            deckNames[44] = "Nine of Diamonds";
            deckImages[44].Source = new BitmapImage(new Uri("images/diamond9.png", UriKind.Relative));


            deckNumber[45] = 10;
            deckNames[45] = "Ten of Diamonds";
            deckImages[45].Source = new BitmapImage(new Uri("images/diamond10.png", UriKind.Relative));


            deckNumber[46] = 10;
            deckNames[46] = "Jack of Diamonds";
            deckImages[46].Source = new BitmapImage(new Uri("images/diamondJ.png", UriKind.Relative));


            deckNumber[47] = 10;
            deckNames[47] = "Queen of Diamonds";
            deckImages[47].Source = new BitmapImage(new Uri("images/diamondQ.png", UriKind.Relative));


            deckNumber[51] = 10;
            deckNames[51] = "King of Diamonds";
            deckImages[51].Source = new BitmapImage(new Uri("images/diamondK.png", UriKind.Relative));


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
        public bool ValidInput()
        {
            string text = textBox.Text;
            return text.All(Char.IsDigit);

        }


        //Hit Method
        public int HitCalc(string text, int score, StackPanel stack, TextBlock tBScore, ref int aces, bool player)
        {

            int card = deck[nextCard];
            string name = deckNames[card];
            int numberScore = deckNumber[card];
            Image img = deckImages[card];

            img.Stretch = Stretch.None;

            stack.Children.Add(img);



            //text = tBHand.Text;
            //if(score == 0)
            //{
            //    tBHand.Text = name;
            //}
            //else
            //{
            //    tBHand.Text = text + ", " + name;
            //}

            score += numberScore;
            if (card == 0 || card == 12 || card == 24 || card == 36)
            {
                aces++;
            }
            if (player == false)
            {
                tBScore.Text = "The dealer has a score of: " + score;
            }
            else
            {
                tBScore.Text = "You have a score of: " + score;
            }
            nextCard++;
            if (nextCard == 52)
            {
                nextCard = 1;
            }
            return score;
        }


        //Stand Methods
        public void StandCalc()
        {
            buttonHit.IsEnabled = false;
            while (dealerScore < 17)
            {
                dealerScore = HitCalc(dealerText, dealerScore, dealersStack, textBlockDealerScore, ref dAces, false);
                if (dealerScore == 17 && dAces > 0)
                {
                    dealerScore = HitCalc(dealerText, dealerScore, dealersStack, textBlockDealerScore, ref dAces, false);
                }
                if (dealerScore > 21 && dAces > 0)
                {
                    dealerScore -= 10;
                    dAces -= 1;
                    textBlockDealerScore.Text = "The dealer has a score of: " + dealerScore;
                }
            }
        }
        public void WinTypeCalc()
        {

            if (dealerScore < 22 && playerScore < 22)
            {
                if (dealerScore > playerScore)
                {
                    winType = 0;
                }
                else if (dealerScore == playerScore)
                {
                    winType = 1;
                }
                else if (playerScore > dealerScore)
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
            else if (playerScore > 22)
            {
                winType = 0;
            }

        }
        public void BetCalc()
        {
            string win = "";
            if (winType == 0)
            {
                playerPoints -= betAmount;
                win = "The dealer Won";
            }
            else if (winType == 2)
            {
                playerPoints += betAmount;
                win = "You win";
            }
            else if (winType == 21)
            {
                betAmount = betAmount * 3 / 2;
                playerPoints += betAmount;
                win = "BLACKJACK You win!";
            }
            else if (winType == 1)
            {
                win = " Tie, nobody won.";
            }
            if (playerPoints == 1)
            {
                textBlockPlayerPoints.Text = "You Have 1 Point Left.";
                textBlockValid.Text = win;
            }
            else
            {
                textBlockPlayerPoints.Text = "You Have " + playerPoints + " Points Left.";
                textBlockValid.Text = win;
            }
        }



    }
}
