using System; 

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Functionalities to add AFTER THE WORKSHOP:
             
             1. Let user know how many guesses it took for the right answer - COMPLETE

             2. Ask the user what range they would like to guess a number in - COMPLETE

             3. Create a loop to always start the game over once the right number is guessed. - COMPLETE

             4. Ask the user what difficult level they would like and give the user a message that they used too many guesses. --- FIX OPTION for UNLIMITED GUESSES
                    Other options (2 guesses, 4 guesses) are COMPLETE

             5. Add an "easter egg" that if the user types in a certain phrase, the user gets a message back. 

            */

            bool realInteger = false;
            bool realIntMin = false;
            bool realIntMax = false;
            int userNumberGuess = 0;
            bool correctGuess = false; //hold value if user guessed correctly
            //default is false otherwise the while loop will assume true and quit the game

            //instantiate random number class or make a copy of that random class
            //written as ClassName objectName = 
            Random rand = new Random();
            int userRangeMin = 0; //for the range of the random number
            int userRangeMax = 0;
            int numberGuesses = 0;
            bool validInput = false; //validate user inputs
            int gameCount = 1;

            //best practice to welcome user before starting game
            Console.WriteLine("Welcome to the Number Guessing Game!");

            while (true)
            {
                if (gameCount > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nLET'S PLAY AGAIN!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                while (validInput == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\nROUND " + (gameCount) + "!");
                    Console.Write("\nPlease choose your number range to guess in by first choosing the smallest number in the range: ");

                    string userInputMin = Console.ReadLine();

                    realIntMin = int.TryParse(userInputMin, out userRangeMin);

                    if (realIntMin == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //changes font color...will have to change back after.
                        Console.WriteLine("\nSorry, the input needs to be a whole number. \n");
                        continue; //this will stop the program from going to the next if statements since data not valid
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        validInput = true;

                        //testing that we have an correct input for user MAX
                        //Console.WriteLine(userRangeMin);
                    }
                }

                validInput = false;

                while (validInput == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\nPlease choose the largest number in the range: ");

                    string userInputMax = Console.ReadLine();

                    realIntMax = int.TryParse(userInputMax, out userRangeMax);

                    if (realIntMax == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("\nSorry, the input needs to be a whole number. \n");
                        continue; 
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        validInput = true;

                        //testing that we have an correct input for user MAX
                        //Console.WriteLine(userRangeMax);
                    }
                }

                int randomNumber = rand.Next(userRangeMin, userRangeMax + 1);

                validInput = false;
                int gameLevel = 0;
                bool realIntLvl = false;
                bool noLimit = false;

                //add game difficulty here
                while (validInput == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\nPlease choose a game difficulty level from the list below: \n\n" +
                        "1. Unlimited attempts\n" +
                        "2. 4 attempts\n" +
                        "3. 2 attempts\n\n");

                    string userLevel = Console.ReadLine();

                    realIntLvl = int.TryParse(userLevel, out gameLevel);

                    if (realIntLvl == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("\nSorry, the input needs to be a whole number. \n");
                        continue; //this will stop the program from going to the next if statements since data not valid
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        validInput = true;
                        //testing that we have an correct input for user game level
                        //Console.WriteLine(gameLevel);

                    }

                }

                int limitOfGuesses = 0;

                if (gameLevel == 3)
                {
                    limitOfGuesses = 2;

                } else if (gameLevel == 2) {

                    limitOfGuesses = 4;

                } else if (gameLevel == 1)
                {
                    noLimit = true;
                }

                //TESTING:
                //Console.WriteLine("MIN = " + userRangeMin);
                //Console.WriteLine("MAX = " + userRangeMax);
                //Console.WriteLine(randomNumber +"\n");

                while (correctGuess == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\nPlease Enter a Number Between " + userRangeMin + " and " + userRangeMax + " ==> ");

                    // userNumberGuess = Convert.ToInt32(Console.ReadLine());

                    string userInput = Console.ReadLine();

                    realInteger = int.TryParse(userInput, out userNumberGuess);

                    if (userNumberGuess > userRangeMax || userNumberGuess < userRangeMin || realInteger == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("\nSorry, the number needs to be a whole number between " + userRangeMin + " and " + userRangeMax + ".\n");
                        continue; 
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    if (randomNumber > userNumberGuess)
                    {
                        Console.WriteLine("\nThe Number is Greater than " + userNumberGuess);
                        numberGuesses = numberGuesses + 1;

                        if (numberGuesses >= limitOfGuesses)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou've run out of chances. GAME OVER!");
                            correctGuess = true;
                            validInput = false;
                        } 

                    }
                    else if (randomNumber < userNumberGuess)
                    {
                        Console.WriteLine("\nThe Number is less than " + userNumberGuess);
                        numberGuesses = numberGuesses + 1;

                        if (numberGuesses >= limitOfGuesses)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou've run out of chances. GAME OVER!");
                            correctGuess = true;
                            validInput = false;
                        }
                    }
                    else
                    {
                        numberGuesses = numberGuesses + 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGood Job! The Correct Number is " + randomNumber);
                        Console.WriteLine("\nIt took " + numberGuesses + " attempt(s) to answer correctly!");
                        correctGuess = true;
                        validInput = false; //for the game restart

                    }
                    

                }

                gameCount += 1;
            }
           
            


         





        }
    }
}
