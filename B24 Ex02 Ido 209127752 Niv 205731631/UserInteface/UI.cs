﻿using System;
using System.Collections.Generic;
using System.Threading;
using GameLogic;

namespace GameUi
{
    public class UI
    {
        //add more enums
        private enum userChoicesMainMenu { Startgame = 1, Quit };
        private enum userChoicesTypeOfPlayer { Human = 1, Computer };

        public const uint widthUperBoundry = 6;
        public const uint hightUperBoundry = 6;
        public const uint widthLowerBoundry = 4;
        public const uint hightLowerBoundry = 4;
        public readonly uint boardwidth, boardheight;
        public static uint firstChoiceXCordinate, firstChoiceYCordinate;
        public static uint secondChoiceXCordinate, secondChoiceYCordinate;


        //UI METHODS
        public static void startGame()//continue this function
        {
            string userchoice;
            uint numberofplayers;
            uint boardwidth, boardheight;
            bool gameFinished = false;
            string winnerPlayerName;
            uint winnerPlayerPoints;
            //add method that initilized with all abc to chars
            List<char> abcList = new List<char>();

            ConsoleOutStartScreen();
            Thread.Sleep(3000);

            ConsoleOutMainMenu();
            userchoice = getChoiceFromInput();
            getBorderDimension(out boardheight, out boardwidth);
            numberofplayers = getPlayersNumber();
            GameManager newManager = new GameManager(boardheight, boardwidth, numberofplayers, ref abcList);//will not work untill unitilized abcList

            CreatePlayers(numberofplayers, ref newManager);



            while (!gameFinished)
            {
                ConsoleOutBoard(newManager.GetBoard);
                //press ____ to maake a move or Q to exit check method


                if (getPlayerChoiceTodo())//todo will inculde error messege exit function only if player took a valid choice
                {
                    newManager.MakeMove(firstChoiceXCordinate, firstChoiceYCordinate, secondChoiceXCordinate, secondChoiceYCordinate);
                    //add to make move the computer ai
                    //add to the memory and all things  that need to add the manager
                }

                if (newManager.IsGameOver())
                {
                    newManager.WinnerOfTheGame(out winnerPlayerName,out winnerPlayerPoints);
                    //print winner
                    //ask for another play will return true if we want to exit game or false to play again 
                    if (!gameFinished)
                    {
                        //setup new board with game manager
                    }
                }

            }
            //need to finish function
        }

