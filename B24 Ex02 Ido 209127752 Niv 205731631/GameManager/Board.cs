using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class Board
    {

        private readonly uint r_HeightOfBoard;
        private readonly uint r_WidthOfBoard;
        private char[,] m_GameBoard;

        public char this[uint row, uint col]//this happens after validity check always;
        {

            get { return m_GameBoard[row, col]; }
            set { m_GameBoard[row, col] = value; }

        }
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
            m_GameBoard = new char[i_Height, i_Width];

            initallizeEmptyBoard();

        }
        public void initallizeEmptyBoard()
        {

            for (uint i = 0; i < r_HeightOfBoard; ++i)
            {
                for (uint j = 0; j < r_WidthOfBoard; ++j)
                {

                    m_GameBoard[i, j] = ' ';

                }

            }
        }

        public void drawGameBoard()
        {

            char[] columns = { 'A', 'B', 'C', 'D', 'E', 'F' };//8+'A'

            Console.Write(" ");
            for (uint i = 0; i < r_WidthOfBoard; ++i)
            {

                Console.Write("  ");
                Console.Write(columns[i] + " ");

            }
            Console.WriteLine();

            for (uint i = 0; i < r_HeightOfBoard; ++i)
            {
                Console.Write(" =");
                for (uint j = 0; j < Width; ++j)
                {
                    Console.Write("====");
                }
                Console.WriteLine();

                Console.Write(i + 1);
                for (uint j = 0; j < r_WidthOfBoard; j++)
                {
                    Console.Write("|" + " " + m_GameBoard[i, j] + " ");
                }
                Console.WriteLine("|");
            }

            Console.Write(" =");
            for (uint j = 0; j < Width; ++j)
            {
                Console.Write("====");
            }
            Console.WriteLine();

        }
        public static Board fillBoardWithValues(uint i_height, uint i_width)
        {

            uint numberOfLettersUsed = i_height * i_width / 2;
            Board fullBoard = new Board(i_height, i_width);

            Random random = new Random();
            List<char> listOfLetters = new List<char>();

            while (listOfLetters.Count < numberOfLettersUsed)
            {
                char letterToGenerate = (char)random.Next('A', 'Z' + 1);
                if (!listOfLetters.Contains(letterToGenerate))
                {
                    listOfLetters.Add(letterToGenerate);
                }

            }

            List<char> listOfAllTheLetters = new List<char>();
            foreach (char letter in listOfLetters)
            {
                listOfAllTheLetters.Add(letter);
                listOfAllTheLetters.Add(letter);
            }

            for (int i = listOfAllTheLetters.Count - 1; i > 0; --i)
            {

                int j = random.Next(i + 1);
                char temporaryCharFromTheListOfAllLetters = listOfAllTheLetters[i];
                listOfAllTheLetters[i] = listOfAllTheLetters[j];
                listOfAllTheLetters[j] = temporaryCharFromTheListOfAllLetters;

            }

            int index = 0;
            for (uint r = 0; r < i_height; ++r)
            {
                for (uint p = 0; p < i_width; ++p)
                {

                    fullBoard[r, p] = listOfAllTheLetters[index++];

                }

            }
            return fullBoard;
        }

    }

}