using System;
using System.Collections.Generic;
using System.Linq;
using static GameLogic.Board;

//game manager use board and player to preform the logics no printing here
//make sure to use all guy tricks 
namespace GameLogic
{
    internal struct Player
    {

        private uint m_Score;
        private readonly string r_Name;
        private bool iscomputer;
        public enum player {FIRST=1,SECONDE=2 }; 

        public Player(string i_NameOfUser, bool i_iscomputer)
        {
            r_Name = i_NameOfUser;
            iscomputer = i_iscomputer;
            m_Score = 0;
        }
        public uint Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public string Name
        {
            get { return r_Name; }
        }
        public bool IsComputer
        {
            internal get { return iscomputer; }
            set { iscomputer = value; }
        }

    }
    public class Board
    {
        private readonly uint r_HeightOfBoard;
        private readonly uint r_WidthOfBoard;
        internal Card[,] m_GameBoard;


        //public Card this[uint row, uint col]//this happens after validity check always
        //{
        //    get { return m_GameBoard[row, col]; }
        //    set { m_GameBoard[row, col].realObject = value; }
        //}
        //need to fix
        public object GetReturnBoard(uint i, uint j)

        { return m_GameBoard[i, j].RealObject; }
        public Card[,] GetBoard

        { get { return m_GameBoard; } }
        public uint Height
        {
            get { return r_HeightOfBoard; }
        }
        public uint Width
        {
            get { return r_WidthOfBoard; }
        }

        public Board(uint i_Height, uint i_Width, List<object> type)
        {

            r_HeightOfBoard = i_Height;
            r_WidthOfBoard = i_Width;
            m_GameBoard = new Card[i_Height, i_Width];
            InitializeBoard(type[0]);//mybe not nessesery
        }
        //private void InitializeBoard(object type)//mybe not nessesery
        //{
        //    for (uint i = 0; i < r_HeightOfBoard; ++i)
        //    {
        //        for (uint j = 0; j < r_WidthOfBoard; ++j)
        //        {
        //            m_GameBoard[i, j] = new Card(type,i,j);
        //        }
        //    }
        //}
        //stays in board

        public void RevealCard(uint row, uint col)
        {
            m_GameBoard[row, col].IsRevealed = true;
        }

        public void HideCard(uint row, uint col)
        {
            m_GameBoard[row, col].isRevealed = false;
        }

        public bool IsRevealed(uint row, uint col)//getter for is reviled
        {
            return m_GameBoard[row, col].IsRevealed;
        }

        public object GetCardobject(uint row, uint col)
        {
            return m_GameBoard[row, col].RealObject;
        }
        public Card GetCard(uint row, uint col)//i dont understand why its not working 
        {
            return m_GameBoard[row, col].GetCard;
        }

        //public void initallizeEmptyBoard() //no need cause working with objects it will be intilized with default of obj
        //{

        //    for (uint i = 0; i < r_HeightOfBoard; ++i)
        //    {
        //        for (uint j = 0; j < r_WidthOfBoard; ++j)
        //        {

        //            m_GameBoard[i, j] = ' ';

        //        }

        //    }
        //}

        //stays in board
        private static Board fillBoardWithValues(uint i_height, uint i_width, List<object> source)
        {

            uint numberOfObject = i_height * i_width / 2;
           // uint indexforcountobjects = numberOfObject;
            Board fullBoard = new Board(i_height, i_width, source);

            if (source.Count < numberOfObject)
            {
                throw new ArgumentException("Not enough objects to fill the board");
            }


            List<object> allObjects = new List<object>();

            foreach (var obj in source)
            {
                if (!(allObjects.Contains(obj)))
                {
                    allObjects.Add(obj);
                    allObjects.Add(obj);
                }
            }
           
            Random random = new Random();

            //while (listOfObjects.Count > 0)
            //{
            //    int letterToGenerate = (int)random.Next('A', 'Z' + 1);
            //    if (!listOfObjects.Contains(letterToGenerate))
            //    {
            //        listOfObjects.Add(letterToGenerate);
            //    }
            //}

            for (int i = allObjects.Count - 1; i > 0; --i)
            {
                int j = random.Next(i + 1);
                var temp = allObjects[i];
                allObjects[i] = allObjects[j];
                allObjects[j] = temp;
            }


            //list<char> listofalltheletters = new list<char>();
            //foreach (char letter in allobjects)
            //{
            //    listofalltheletters.add(letter);
            //    listofalltheletters.add(letter);
            //}
            //for (int i = listofalltheletters.count - 1; i > 0; --i)
            //{
            //    int j = random.next(i + 1);
            //    char temporarycharfromthelistofallletters = listofalltheletters[i];
            //    listofalltheletters[i] = listofalltheletters[j];
            //    listofalltheletters[j] = temporarycharfromthelistofallletters;
            //}

            int index = 0;
            for (uint i = 0; i < i_height; ++i)
            {
                for (uint j = 0; j < i_width; ++j)
                {
                    fullBoard.m_GameBoard[i, j] = new Card(allObjects[index++],i,j);

                }
            }
            return fullBoard;
        }
        public bool IsCardsInBounderies(uint row1, uint col1)
        {
            if((row1 > Height  || col1 > Width))
            {
                return false;
            }
            return true;
        }
        public bool isCardsEqual(uint row1, uint col1, uint row2, uint col2)
        {
            return m_GameBoard[row1, col1] == m_GameBoard[row2, col2];
        }