        //ConsoleOutStartScreen: prints to the console the game name in ascii art
        private static void ConsoleOutStartScreen()
        {
            Console.WriteLine("\r\n" +
                " .----------------.  .----------------.  .-----------------.  .----------------.  .----------------.  .----------------. \r\n" +
                "| .--------------. || .--------------. || .--------------.  || .--------------. || .--------------. || .--------------.|\r\n" +
                "| | ____    _____| || |  __________  | || | ____    _____ | || |     ____     | || |  _______     | || |  ____   ____  | |\r\n" +
                "| ||_   \\  /  _|| || | |_   ___   | | || ||_   \\  /  _| | || |   .'    `.   | || | |_   __ \\   | || | |_  _| |_  _| | |\r\n" +
                "| |  |   \\/   | | || |   | |_  \\_| | || |  |   \\/   |  | || |  /  .--.  \\ | || |   | |__) |   | || |   \\\\  / /   | |\r\n" +
                "| |  | |\\  /| | | || |   |  _|  __  | || |  | |\\  /| |  | || |  | |    | |  | || |   |  __ /    | || |    \\\\/ /    | |\r\n" +
                "| | _| |_\\/_| |_| || |  _| |___/  | | || | _| |_\\/_| |_ | || |  \\ `--'  /  | || |  _| |  \\\\_ | || |    _|   |_    | |\r\n" +
                "| ||_____| |_____| || | |__________| | || ||_____| |_____|| || |   `.____.'   | || | |____| |___| | || |   |_______|   | |\r\n" +
                "| |              | || |              | || |               | || |              | || |              | || |               | |\r\n" +
                "| '--------------' || '--------------' || '--------------'  || '--------------' || '--------------' || '---------------' |\r\n" +
                " '----------------'  '----------------'  '-----------------'  '----------------'  '----------------'  '-----------------' \r\n" +
                " .----------------.  .----------------.  .-----------------.  .-----------------.  .----------------.                     \r\n" +
                "| .--------------. || .--------------. || .---------------. || .---------------. || .--------------. |                    \r\n" +
                "| |              | || |    _______   | || |      __       | || | ____    _____ | || |  __________  | |                    \r\n" +
                "| |              | || |  .' ___   |  | || |     /  \\     | || ||_   \\  /   _|| || | |_   ___   | | |                    \r\n" +
                "| |    ______    | || | / .'   \\_|  | || |    / /\\\\    | || |  |   \\/   |  | || |   | |_  \\_| | |                    \r\n" +
                "| |   |______|   | || | | |    ____  | || |   / ____ \\   | || |  | |\\  /| |  | || |   |  _|  __  | |                    \r\n" +
                "| |              | || | \\`.___] _|  | || | _/ /    \\\\_ | || | _| |_\\/_| |_ | || |  _| |___/  | | |                    \r\n" +
                "| |              | || |  `._____.'   | || ||____|   |____|| || ||_____| |_____|| || | |__________| | |                    \r\n" +
                "| |              | || |              | || |               | || |               | || |              | |                    \r\n" +
                "| '--------------' || '--------------' || '---------------' || '---------------' || '--------------' |                    \r\n" +
                " '----------------'  '----------------'  '-----------------'  '-----------------'  '----------------'                     \r\n");

        }
        ////ConsoleOutMainMenu:prints to the console th main menu of the game
        private static void ConsoleOutMainMenu()
        {
            Console.WriteLine("welcome to the memory game!!" +
                "" +
                $"({userChoicesMainMenu.Startgame}) Start new game." +
                $"({userChoicesMainMenu.Quit}) Quit game.");
        }
        public static string getChoiceFromInput()
        {
            string inputForGameMode;

            inputForGameMode = Console.ReadLine();
            CheckIfValidInputForMenuChoices(ref inputForGameMode);

            return inputForGameMode;
        }
        private static void CheckIfValidInputForMenuChoices(ref string io_String)
        {
            while (!(io_String.Equals("1") || io_String.Equals("2")))
            {
                Console.WriteLine("You entered an invalid choice. Please try again: ");
                io_String = Console.ReadLine();
            }
        }
        //get how many players
        private static uint getPlayersNumber()
        {

            Console.WriteLine("how many palyers will play the game?");
            return CheckIfValidInputForHowManyPlayers(Console.ReadLine());

        }//done
        //choose player type
        private static void ConsoleOutChoosePlayerTypes()
        {
            Console.WriteLine(
               $"If you want to play against a real player press {userChoicesTypeOfPlayer.Human}" +
               $" and if you want to play against a computer press {userChoicesTypeOfPlayer.Computer}: ");
        }//done

        //valid check player
        private static uint CheckIfValidInputForHowManyPlayers(string io_String)//done
        {
            uint numberOfPlayers;
            while (!(uint.TryParse(io_String, out numberOfPlayers)))
            {
                Console.WriteLine("You entered an invalid choice. Please try again: ");
                io_String = Console.ReadLine();
            }
            return numberOfPlayers;

        }

        public static void getBorderDimension(out uint o_rows, out uint o_cols)//fix function for dimantions of board
        {
            bool validInput = false;
            uint rows, cols;
            Console.WriteLine(
                $"To set up the Game board please select " +
                $"the height and width within the range of " +
                $"{hightLowerBoundry}x{widthLowerBoundry}" +
                $" to {hightUperBoundry}x{widthUperBoundry}");

            while (!validInput)
            {
                while (!validInput)
                {
                    Console.Write(
                    $"Enter the number of rows" +
                    $" ({hightLowerBoundry}-{hightUperBoundry}): ");
                    validInput = uint.TryParse(Console.ReadLine(), out rows);
                }
                validInput = !validInput;
                while (!validInput)
                {
                    Console.Write(
                    $"Enter the number of colmuns " +
                    $"({widthLowerBoundry}-{widthUperBoundry}): ");
                    validInput = uint.TryParse(Console.ReadLine(), out rows);

                }
                if (rows >= hightLowerBoundry && rows <= hightUperBoundry && cols >= widthLowerBoundry && cols <= widthUperBoundry && (cols * rows % 2 == 0))
                {
                    validInput = !validInput;
                }
                else
                {
                    Console.WriteLine(
                        "Invalid input, the total number of squares must be even, " +
                        $"and within the range of {hightLowerBoundry}x{widthLowerBoundry} " +
                        $"to {hightUperBoundry}x{widthUperBoundry}, try again: ");
                }


            }

        }

