using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic.Components;


namespace GameLogic
{  //classes of components
    //internal struct Player
    //{
    //    public enum PlayerTurn { FIRST = 1, SECONDE = 2 };
    //    private uint m_Score;
    //    private readonly string r_Name;
    //    private bool iscomputer;
    //    public uint playerturn;
    //    public Player(string i_NameOfUser, bool i_iscomputer)
    //    {
    //        r_Name = i_NameOfUser;
    //        iscomputer = i_iscomputer;
    //        m_Score = 0;
    //        playerturn = (uint)PlayerTurn.FIRST;
    //    }
    //    public uint Score
    //    {
    //        get { return m_Score; }
    //        set { m_Score = value; }
    //    }
    //    public string Name
    //    {
    //        get { return r_Name; }
    //    }
    //    public bool IsComputer
    //    {
    //        internal get { return iscomputer; }
    //        set { iscomputer = value; }
    //    }

    //}
    //public class Board
    //{
    //    private readonly uint r_HeightOfBoard;
    //    private readonly uint r_WidthOfBoard;
    //    internal Card[,] m_GameBoard;

    //    public object GetReturnCardObject(uint i, uint j)

    //    { return m_GameBoard[i, j].RealObject; }
    //    public Card[,] GetBoard

    //    { get { return m_GameBoard; } }
    //    public uint Height
    //    {
    //        get { return r_HeightOfBoard; }
    //    }
    //    public uint Width
    //    {
    //        get { return r_WidthOfBoard; }
    //    }

    //    public Board(uint i_Height, uint i_Width)
    //    {
    //        r_HeightOfBoard = i_Height;
    //        r_WidthOfBoard = i_Width;
    //        m_GameBoard = new Card[i_Height, i_Width];
           
    //    }
    //    public void RevealCard(uint row, uint col)
    //    {
    //        m_GameBoard[row, col].IsRevealed = true;
    //    }

    //    public void HideCard(uint row, uint col)
    //    {
    //        m_GameBoard[row, col].IsRevealed = false;
    //    }

    //    public bool IsRevealed(uint row, uint col)//getter for is reviled
    //    {
    //        return m_GameBoard[row, col].IsRevealed;
    //    }

    //    public object GetCardobject(uint row, uint col)
    //    {
    //        return m_GameBoard[row, col].RealObject;
    //    }
    //    public Card GetCard(uint row, uint col)//i dont understand why its not working 
    //    {
    //        return m_GameBoard[row, col].GetCard;
    //    }

    //    public Board fillBoardWithValues(uint i_height, uint i_width, List<object> source,ref LinkedList<Card> unreveildCardList)
    //    {

    //        uint numberOfObject = i_height * i_width / 2;
    //       // uint indexforcountobjects = numberOfObject;
    //        Board fullBoard = new Board(i_height, i_width);

    //        if (source.Count < numberOfObject)
    //        {
    //            throw new Exception("Not enough objects to fill the board");
    //        }

    //        List<object> allObjects = new List<object>();

    //        foreach (object obj in source)
    //        {
    //            if (!(allObjects.Contains(obj)))
    //            {
    //                allObjects.Add(obj);
    //                allObjects.Add(obj);
    //            }
    //        }
           
    //        Random random = new Random();

    //        for (int i = allObjects.Count - 1; i > 0; --i)
    //        {
    //            int j = random.Next(i + 1);
    //            object temp = allObjects[i];
    //            allObjects[i] = allObjects[j];
    //            allObjects[j] = temp;
    //        }

    //        int index = 0;
    //        for (uint i = 0; i < i_height; ++i)
    //        {
    //            for (uint j = 0; j < i_width; ++j)
    //            {
    //                fullBoard.m_GameBoard[i, j] = new Card(allObjects[index++],i,j);
    //                unreveildCardList.AddFirst(fullBoard.m_GameBoard[i, j]);
    //            }
    //        }
    //        return fullBoard;
    //    }
    //    public bool IsCardsInBounderies(uint row1, uint col1)
    //    {
    //        bool valid=true;
    //        if((row1 > Height  || col1 > Width))
    //        {
    //            valid=!valid;
    //        }
    //        return valid;
    //    }
    //    public bool isCardsEqual(uint row1, uint col1, uint row2, uint col2)
    //    {
    //        return m_GameBoard[row1, col1] == m_GameBoard[row2, col2];
    //    }
        
    //    // this 4 function is only for coder ease not really nessesery
    //    public void ConsoleOutSingleCard(uint i_xCordinateInMatrix, uint i_yCordinateInMatrix)
    //    {
    //        if (i_xCordinateInMatrix >= r_HeightOfBoard || i_yCordinateInMatrix >= r_WidthOfBoard)
    //        {
    //            throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
    //        }

    //        Board.Card card = m_GameBoard[i_xCordinateInMatrix, i_yCordinateInMatrix];
    //        string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
    //        Console.WriteLine($"Card at ({i_xCordinateInMatrix + 1}, {i_yCordinateInMatrix + 1}): {cardContent}");
    //    }
    //    public void ConsoleOutSingleRow(uint i_rowCordinateInMatrix)
    //    {
    //        if (i_rowCordinateInMatrix >= r_HeightOfBoard)
    //        {
    //            throw new ArgumentOutOfRangeException("Row coordinate is out of bounds.");
    //        }

