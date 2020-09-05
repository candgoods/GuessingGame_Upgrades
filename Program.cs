using System; //we need this to do certain things in our code; Console is part of this namespace
//then we specify the namespace we use "system"

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Functionalities to add AFTER THE WORKSHOP:
             
             1. Let user know how many guesses it took for the right answer - COMPLETE

             2. Ask the user what range they would like to guess a number in - COMPLETE

             3. Create a loop to always start the game over once the right number is guessed. 

             4. Ask the user what difficult level they would like and give the user a message that they used too many guesses.

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

            //best practice to welcome user before starting game
            Console.WriteLine("Welcome to the Number Guessing Game!");

            while (validInput == false)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\nPlease choose your number range to guess in by first choosing the smallest number in the range: ");

                string userInputMin = Console.ReadLine();

                realIntMin = int.TryParse(userInputMin, out userRangeMin);

                if (realIntMin == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //changes font color...will have to change back after.
                    Console.WriteLine("\nSorry, the number needs to be a whole number. \n");
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
                    Console.ForegroundColor = ConsoleColor.Red; //changes font color...will have to change back after.
                    Console.WriteLine("\nSorry, the number needs to be a whole number. \n");
                    continue; //this will stop the program from going to the next if statements since data not valid
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
                    Console.ForegroundColor = ConsoleColor.Red; //changes font color...will have to change back after.
                    Console.WriteLine("\nSorry, the number needs to be a whole number between " +userRangeMin + " and " + userRangeMax +".\n");
                    continue; //this will stop the program from going to the next if statements since data not valid
                    Console.ForegroundColor = ConsoleColor.White;
                }
               

                if (randomNumber > userNumberGuess)
                {
                    Console.WriteLine("\nThe Number is Greater than " + userNumberGuess);
                    numberGuesses = numberGuesses + 1;
                }
                else if (randomNumber < userNumberGuess)
                {
                    Console.WriteLine("\nThe Number is less than " + userNumberGuess);
                    numberGuesses = numberGuesses + 1;
                }
                else
                {
                    numberGuesses = numberGuesses + 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGood Job! The Correct Number is " + randomNumber);
                    Console.WriteLine("\n It took " + numberGuesses + " guesses to answer correctly!");
                    correctGuess = true;

                }
                
            }       


           
            


         





        }
    }
}
