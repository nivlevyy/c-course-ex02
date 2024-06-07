using System;
using UserInterface;
using GameLogic;
using GamePlay;
using Ex02.ConsoleUtils;


namespace GameManager
{
    public class TheGame
    {

        private Board m_GameBoard;
        private Board m_FullBoardWithValues;
        private static uint numberOfPlayers;
        private static User[] Players;
        private static uint boardRows;
        private static uint boardCols;




        public uint numOfPlayer
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }

        }

        //public Board gameBoard
        //{
        //    get { return m_GameBoard; }
        //    set { m_GameBoard = value; }
        //}

        public static void start()
        {
          string userChoice;

            while (oneMoreGame)
            {
                PrintmainMenu(out userChoice);
                printChoosePlayerMode();
                createPlayers();

                //need to check what was recived from ^ 
                //if 1  get choices for player or computer game;
                //getMode(ref userChoice);
                //need to check mode from^ and continue the game
                //getPlayerNumber(ref numberOfPlayers);
                //

                oneMoreGame = SetUpGame(//numberOfPlayers, userChoice)pass mode and how many players);


            }
        }

        private static bool SetUpGame(int i_NumberOfPlayers,string i_GameMode)
        {
           TheGame memoryGame = new TheGame();
            bool playAnotherGame = true;
            Console.WriteLine("Please enter your name: ");

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

            
            if (!User.playGame(ref usersOfTheGame ,ref memoryGame))//the actul game, a player didnt press Q; meaning the game is finished;
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

        private static void SetGameBoard(ref TheGame io_currentGamePlayed)//maybe move to UI
        {

            Console.WriteLine("To set up the Game board please select the height and width");

            Logics.getBorderDimension(ref int, ref int);

            Board currentBoardSetUp = new Board(int.Parse(height), int.Parse(width));

            Board fullGameBoard = Board.fillBoardWithValues(int.Parse(height), int.Parse(width));

            Screen.Clear();
            currentBoardSetUp.drawGameBoard();

            io_currentGamePlayed.m_FullBoardWithValues = fullGameBoard;
            io_currentGamePlayed.m_GameBoard = currentBoardSetUp;

        }

        private static void PrintmainMenu(out string o_userInput)
        {
            Console.WriteLine("(1) Start new game.");
            Console.WriteLine("(2) Quit game.");
            o_userInput = Console.ReadLine();
            //valid check
            Logics.checkIfValidInputForMainMenu(ref o_userInput);//why is it public and not private.

        }//working

        private static void printChoosePlayerMode()
        {
            bool isvalid;
            Console.WriteLine("choose how many players will play the game:");
            while(!(numberOfPlayers >= 1))
            {
                isvalid = uint.TryParse(Console.ReadLine(),out numberOfPlayers);
            }

        }//working

       
        private static void createPlayers()
        {
            string userChoice;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("choose (1) for humen player or (2) for computer player");
                userChoice = Console.ReadLine();    
                Logics.checkIfValidInputForMainMenu(ref userChoice);
                if (userChoice == "1")
                {
                    Console.WriteLine("insert player name:");
                    Players[i] = new User(Console.ReadLine(),false);
                }
                else if (userChoice == "2")
                {
                    Players[i] = new User($"Computer{i+1}",true);
                }
            
            }
        }//WORKING

        private static void CreateBoardDimansions()
        {
            Logics.getBorderDimension(out boardRows, out boardCols);
            m_GameBoard(boardRows, boardCols);



        }

        private static void PrintMainScreen()// go to UI
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
    }
}
