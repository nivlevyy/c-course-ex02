using System;
using System.Collections.Generic;

namespace GameLogic
{

    public class Logics
    {

        private static void PrintmainMenu(out String o_userInput)
        {
            Console.WriteLine("(1) Start new game.");
            Console.WriteLine("(Q) Quit game.");
            o_userInput = Console.ReadLine();
            //valid check
            checkIfValidInputForMainMenu(ref o_userInput);

        }
        private static void PrintGameModesMenu()
        {


        }
        public static void checkIfValidInputForMainMenu(ref string io_String)
        {
            while (!(io_String.Equals("1") || io_String.Equals("2")))
            {
                Console.WriteLine("The invalid choice. Please try again");
                io_String = Console.ReadLine();
            }
        }
        private static bool SetUpGame()
        {
            RunGame memoryGame = new RunGame();
            bool playAnotherGame = true;

            UserInfo user1 = new UserInfo(nameOfPlayers);///maybe add how many players
            UserInfo user2;
            Console.WriteLine("For Player VS Player press 1, for Player VS Computer press 2: ");
            string mode = Console.ReadLine();

            CheckIfValidInputForGameMode(ref mode);

            if (mode.Equals("1"))
            {
                Console.WriteLine("Please enter the name of the second player:");
                nameOfPlayers = Console.ReadLine();
                user2 = new UserInfo(nameOfPlayers);

            }
            else//playing vs computer TODO
            {
                user2 = new UserInfo("Computer");

            }
            SetGameBoard(ref memoryGame);

            //need to change to maybe more players
            if (!PlayGame(ref user1, ref user2, memoryGame))//the actul game, a player didnt press Q; meaning the game is finished;
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



        private static bool PlayGame(ref UserInfo io_User1, ref UserInfo io_User2, Logics i_Game)
        {

            bool wasGameTerminated = false;
            while (io_User1.Score + io_User2.Score != (i_Game.m_GameBoard.Height * i_Game.m_GameBoard.Width / 2))
            {

                if (!PlayTurn(ref io_User1, ref i_Game) || PlayTurn(ref io_User2, ref i_Game))
                {
                    wasGameTerminated = true;
                    break;
                }


            }

            return wasGameTerminated;
        }

        private static bool PlayTurn(ref UserInfo io_User, ref Logics io_Game)
        {
            bool qWasNotPressed = true;
            string[] userChoices = new string[2];

            for (int i = 0; i < 2 && qWasNotPressed; ++i)
            {
                Console.WriteLine(io_User.Name + " please make a choice:");
                userChoices[i] = Console.ReadLine();
                if (userChoices[i].Equals("Q"))
                {
                    qWasNotPressed = !qWasNotPressed;
                }
                else
                {
                    CheckIfValidTurnInput(ref userChoices[i], ref io_Game);//change to parse
                    io_Game.m_GameBoard[(int)(userChoices[i][1] - '1'), (int)(userChoices[i][0] - 'A')] = io_Game.m_FullBoardWithValues[(int)(userChoices[i][1] - '1'), (int)(userChoices[i][0] - 'A')];
                    Screen.Clear();
                    io_Game.m_GameBoard.drawGameBoard();
                }
            }

            if (qWasNotPressed)
            {

                if (io_Game.m_GameBoard[(int)(userChoices[0][1] - '1'), (int)(userChoices[0][0] - 'A')] == io_Game.m_GameBoard[(int)(userChoices[1][1] - '1'), (int)(userChoices[1][0] - 'A')])
                {
                    io_User.Score++;
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                    io_Game.m_GameBoard[(int)(userChoices[0][1] - '1'), (int)(userChoices[0][0] - 'A')] = io_Game.m_GameBoard[(int)(userChoices[1][1] - '1'), (int)(userChoices[1][0] - 'A')] = ' ';
                    Screen.Clear();
                    io_Game.m_GameBoard.drawGameBoard();
                }


            }


            return qWasNotPressed;
        }

        private static void CheckIfValidTurnInput(ref string io_String, ref Logics i_Game)
        {
            char maxLetter;
            int columnRepresentive;
            bool isValidInput = false;

            if (i_Game.m_GameBoard.Width == 4)
            {
                maxLetter = 'E';
            }
            else
            {
                maxLetter = 'F';
            }
            while (!isValidInput)
            {
                if (io_String.Length == 2)
                {

                    isValidInput = io_String[0] >= 'A' && io_String[0] <= maxLetter && io_String[1] > '0' && io_String[1] <= (char)i_Game.m_GameBoard.Width + 48;

                }

                if (isValidInput)//the input is valid need to check if the square is vacant
                {

                    columnRepresentive = io_String[0] - 65;
                    if (i_Game.m_GameBoard[(int)io_String[1] - '1', columnRepresentive] == ' ')//its empty;
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The square that you chose is taken, please choose something else: ");
                        io_String = Console.ReadLine();
                        isValidInput = !isValidInput;

                    }


                }
                else
                {
                    Console.WriteLine("This input is invalid, please choose something else: ");
                    io_String = Console.ReadLine();
                }


            }


        }