    //        Console.Write($"Row {i_rowCordinateInMatrix + 1}: ");
    //        for (uint col = 0; col < r_WidthOfBoard; ++col)
    //        {
    //            Board.Card card = m_GameBoard[i_rowCordinateInMatrix, col];
    //            string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
    //            Console.Write($"{cardContent} ");
    //        }
    //        Console.WriteLine();
    //    }
    //    public void ConsoleOutSingleCol(uint i_colCordinateInMatrix)
    //    {
    //        if (i_colCordinateInMatrix >= r_WidthOfBoard)
    //        {
    //            throw new ArgumentOutOfRangeException("Column coordinate is out of bounds.");
    //        }

    //        Console.WriteLine($"Column {i_colCordinateInMatrix + 1}:");
    //        for (uint row = 0; row < r_HeightOfBoard; ++row)
    //        {
    //            Board.Card card = m_GameBoard[row, i_colCordinateInMatrix];
    //            string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
    //            Console.WriteLine($"{cardContent}");
    //        }
    //    }
    //    public void ConsoleOutBoard()
    //    {
    //        char[] columns = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    //        // Print column headers
    //        Console.Write("  ");
    //        for (uint col = 0; col < r_WidthOfBoard; col++)
    //        {
    //            Console.Write($" {columns[col]} ");
    //        }
    //        Console.WriteLine();

    //        // Print the board rows
    //        for (uint row = 0; row < r_HeightOfBoard; row++)
    //        {
    //            // Print the horizontal divider
    //            Console.Write(" =");
    //            for (uint col = 0; col < r_WidthOfBoard; col++)
    //            {
    //                Console.Write("====");
    //            }
    //            Console.WriteLine();

    //            // Print the row number
    //            Console.Write($"{row + 1} ");

    //            // Print the cards in the row
    //            for (uint col = 0; col < r_WidthOfBoard; col++)
    //            {
    //                Board.Card card = m_GameBoard[row, col];
    //                string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
    //                Console.Write($"| {cardContent} ");
    //            }
    //            Console.WriteLine("|");
    //        }

    //        // Print the final horizontal divider
    //        Console.Write(" =");
    //        for (uint col = 0; col < r_WidthOfBoard; col++)
    //        {
    //            Console.Write("====");
    //        }
    //        Console.WriteLine();
    //    }


    //    //help functions
    //    //like print one row 
    //    //card will be class cause we support game that can put in
    //    //card any object that the coder disire so we dont know his size
    //   public class Card
    //    {
    //        private uint xCordinate;
    //        private uint yCordinate;
    //        private object realObject;
    //        private bool isRevealed;

    //        public Card(object i_realobj,uint x,uint y)
    //        {
    //            realObject = i_realobj;
    //            isRevealed = false;
    //            xCordinate = x;
    //            yCordinate = y;
    //        }
    //        public Card GetCard
    //        {
    //            get { Card newcopypointer = new Card(realObject, xCordinate, yCordinate);
    //                return newcopypointer; }
    //        }
    //        public bool IsRevealed
    //        {
    //            get { return isRevealed; }
    //            set { isRevealed = value; }
    //        }
    //        public object RealObject
    //        {
    //            get { return realObject; }
    //        }
    //        public uint getXCordinate
    //        {
    //            get { return xCordinate; }
    //        }
    //        public uint getYCordinate
    //        {
    //            get { return yCordinate; }
    //        }

    //        public static bool operator ==(Card firstCard, Card secondeCard)
    //        {
    //            return firstCard.realObject == secondeCard.realObject;
    //        }
    //        public static bool operator !=(Card firstCard, Card secondeCard)
    //        {
    //            return !(firstCard == secondeCard);
    //        }
    //        public override bool Equals(object obj)
    //        {
    //            return this.realObject == ((Card)obj).realObject;
    //        }
    //    }

    //}
   public class GameManager
    {
        internal Board gameBoard;
        internal LinkedList<Card> unreaviledCards;
        internal Dictionary<object,Card> collectiveMemoryOfCards;
        internal List<Tuple<Card,Card>> listCoupleObjects;
        internal readonly uint numberOfPlayers;
        internal Player[] r_Players;
        internal static uint m_CurrentPlayerIndex;
        public uint numOfPlayer
        {
            get { return numberOfPlayers; }
        } //done
        public bool iscomputer
        {
            get { return r_Players[m_CurrentPlayerIndex].IsComputer; }
        } //done
        public string playerName
        {
            get { return r_Players[m_CurrentPlayerIndex].Name; }
        } //done
        public GameManager(uint boardhight, uint boardwidth, uint i_numberOfPlayers, List<object> objectsData)
        {
            if ((boardhight * boardwidth) % 2 == 0)
            {
                unreaviledCards = new LinkedList<Card>();
                gameBoard = new Board(boardhight, boardwidth);
                gameBoard.fillBoardWithValues(boardhight, boardwidth, objectsData,ref unreaviledCards);
                numberOfPlayers = i_numberOfPlayers;
                r_Players = new Player[numberOfPlayers];//names filled in ui
                m_CurrentPlayerIndex = 0;
            }
            else
                throw new Exception("The product of height and width must be even.");
            //check with guy if possible
            //if not delete
            //ui must support even product
        }

      

