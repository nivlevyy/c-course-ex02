
using System;
using System.Collections.Generic;

namespace GameLogic.Components
{
    internal class Board
    {
        private readonly uint r_HeightOfBoard;
        private readonly uint r_WidthOfBoard;
        internal Card[,] m_GameBoard;

        public object GetReturnCardObject(uint i, uint j)

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

        public Board(uint i_Height, uint i_Width)
        {
            r_HeightOfBoard = i_Height;
            r_WidthOfBoard = i_Width;
            m_GameBoard = new Card[i_Height, i_Width];

        }
        public void RevealCard(uint row, uint col)
        {
            m_GameBoard[row, col].IsRevealed = true;
        }

        public void HideCard(uint row, uint col)
        {
            m_GameBoard[row, col].IsRevealed = false;
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

        public Board fillBoardWithValues(uint i_height, uint i_width, List<object> source, ref LinkedList<Card> unreveildCardList)
        {

            uint numberOfObject = i_height * i_width / 2;
            // uint indexforcountobjects = numberOfObject;
            Board fullBoard = new Board(i_height, i_width);

            if (source.Count < numberOfObject)
            {
                throw new Exception("Not enough objects to fill the board");
            }

            List<object> allObjects = new List<object>();

            foreach (object obj in source)
            {
                if (!(allObjects.Contains(obj)))
                {
                    allObjects.Add(obj);
                    allObjects.Add(obj);
                }
            }

            Random random = new Random();

            for (int i = allObjects.Count - 1; i > 0; --i)
            {
                int j = random.Next(i + 1);
                object temp = allObjects[i];
                allObjects[i] = allObjects[j];
                allObjects[j] = temp;
            }

            int index = 0;
            for (uint i = 0; i < i_height; ++i)
            {
                for (uint j = 0; j < i_width; ++j)
                {
                    fullBoard.m_GameBoard[i, j] = new Card(allObjects[index++], i, j);
                    unreveildCardList.AddFirst(fullBoard.m_GameBoard[i, j]);
                }
            }
            return fullBoard;
        }
        public bool IsCardsInBounderies(uint row1, uint col1)
        {
            bool valid = true;
            if ((row1 > Height || col1 > Width))
            {
                valid = !valid;
            }
            return valid;
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

            Card card = m_GameBoard[i_xCordinateInMatrix, i_yCordinateInMatrix];
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
                Card card = m_GameBoard[i_rowCordinateInMatrix, col];
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
                Card card = m_GameBoard[row, i_colCordinateInMatrix];
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
                    Card card = m_GameBoard[row, col];
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

        public Card[] returnCardsRow(uint row)
        {
            Card[] oneCardRow = new Card[r_WidthOfBoard];

            for (uint col = 0; col < r_WidthOfBoard; col++)
            {
                oneCardRow[col] = m_GameBoard[row, col];
            }
            return oneCardRow;
        }
        public Card[,] returnGameBoard()
        {
            return m_GameBoard;
        }


        //help functions
        //like print one row 
        //card will be class cause we support game that can put in
        //card any object that the coder disire so we dont know his size
        //public class Card
        //{
        //    private uint xCordinate;
        //    private uint yCordinate;
        //    private object realObject;
        //    private bool isRevealed;

        //    public Card(object i_realobj, uint x, uint y)
        //    {
        //        realObject = i_realobj;
        //        isRevealed = false;
        //        xCordinate = x;
        //        yCordinate = y;
        //    }
        //    public Card GetCard
        //    {
        //        get
        //        {
        //            Card newcopypointer = new Card(realObject, xCordinate, yCordinate);
        //            return newcopypointer;
        //        }
        //    }
        //    public bool IsRevealed
        //    {
        //        get { return isRevealed; }
        //        set { isRevealed = value; }
        //    }
        //    public object RealObject
        //    {
        //        get { return realObject; }
        //    }
        //    public uint getXCordinate
        //    {
        //        get { return xCordinate; }
        //    }
        //    public uint getYCordinate
        //    {
        //        get { return yCordinate; }
        //    }

        //    public static bool operator ==(Card firstCard, Card secondeCard)
        //    {
        //        return firstCard.realObject == secondeCard.realObject;
        //    }
        //    public static bool operator !=(Card firstCard, Card secondeCard)
        //    {
        //        return !(firstCard == secondeCard);
        //    }
        //    public override bool Equals(object obj)
        //    {
        //        return this.realObject == ((Card)obj).realObject;
        //    }
        //}

    }
}
