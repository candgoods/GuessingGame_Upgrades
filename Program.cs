using System; //we need this to do certain things in our code; Console is part of this namespace
//then we specify the namespace we use "system"

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool realInteger = false;
            bool realIntMin = false;
            bool realIntMax = false; 

            int userNumberGuess = 0;
            bool correctGuess = false; //hold value if user guessed correctly
            //default is false otherwise the while loop will assume true and quit the game

            //instantiate random number class or make a copy of that random class
            //written as ClassName objectName = 
            Random rand = new Random();
            int userRangeMin = 0;
            int userRangeMax = 0;
            int randomNumber = rand.Next(userRangeMin, userRangeMax+1); // allow player to choose the guessing range
            //it will not include that max. So if you want to include 20, make the max 21
            int numberGuesses = 0;
            bool validInput = false;
     

            //best practice to welcome user before starting game
            Console.WriteLine("Welcome to the Number Guessing Game!");

            //Console.WriteLine(); //this will add a new line
            //can also use a new line character \n within the quotation marks

            while (correctGuess == false)
            {
                //change back to default color
                Console.ForegroundColor = ConsoleColor.White;
                //prompt user for input
                //Console.Write("\nPlease Enter a Number Between 1 and 20 ==> ");
                
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


                Console.Write("\nPlease Enter a Number Between " + userRangeMin + " and " + userRangeMax +" ==> ");

                //get user input
                //string userInput = Console.ReadLine();
                userNumberGuess = Convert.ToInt32(Console.ReadLine());

                //Readline only takes in a string which is why we aren't setting as an integer

                /*readline and writeline are their own methods that exist already
                Console is the class that those methods exist in*/

                /*if we want to get the input on the same line, we should use 
                Console.Write instead of console.writeLine*/

                //Validate user inputs
                //realInteger

                //realInteger = int.TryParse(userInput, out userNumberGuess);
                /*tryparse is a method to use on strings; you will parse/sift through data 
                 * to determine if number in data input*/

                if (userNumberGuess > userRangeMax || userNumberGuess < userRangeMin || realInteger == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //changes font color...will have to change back after.
                    Console.WriteLine("\nSorry, the number needs to be a whole number between 1 and 20.\n");
                    continue; //this will stop the program from going to the next if statements since data not valid
                    Console.ForegroundColor = ConsoleColor.White; 
                }

                //Console.WriteLine("User Input ==> " + userInput + "\n");

                //+ is not the only way to concatenate. See below
                //Console.WriteLine($"Is this a real int? ==> {realInteger}");

                //now to determine how close the user guess is to the random number

                //test that random code is working properly
                //Console.WriteLine(randomNumber); //debugging remove later

                //is random number greater than users guess
                //while (userNumberGuess != randomNumber) {
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
                    //}
                }
            }


         





        }
    }
}