       // public Board GetBoard
        //{
        //    get { return gameBoard; }
        //} //done

        public static List<object> ConvertListToObjectList<T>(List<T> List)
        {
            List<object> objectList = new List<object>();

            foreach (T obj in List)
            {
                objectList.Add(obj);
            }

            return objectList;
        }
        public void AddPlayer(string playerName, uint index, bool iscomputer)
        {

            Player newPlayer = new Player(playerName, iscomputer);
            r_Players[index] = newPlayer;
            
        }

        public bool MakeSingleMove(uint row1, uint col1)//bool indicate that this move cant be done
        {   
            if (gameBoard.IsRevealed(row1, col1) || (!gameBoard.IsCardsInBounderies(row1, col1)))//relevat to human
            {
                return false;
            }
            else
            {
                gameBoard.RevealCard(row1, col1);
                unreaviledCards.Remove(gameBoard.m_GameBoard[row1, col1]);
                collectiveMemoryOfCardsHandle(row1, col1);
                return true;
            }
        }
       
        public bool checkMakeMove(uint row1, uint col1, uint row2, uint col2)
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
                collectiveMemoryOfCardsHandle(row1, col1);
                collectiveMemoryOfCardsHandle(row2, col2);

                gameBoard.HideCard(row1, col1);
                gameBoard.HideCard(row2, col2);

                NextTurn();
                return false;
            }

        }//done
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
        }//done
        
        //think how to do it
        public bool computerSingleMakeMove()
        {
            bool isequal;
            if (listCoupleObjects.Count > 0)
            {
                if (!(r_Players[m_CurrentPlayerIndex].playerturn == (uint)Player.PlayerTurn.FIRST))
                {
                    listCoupleObjects[0].Item1.IsRevealed = true;
                    r_Players[m_CurrentPlayerIndex].playerturn = (uint)Player.PlayerTurn.SECONDE;

                }
                else
                {
                    listCoupleObjects[0].Item2.IsRevealed = true;
                    r_Players[m_CurrentPlayerIndex].Score += 1;
                    listCoupleObjects.RemoveAt(0);
                    r_Players[m_CurrentPlayerIndex].playerturn = (uint)Player.PlayerTurn.FIRST;

                }
                isequal=true;
            }
            else if (collectiveMemoryOfCards.Count > 0)
            {
                Card firstcard = collectiveMemoryOfCards.Values.First();
                if (!(r_Players[m_CurrentPlayerIndex].playerturn == (uint)Player.PlayerTurn.FIRST))
                {
                    isequal= MakeSingleMove(firstcard.getXCordinate, firstcard.getYCordinate);
                    r_Players[m_CurrentPlayerIndex].playerturn = (uint)Player.PlayerTurn.SECONDE;         
                }
                else
                {
                    Card secondcard = PickRandomCard();//DO REAL RAND FROM UNREVIELD
                    MakeSingleMove(secondcard.getXCordinate, secondcard.getYCordinate);
                    isequal = checkMakeMove(firstcard.getXCordinate, firstcard.getYCordinate, secondcard.getXCordinate, secondcard.getYCordinate);   
                   
                    if (isequal)
                    {
                        collectiveMemoryOfCards.Remove(firstcard.RealObject); 
                        
                    }             
                    unreaviledCards.Remove(secondcard);
                }
            }
            else//make random choice function that use unreveild cards choose the first unrevield 
                //still not random just  picking un folded card
            {
                Card firstcard = PickRandomCard();
                if (!(r_Players[m_CurrentPlayerIndex].playerturn == (uint)Player.PlayerTurn.FIRST))
                {
                    isequal =MakeSingleMove(firstcard.getXCordinate, firstcard.getYCordinate);                   
                }
                else
                {
                    Card secondcard = PickRandomCard();
                    MakeSingleMove(secondcard.getXCordinate, secondcard.getYCordinate);
                    isequal = checkMakeMove(firstcard.getXCordinate, firstcard.getYCordinate, secondcard.getXCordinate, secondcard.getYCordinate);               
                    if(isequal)
                    {
                        //add points to player
                        unreaviledCards.Remove(firstcard);
                        unreaviledCards.Remove(secondcard);
                    }
                }
            }
            return isequal;
        }//done
        private Card PickRandomCard()
        {
            Random random = new Random();
            int index = random.Next(unreaviledCards.Count);
            LinkedListNode<Card> node = unreaviledCards.First;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node.Value;
        }//done

        private void NextTurn()
        {

            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % numberOfPlayers;
        } //DONE

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

        }//DONE
        public void WinnerOfTheGame(out string o_winnerName, out uint points)//done
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