        // this 4 function is only for coder ease not really nessesery
        public void ConsoleOutSingleCard(uint i_xCordinateInMatrix, uint i_yCordinateInMatrix)
        {
            if (i_xCordinateInMatrix >= r_HeightOfBoard || i_yCordinateInMatrix >= r_WidthOfBoard)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
            }

            Board.Card card = m_GameBoard[i_xCordinateInMatrix, i_yCordinateInMatrix];
            string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
            Console.WriteLine($"Card at ({i_xCordinateInMatrix + 1}, {i_yCordinateInMatrix + 1}): {cardContent}");
        }
        public void ConsoleOutSingleRow(uint i_rowCordinateInMatrix)
        {
            if (i_rowCordinateInMatrix >= r_HeightOfBoard)
            {
                throw new ArgumentOutOfRangeException("Row coordinate is out of bounds.");
            }

            Console.Write($"Row {i_rowCordinateInMatrix + 1}: ");
            for (uint col = 0; col < r_WidthOfBoard; ++col)
            {
                Board.Card card = m_GameBoard[i_rowCordinateInMatrix, col];
                string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
                Console.Write($"{cardContent} ");
            }
            Console.WriteLine();
        }
        public void ConsoleOutSingleCol(uint i_colCordinateInMatrix)
        {
            if (i_colCordinateInMatrix >= r_WidthOfBoard)
            {
                throw new ArgumentOutOfRangeException("Column coordinate is out of bounds.");
            }

            Console.WriteLine($"Column {i_colCordinateInMatrix + 1}:");
            for (uint row = 0; row < r_HeightOfBoard; ++row)
            {
                Board.Card card = m_GameBoard[row, i_colCordinateInMatrix];
                string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
                Console.WriteLine($"{cardContent}");
            }
        }
        public void ConsoleOutBoard()
        {
            char[] columns = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Print column headers
            Console.Write("  ");
            for (uint col = 0; col < r_WidthOfBoard; col++)
            {
                Console.Write($" {columns[col]} ");
            }
            Console.WriteLine();

            // Print the board rows
            for (uint row = 0; row < r_HeightOfBoard; row++)
            {
                // Print the horizontal divider
                Console.Write(" =");
                for (uint col = 0; col < r_WidthOfBoard; col++)
                {
                    Console.Write("====");
                }
                Console.WriteLine();

                // Print the row number
                Console.Write($"{row + 1} ");

                // Print the cards in the row
                for (uint col = 0; col < r_WidthOfBoard; col++)
                {
                    Board.Card card = m_GameBoard[row, col];
                    string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
                    Console.Write($"| {cardContent} ");
                }
                Console.WriteLine("|");
            }

            // Print the final horizontal divider
            Console.Write(" =");
            for (uint col = 0; col < r_WidthOfBoard; col++)
            {
                Console.Write("====");
            }
            Console.WriteLine();
        }


        //help functions
        //like print one row 
        //card will be class cause we support game that can put in
        //card any object that the coder disire so we dont know his size
       public class Card
        {
            private uint xCordinate;
            private uint yCordinate;
            private object realObject;
            private bool isRevealed;

