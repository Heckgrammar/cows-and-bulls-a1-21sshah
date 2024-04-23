using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playagain = true;

            int highScore = 0;
            int numOfDigits = 0;
            int minNumber = 0;
            int maxNumber = 0;
            int number = 0;
            string Num2 = "";
            int numOfrepeats = 1;

            int cows = 0;
            int bulls = 0;



            while (playagain == true)

            {



                Console.WriteLine("------------------------------");
                Console.WriteLine("------------Menu--------------");
                Console.WriteLine("A.Play standard game(4 digits)\nB.Change number of digits\nC.Show top score\nD.Quit");
                string choice = Console.ReadLine();
                if (choice == "d" || choice == "D")
                {
                    playagain = false;
                    break;
                }
                else if (choice == "A" || choice == "a")
                {

                    numOfDigits = 4;


                }
                else if (choice == "C" || choice == "c")
                {
                    Console.WriteLine("High score: " + highScore);

                }
                else if (choice == "b" || choice == "B")
                {
                    Console.WriteLine("How many digits? ");

                    numOfDigits = Convert.ToInt32(Console.ReadLine());

                }

                if (choice == "b" || choice == "B" || choice == "A" || choice == "a")
                {
                    while (numOfrepeats != 0)

                    {
                        if (choice == "A" || choice == "a")
                        {
                            Random r = new Random();
                            minNumber = 1234;

                            maxNumber = 9877;

                            number = r.Next(minNumber, maxNumber);
                            Console.WriteLine(number);


                        }
                        else if (choice == "b" || choice == "B")
                        {
                            Random rnd = new Random();
                            minNumber = (int)Math.Pow(10, numOfDigits - 1);

                            maxNumber = (int)Math.Pow(10, numOfDigits) - 1;

                            number = rnd.Next(minNumber, maxNumber);
                        }


                        numOfrepeats = 0;


                        Num2 = Convert.ToString(number);

                        for (int i = 0; i < Num2.Length; i++)
                        {

                            for (int j = 0; j < Num2.Length; j++)
                            {

                                if (Num2[i] == Num2[j] && !(i == j))
                                {


                                    numOfrepeats++;


                                }



                            }
                        }
                        Console.WriteLine(number);
                    }



                    int numOfGuesses = 0;

                    int guess = 0;

                    while (guess != number)

                    {

                        Console.WriteLine("------------------------------------------------------\nEnter a number: ");



                        guess = Convert.ToInt32(Console.ReadLine());

                        numOfGuesses++;

                        string guessTemp = Convert.ToString(guess);

                        char[] guessStr = guessTemp.ToCharArray();

                        bool containsRepeats = false;

                        for (int i = 0; i < guessStr.Length; i++)

                        {

                            for (int j = i + 1; j < guessStr.Length; j++)

                            {

                                if (guessStr[i] == guessStr[j])

                                {

                                    containsRepeats = true;

                                    break;

                                }

                            }

                            if (containsRepeats)

                            {

                                break;

                            }

                        }

                        if (guessStr.Length != numOfDigits || guessStr[0] == '0' || containsRepeats)

                        {

                            Console.WriteLine("Sorry not valid, has to be " + numOfDigits + " digits, first can't be 0 and can't have repeating digits");

                        }

                        else

                        {

                            cows = 0;
                            bulls = 0;

                            for (int i = 0; i < guessStr.Length; i++)

                            {

                                if (guessStr[i] == Num2[i])

                                {

                                    bulls++;

                                }

                                else if (Num2.Contains(guessStr[i]))

                                {

                                    cows++;

                                }

                            }

                            Console.WriteLine("Cows: " + cows);

                            Console.WriteLine("Bulls: " + bulls);



                            if (bulls == numOfDigits)

                            {

                                Console.WriteLine("It took you " + numOfGuesses + " guesses");

                                if ((numOfGuesses < highScore && highScore != 0) || highScore == 0)

                                {

                                    highScore = numOfGuesses;

                                }


                                break;


                            }

                        }



                    }

                }


            }
        }
    }
}