        private static void SetGameBoard(ref Logics io_currentGamePlayed)//maybe move to UI
        {

            Console.WriteLine("To set up the Game board please select the height and width");

            //GetBorderDimension(ref io_currentGamePlayed);


            Console.WriteLine("The height can be 4 or 6, and the width can also be 4 or 6. Please enter the height:");
            //change to allow 5x4 for exmaple
            string height = Console.ReadLine();

            CheckIfValidSizeInput(ref height);
            Console.WriteLine("Please enter the Width: ");
            string width = Console.ReadLine();
            CheckIfValidSizeInput(ref width);


            Board currentBoardSetUp = new Board(int.Parse(height), int.Parse(width));

            Board fullGameBoard = FillBoardWithValues(int.Parse(height), int.Parse(width));

            Screen.Clear();
            currentBoardSetUp.drawGameBoard();

            io_currentGamePlayed.m_FullBoardWithValues = fullGameBoard;
            io_currentGamePlayed.gameBoard = currentBoardSetUp;

        }

        private static void CheckIfValidInputForGameMode(ref string i_String)
        {

            while (!(i_String.Equals("1") || i_String.Equals("2")))
            {
                Console.WriteLine("The input is incorrect. Please enter 1 for Player VS Player or 2 for Player VS Computer: ");
                i_String = Console.ReadLine();
            }

        }

        private static void CheckIfValidSizeInput(ref string i_String)//need to change
        {

            while (!(i_String.Equals("4") || i_String.Equals("6")))
            {
                Console.WriteLine("The input is invalid. Please enter 4 or 6: ");
                i_String = Console.ReadLine();

            }

        }

        



        public static void getBorderDimension(out uint o_rows, out uint o_cols)
        {
            bool validInput = false;
            Console.WriteLine($"To set up the Game board please select the height and width within the range of {hightLowerBoundry}x{widthLowerBoundry} to {hightUperBoundry}x{widthUperBoundry}");

            while (!validInput)
            {
                Console.Write($"Enter the number of rows ({hightLowerBoundry}-{hightUperBoundry}): ");
                Console.Write($"Enter the number of colmuns ({widthLowerBoundry}-{widthUperBoundry}): ");

                if (true == uint.TryParse(Console.ReadLine(), out o_rows) && true == uint.TryParse(Console.ReadLine(), out o_cols))
                {
                    if (o_rows >= hightLowerBoundry && o_rows <= hightUperBoundry && o_cols >= widthLowerBoundry && o_cols <= widthUperBoundry && (i_cols * i_rows % 2 == 0))
                    {
                        validInput = !validInput;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input, the total number of squares must be even, and within the range of {hightLowerBoundry}x{widthLowerBoundry} to {hightUperBoundry}x{widthUperBoundry}, try again: ");
                    }
                }

            }

        }

    }
}