            public Card(object i_realobj,uint x,uint y)
            {
                realObject = i_realobj;
                isRevealed = false;
                xCordinate = x;
                yCordinate = y;
            }
            public Card GetCard
            {
                get { Card newcopypointer = new Card(realObject, xCordinate, yCordinate);
                    return newcopypointer; }
            }
            public bool IsRevealed
            {
                get { return isRevealed; }
                set { isRevealed = value; }
            }
            public object RealObject
            {
                get { return realObject; }
            }
            public uint getXCordinate
            {
                get { return xCordinate; }
            }
            public uint getYCordinate
            {
                get { return yCordinate; }
            }

            public static bool operator ==(Card firstCard, Card secondeCard)
            {
                return firstCard.realObject == secondeCard.realObject;
            }
            public static bool operator !=(Card firstCard, Card secondeCard)
            {
                return !(firstCard == secondeCard);
            }
            public override bool Equals(object obj)
            {
                return this.realObject == ((Card)obj).realObject;
            }
        }

    }
  
   public class GameManager
    {
        internal Board gameBoard;
        internal Dictionary<object,Card> collectiveMemoryOfCards;
        internal List<Tuple<Card,Card>> listCoupleObjects;
        internal readonly uint numberOfPlayers;
        internal Player[] r_Players;
        internal static uint m_CurrentPlayerIndex;
        

        public uint numOfPlayer
        {
            get { return numberOfPlayers; }
        }
        public bool iscomputer
        {
            get { return r_Players[m_CurrentPlayerIndex].IsComputer; }
        }
        public string playerName
        {
            get { return r_Players[m_CurrentPlayerIndex].Name; }
        }


        public GameManager(uint boardhight, uint boardwidth, uint i_numberOfPlayers, ref List<object> objectsdata)
        {
            if ((boardhight * boardwidth) % 2 == 0)
            {
                gameBoard = new Board(boardhight, boardwidth, objectsdata);
                numberOfPlayers = i_numberOfPlayers;
                r_Players = new Player[numberOfPlayers];
                m_CurrentPlayerIndex = 0;
            }
            else
                throw new ArgumentException("The product of height and width must be even.");
            //check with guy if possible
            //if not delete
            //all the
            //if and the ui must support even product

        }

        public Board GetBoard
        {
            get { return gameBoard; }
        }



        //public Board gameBoard
        //{
        //    get { return m_GameBoard; }
        //    set { m_GameBoard = value; }
        //}
        ///remember to add defults for number or chars something like below 
        ///  char letterToGenerate = (char)random.Next('A', 'Z' + 1);
        //       if (!listOfLetters.Contains(letterToGenerate))
        //      {
        //          listOfLetters.Add(letterToGenerate);
        //    }

        public bool SetUpGameboard(uint boardhight, uint boardwidth, List<object> objectsdata)
        {
            //here we needto get only the object list from user make the board with boards methods 
            //here we setup only the board ,mybe get rid of num of players
            //ADD all cards to unreveiledcards

            bool playAnotherGame = true;

            string nameOfPlayers = Console.ReadLine();

            User[] usersOfTheGame = new User[i_NumberOfPlayers];
            User user1 = new User(nameOfPlayers);///


            if (i_GameMode.Equals("1"))
            {
                //Console.WriteLine("Please enter the name of the second player:");
                //nameOfPlayers = Console.ReadLine();
                //user2 = new UserInfo(nameOfPlayers);

            }
            else//playing vs computer TODO
            {
                user2 = new User("Computer");

            }


            SetGameBoard(ref memoryGame);

            //need to change to maybe more players


            if (!User.playGame(ref usersOfTheGame, ref memoryGame))//the actul game, a player didnt press Q; meaning the game is finished;
            {
                playAnotherGame = FinishGameAndDecideNext(ref user1, ref user2);

            }
            else
            {
                //game was terminated; not playing again;
                playAnotherGame = !playAnotherGame;
            }
            return playAnotherGame;
        }


        public bool setupgameplayers(uint i_numberOfPlayers)
        {
            //here we add the players with their names

            return true;
        }
        //here we get from ui sring the name and add this player
        public void AddPlayer(string playerName, uint index, bool iscomputer)
        {

            Player newPlayer = new Player(playerName, iscomputer);
            r_Players[index] = newPlayer;
        }

        public bool MakeSingleMove(uint row1, uint col1)
        {
            //if(!gameBoard.IsCardsInBounderies(row1, col1))
            //{
            //    return false;
            //}
            //add to ui if its the same cards!!error messege

            //think how to implement computer here or in another function if(r_Players[m_CurrentPlayerIndex].IsComputer)
            //add if not in boundries 
          
                //MOVE TO HUMAN MOVE    
                if (gameBoard.IsRevealed(row1, col1))//relevat to human
                {
                    return false;
                }
                else
                {
                    gameBoard.m_GameBoard[row1, col1].IsRevealed = true;
                     collectiveMemoryOfCardsHandle(row1, col1);
                }
                //think more about logic
                //the function for memory
               
                

               
            
        }
       
        public bool checkmakeMove(uint row1, uint col1, uint row2, uint col2)
        {
            if (gameBoard.isCardsEqual(row1, col1, row2, col2))//move for the two cards moves
            {
                //add the cards to known list
                //think about logic for ai computer
                gameBoard.m_GameBoard[row1, col1].IsRevealed = true;
                gameBoard.m_GameBoard[row2, col2].IsRevealed = true;
                //remove from collective memory
                r_Players[m_CurrentPlayerIndex].Score += 1;
                return true;
            }
            else
            {

                collectiveMemoryOfCards.Add(gameBoard.m_GameBoard[row1, col1].RealObject, gameBoard.GetCard(row1, col1));
                collectiveMemoryOfCards.Add(gameBoard.m_GameBoard[row2, col2].RealObject, gameBoard.GetCard(row2, col2));

                gameBoard.HideCard(row1, col1);
                gameBoard.HideCard(row2, col2);

                NextTurn();
                return false;
            }

        }
        private void collectiveMemoryOfCardsHandle(uint row,uint col)
        {
            object key = gameBoard.m_GameBoard[row, col].RealObject;
            if (!collectiveMemoryOfCards.ContainsKey(gameBoard.m_GameBoard[row, col].RealObject))
            {
                collectiveMemoryOfCards.Add(gameBoard.m_GameBoard[row, col].RealObject, gameBoard.GetCard(row, col));
            }
            else if (!collectiveMemoryOfCards[key].Equals(gameBoard.m_GameBoard[row, col])) 
            {
                listCoupleObjects.Add(Tuple.Create(collectiveMemoryOfCards[key],gameBoard.m_GameBoard[row, col]));
                collectiveMemoryOfCards.Remove(key);
            }
        }
        
        //think how to do it
        public bool computerMakeMove()
        {
            if(listCoupleObjects.Count > 0)
            {
                listCoupleObjects[0].Item1.IsRevealed=true;
                listCoupleObjects[0].Item2.IsRevealed = true;
                r_Players[m_CurrentPlayerIndex].Score += 1;
                listCoupleObjects.RemoveAt(0);
                return true;
            }
            else if(collectiveMemoryOfCards.Count>0)
            {
                Card firstcard = collectiveMemoryOfCards.Values.First();  
                MakeSingleMove(firstcard.getXCordinate,firstcard.getYCordinate);
                Card secondcard =//random function that use unreveild cards
                //MakeSingleMove(secondcard.getXCordinate,secondcard.getYCordinate);

                 return checkmakeMove(firstcard.getXCordinate, firstcard.getYCordinate, secondcard.getXCordinate, secondcard.getYCordinate);
            }
            else//make random choice function that use unreveild cards choose the first unrevield 
            {
                Card firstcard = //random function use unrevield
               // MakeSingleMove(firstcard.getXCordinate, firstcard.getYCordinate);
                Card secondcard =//random function that use unreveild cards
                //MakeSingleMove(secondcard.getXCordinate,secondcard.getYCordinate);

                return checkmakeMove(firstcard.getXCordinate, firstcard.getYCordinate, secondcard.getXCordinate, secondcard.getYCordinate);

            }


        }


        private void NextTurn()
        {

            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % numberOfPlayers;
        }

        public bool IsGameOver()
        {
            foreach(Card currentCard in gameBoard.m_GameBoard)
            {
                if(!(currentCard.IsRevealed))
                {
                    return false;
                }
            }
            return true;

        }
        public void WinnerOfTheGame(out string o_winnerName, out uint points)
        {
            Player winner = r_Players[0];
            foreach (Player player in r_Players)
            {
                if (player.Score > winner.Score)
                {
                    winner = player;
                }
            }
            points = winner.Score;
            o_winnerName = winner.Name;
        }

   }

}
