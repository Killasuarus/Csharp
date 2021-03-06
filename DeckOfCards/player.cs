using System;
using System.Collections.Generic;
 
 namespace DeckOfCards {
    public class Player{ 
            public string name;
            public int score = 100;
            public List<Card> hand = new List<Card>();
            public int handVal = 0;

        public Player (string n) {
            name = n;
        }       

        Random rand = new Random();
        public void Deal(Deck cards) {
            hand.Add(cards.Deal());
        }

        public void InitialDeal(Deck cards){
            hand.Add(cards.Deal());
            hand.Add(cards.Deal());
        }

        public void initalizeHandVal(){
            handVal += hand[0].val;
            handVal += hand[1].val;
        }
        public void updateHandVal(){ 
            handVal += hand[hand.Count-1].val;
        }

    }
}