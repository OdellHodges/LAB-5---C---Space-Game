using System;

namespace LAB_5___C___Space_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //So I have to create a new game and if you are a lot like me I have no clue what I am doing.
            //To ensure I can read this code 6 months from now, I am adding a ton of comments
            //Begin writing the code here in this section. We need to have a title

            Title();
            //Once you add the title, there will be an error message in your error list. You will need to use (Ctrl +.) to create a method.
            // reiteration because I am stupid, create a new method for title using Ctrl + .

            MainMenu();
            //You will need to create a new method for the MainMenu like you did for the Title portion
        }


        public static void Title()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            //You can change the background color in C# by doing the above. It uses an Enum to save a variety of colors. 

            Console.ForegroundColor = ConsoleColor.Gray;
            //I am not sure what the forground color is but it changes some stuff and it looks cool. 

            Console.WriteLine("##############################################");
            //This is where you will add the title of your game using the Console Writeline function. Don't forget the ("")
            Console.WriteLine("##############################################");
            Console.WriteLine("##############################################");
            Console.WriteLine("##############################################");
            Console.WriteLine("##############################################");
            Console.WriteLine("##############################################");


        }

        private static void MainMenu()
        {
            CreatingMenuOptions(); //This reference type was created for the 2 options for initating the game. 

            var userMainMenu = Console.ReadLine();

            userMainMenu.ToUpper();
            //the ToUpper or ToLower feature will allow Visual Studio to take in a vowel regardless if its lower case or upper case

            var validInput = false;
            //We need to create a new input with a true/false function to create a while loop.

            while (validInput == false)
            {
                //the while loop is used to keep running if the user wants to be a jackass and not put in the approriate letter to start the game.
                //its primary purpose is while the user is being a butt, then we will keep returning back to the main screen without quitting the program.

                userMainMenu = Console.ReadLine().ToUpper();

                if (userMainMenu == "S" || userMainMenu == "C")
                //An if statement is how to ask the computer question.
                //the == is how to determine = (equals)
                // the symbol || signifies (or)
                // basically the above text in english would stay "if  userMainMenu is equal to S or C or L..."
                {
                    Console.WriteLine("Welcome to the Matrix... I am the Architect");

                    if (userMainMenu == "S") //We need to create another if else statement within the loop.
                    {
                        StartGame();
                    }
                    else if (userMainMenu == "C") // This if else statement will take in information the user puts in after trying to break my code
                    {
                        CreateCharacter();
                    }

                    validInput = true;
                    //If the user stops messing things up in the code then validInput will be true while executing the loop.
                }
                else
                {
                    validInput = false;
                    //this instance is used if the user continues to screw up my code. 
                    //This statement may be redundant but it must be tested first. 

                    Console.WriteLine("Stop trying to break my program and put in the appropriate parameters I told you to put in!");
                    CreatingMenuOptions(); //Since a method was created for all the options for the game we can use this method to address all 3 console writeline options in the beginnning of the game


                }

                //You can initiate this same process using a switch statement. 
                //The switch statement will enable the user to do the same things as an if else statement but it looks nicer.
                // An example of the code is as follows:
                //switch (Console.ReadLine().ToUpper()) //Within the switch statement, the text "Console.ReadLine().ToUpper()" was inputted.
                //                                      //The puprose of this inputted value is if the user does not input the Captalized letter the program will still read the line
                //{
                //    case "S": // case is the instance of where you want your switch to occur. Therefore, if the user inputs S then the game will start
                //        StartGame();
                //        validInput = true; //Ensure you input the boolean into the code or else your switch statement will not end
                //        break; //The break statement enables the user to stop at this particular instance rather than continue through the switch statement throughout all the parameters.
                //    case "C":
                //        CreateCharacter();
                //        validInput = true;
                //        break;
                //    default: //The default parameter acts as the else statement for switches. 
                //            // In the information below, the is copied directly from the else statement above. 
                //        validInput = false;
                //        Console.WriteLine("Stop trying to break my program and put in the appropriate parameters I told you to put in!");
                //        CreatingMenuOptions();
                //        break;
                //}
            }

            Console.WriteLine($"You have Choosen - {userMainMenu}");
            
            //String inteprelation is initated by adding ($) its just big words that lets you add variables to  Console.Writeline
            //Just ensure you use {} when trying to use this BS feature.
            //Using the (+) feature creates a concatination (Combines) between different Console.Writeline

        }

        private static void CreatingMenuOptions() //Creating this method will enable you to not repeat yourself and have to rewrite the individual console writelines. 
        {
            Console.WriteLine("\n\n(S)tart the game");
            // The \n feature creates a new line in C#. I had no clue so by adding two of them I created two new lines.

            Console.WriteLine("(C)reater a character");
        }

        private static void StartGame()
        {
            var BasePath = $"{AppDomain.CurrentDomain.BaseDirectory} Introduction"; //Creating a JSON file is where I will attempt to store all text information to my story
                                                                                    //The AppDomain function is used to pull the source information from a designated location

            var initialApp = new App(); //The App Class and the Program Class have now been linked with this instance.
                                        // This process is called instanciation
            Console.WriteLine("Let the game begin...");
            initialApp.Run();
        }

        private static void CreateCharacter()
        {
            var Player = new App();
        }

        public static void ClosingMessage(QuitReason quitReason)
        {
            switch (quitReason)
            {
                case QuitReason.UserQuit:
                    Console.WriteLine("Sorry to see you go...\n\n");
                    break;
                case QuitReason.Age:
                    Console.WriteLine("You're 60 years old...\n\n");
                    break;
                case QuitReason.OutofMoney:
                    Console.WriteLine("Your last penny spent...\n\n");
                    break;
                case QuitReason.DontQuit:
                    throw new NotImplementedException("Shouldn't be quitting with DontQuit reason");
            }
        }


    }
}
