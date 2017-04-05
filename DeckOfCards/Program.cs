using System;

namespace DeckOfCards
{
    class Program
    {
        public static void NewGame()
        {
            Deck gameDeck = new Deck();
            Dealer gameDealer = new Dealer();  //need Dealer class
            Console.WriteLine("~~~~~~  LET'S PLAY SOME BLACK JACK!  ~~~~~~");
            Console.WriteLine("###########################################");
            Console.WriteLine("Input player name:");
            string playerName = Console.ReadLine();
            Player user = new Player(playerName);
            Console.WriteLine("Welcome {0}, let's play!", user.name);
            StartGame(gameDeck, gameDealer, user);
        }
        public static void StartGame(Deck gameDeck, Dealer gameDealer, Player user)
        {
            Random rand = new Random();
            gameDeck.shuffle();
            user.InitialDeal(gameDeck);
            gameDealer.InitialDeal(gameDeck);
            user.initalizeHandVal();
            gameDealer.initalizeHandVal();
            int wager = 10;
            string DealerTopCard = gameDealer.hand[gameDealer.hand.Count-1].stringVal; // check this variable to match dealer class
            string PlayerTopCard = user.hand[user.hand.Count-1].stringVal;
            int DealerHand = gameDealer.handVal; // check "handValue" variable
            int PlayerHand = user.handVal; // check "handValue" variable
            Console.WriteLine("Dealer's top card is a {0}", DealerTopCard);
            Console.WriteLine("You have a {0} and a {1}. Your hand total is {2}", user.hand[0].stringVal, user.hand[1].stringVal, PlayerHand);

            bool playerTurn = true; //Begin Player Turn Loop
            while(playerTurn == true)
            {
                Console.WriteLine("Your hand total is {0}", PlayerHand);
                Console.WriteLine("Dealer's top card is a {0}", DealerTopCard);
                Console.WriteLine("What would you like to do ('Hit', 'Stay')");
                string res = Console.ReadLine();

                switch(res)
                {
                    case "Hit":
                        user.Deal(gameDeck); // make sure Hit method matches player class
                        user.updateHandVal();
                        Console.WriteLine("You hit and got a {0}", PlayerTopCard);
                        if(PlayerHand > 21)
                        {
                            Console.WriteLine("Sorry, you busted with a total of {0}", PlayerHand);
                            playerTurn = false;
                            user.score -= wager;
                            break;
                        }
                        else if(PlayerHand == 21)
                        {
                            Console.WriteLine("WOOHOOO, you got 21!!!!");
                            playerTurn = false;
                            break;
                        }
                        else{
                            break;
                        }
                    case "Stay":
                        Console.WriteLine("You chose to stay with a total of {0}", PlayerHand);
                        playerTurn = false;
                        break;
                    default:
                        Console.WriteLine("Come on now, enter a proper command!!!!");
                        break;
                }
            }
                Console.WriteLine("made past player turn");
                if(PlayerHand > 21) // If the player busted, reset the game. Otherwise it is the dealers turn
                {
                    GameReset(user);
                }

                // setting up dealer turn sequence
                bool dealerTurn = true;
                bool dealerBust = false;
                while(dealerTurn == true)
                {
                    if(DealerHand == 21)
                    {
                        dealerTurn = false;
                        break;
                    }
                    else if(DealerHand >= 17 && DealerHand <= 20)
                    {
                        dealerTurn = false;
                        break;
                    }
                    else if(DealerHand > 21)
                    {
                        dealerTurn = false;
                        dealerBust = true;
                        
                    }
                    else{
                        gameDealer.Deal(gameDeck);
                        gameDealer.updateHandVal();
                    }
                }
                if(dealerBust == true)
                {
                    Console.WriteLine("The Dealer has busted with a {0}, you win!", DealerHand);
                    user.score += wager;
                    GameReset(user);
                }
                else if(DealerHand == PlayerHand)
                {
                    Console.WriteLine("It's a tie! (a.k.a. 'Push'");
                    Console.WriteLine("Your hand and the dealer hand = {0}", PlayerHand);
                    GameReset(user);
                }
                else if(PlayerHand > DealerHand)
                {
                    Console.WriteLine("You win!!! Your {0} beats the Dealers {1}", PlayerHand, DealerHand);
                    user.score += wager;
                    GameReset(user);
                }
                else{
                    Console.WriteLine("You lose.... The Dealer has {0} which beats your {1}", DealerHand, PlayerHand);
                    user.score -= wager;
                    GameReset(user);
                }

        }

        public static void GameReset(Player user)
        {
            if(user.score > 0)
            {
                Console.WriteLine("Your score is {0}, would you like to play a new game? ('yes' or 'no')", user.score);
                string answer = Console.ReadLine();
                switch(answer)
                {
                    case "yes":
                        Deck newDeck = new Deck();
                        Dealer newDealer = new Dealer();
                        StartGame(newDeck, newDealer, user);
                        break;
                    case "no":
                        Console.WriteLine("All done? You score is {0}, great job!", user.score);
                        break;
                    default:
                        Console.WriteLine("Enter either 'yes' or 'no'");
                        break;
                }
            }
            else{
                Console.WriteLine("You're out of points, you lose!!!");
            }
        }
            
        // public void Run()
        // {
        //     NewGame();
        // }
        static void Main(string[] args)
        {
            NewGame();
            // Deck deck = new Deck();
            // Player player = new Player("player");
            // deck.shuffle();
            // player.Deal(deck);
            // player.Deal(deck);
            // player.Deal(deck);
            // player.Deal(deck);
        }
    }
}