        public static string getusersnames()//done
        {
            Console.WriteLine("enter player name here:");
            string playerName = Console.ReadLine();

            return playerName;
        }
        private static void CreatePlayers(uint numberOfPlayers, ref GameManager gameManager)
        {
            string userChoice;
            string playerName;
            // Screen.Clear();
            HashSet<string> mySet = new HashSet<string>();

            for (int i = 1; i < numberOfPlayers; ++i)
            {
                //  Screen.Clear();
                Console.WriteLine(
                    "this player will be a real player or a computer" +
                    $" press {userChoicesTypeOfPlayer.Human} for human" +
                    $"and press {userChoicesTypeOfPlayer.Human} for computer");

                userChoice = getChoiceFromInput();
                //   Screen.Clear();
                if (userChoice == $"{userChoicesTypeOfPlayer.Human}")
                {
                    playerName = getusersnames();
                    while ((mySet.Contains(playerName)))
                    {
                        Console.WriteLine(
                        "this player name is ocupid please enter different name");
                        playerName = getusersnames();
                    }
                    gameManager.AddPlayer(playerName, i, false);
                }
                else if (userChoice == $"{userChoicesTypeOfPlayer.Human}")
                {
                    playerName = $"Computer{i + 1}";

                    gameManager.AddPlayer(playerName, i, true);
                }

            }
        }//done

        public void createGameBoard(ref GameManager gameManager)//add dimentions)//need to be change for all letters in col and how to print board in ui 
        {
            uint rows, cols;
            getBorderDimension(out rows, out cols);
            //add list of all ABC to setup board
            gameManager.SetUpGameboard(rows, cols,);

        }

            public static void ConsoleOutBoard(Board gameBoard)//todo only the printing easy 
            {
            char[] columns = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Print column headers
            Console.Write("  ");
            for (uint col = 0; col < gameBoard.Width; col++)
            {
                Console.Write($" {columns[col]} ");
            }
            Console.WriteLine();

            // Print the board rows
            for (uint row = 0; row < gameBoard.Height; row++)
            {
                // Print the horizontal divider
                Console.Write(" =");
                for (uint col = 0; col < gameBoard.Width; col++)
                {
                    Console.Write("====");
                }
                Console.WriteLine();

                // Print the row number
                Console.Write($"{row + 1} ");

                // Print the cards in the row
                for (uint col = 0; col < gameBoard.Width; col++)
                {
                    Board.Card card = gameBoard[row, col];
                    string cardContent = card.IsRevealed ? card.RealObject.ToString() : " ";
                    Console.Write($"| {cardContent} ");
                }
                Console.WriteLine("|");
            }

            // Print the final horizontal divider
            Console.Write(" =");
            for (uint col = 0; col < gameBoard.Width; col++)
            {
                Console.Write("====");
            }
            Console.WriteLine();
             }
         

    

       //mybe add point
        public static bool getPlayerChoiceTodo()
        {

        }//todo
        public static string getOneCardPlayerChoice(out uint x_cordinate ,out uint y_cordinate,GameManager gameManager)//todo
        {
            string inputForGameMode;

            Console.WriteLine("please enter a card to flip ,notice to choose cards only from unfliped card or in board boundries");
            inputForGameMode = Console.ReadLine();
            //check if its intiger and within boundries 
            if ()
            {


            }


            //make sure to take right input from the user 

            inputForGameMode = Console.ReadLine();
            CheckIfValidInputForMenuChoices(ref inputForGameMode);

            return inputForGameMode;
        }
    }
}






















//        private static bool FinishGameAndDecideNext(ref UserInfo i_User1, ref UserInfo i_User2)
//        {
//            bool playAnotherGame = true;
//            Screen.Clear();
//            Console.Write("CONGARTULATIONS!!! ");
//            if (i_User1.Score > i_User2.Score)
//            {
//                Console.Write(i_User1.Name);
//            }
//            else if (i_User1.Score < i_User2.Score)
//            {
//                Console.Write(i_User2.Name);
//            }
//            else
//            {
//                Console.Write("ITS A TIE!");

//            }
//            Console.WriteLine(" YOU WON THE GAME");

//            Console.WriteLine("Do you want to play again? Press 1 for yes and 2 otherwise: ");
//            string mode = Console.ReadLine();
//            CheckIfValidInputForGameMode(ref mode);
//            if (!mode.Equals("1"))
//            {
//                playAnotherGame = !playAnotherGame;

//            }
//            return playAnotherGame;
//        }










//    }
//    //private static void SetGameBoard(ref GameManager io_currentGamePlayed)//maybe move to UI
//    //{
//    //    Logics.getBordeDimension(ref int, ref int);

//    //    Board currentBoardSetUp = new Board(int.Parse(height), int.Parse(width));

//    //    Board fullGameBoard = Board.fillBoardWithValues(int.Parse(height), int.Parse(width));

//    //    Screen.Clear();
//    //    currentBoardSetUp.drawGameBoard();

//    //    io_currentGamePlayed.m_FullBoardWithValues = fullGameBoard;
//    //    io_currentGamePlayed.m_GameBoard = currentBoardSetUp;


//    //}
//}