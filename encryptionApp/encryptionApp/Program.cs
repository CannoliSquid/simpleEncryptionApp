using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Fun little console app.
    Different kinds of ciphers demonstrated
    Eric Basini, 11/15/17
*/

namespace encryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool forestGump = true;

            while (forestGump == true)
            {
                //Variables

                //"What do you want to run?"
                string runType = "";
                //"What would you like "encrypted""?
                string inputString = "";
                //"What is it like now?"
                string endString = "";

                //Direct and Prompt User
                Console.WriteLine("Enter the name of the cipher/encryption method you would like to use. ");
                Console.WriteLine("Enter 'q' to exit or 'options' to see what forms of encryption/ciphers are available): ");
                runType = Console.ReadLine();
                if (runType.ToLower() == "q")
                {
                    Environment.Exit(0);
                }
                if (runType.ToLower() == "options")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Type: ");
                    Console.WriteLine("'caesar' for the Caesar Cipher");
                    Console.WriteLine("'morse' for Morse Code");
                    Console.WriteLine("'hill' for the Hill Cipher");
                    Console.WriteLine("'random' for a random cipher");
                    Console.WriteLine(" ");
                }
                if (runType.ToLower() == "caesar")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Caesar");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    inputString = Console.ReadLine();
                    endString = caesarFunc(inputString);
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
                if (runType.ToLower() == "morse")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Morse");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    inputString = Console.ReadLine();
                    endString = morseFunc(inputString);
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
                if (runType.ToLower() == "hill")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Hill");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    inputString = Console.ReadLine();
                    endString = hillFunc(inputString);
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
                if (runType.ToLower() == "random")
                {
                    //Add a random number generator to choose which method gets picked.
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Random");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    inputString = Console.ReadLine();
                    Console.WriteLine(" ");
                }
            }
        }

        private static string caesarFunc(string input)
        {
            //Variables
            StringBuilder transformedString = new StringBuilder();
            string charPool = "abcdefghijklmnopqrstuvwxyz";
            char[] charPoolArray = charPool.ToCharArray();
            char findChar;
            char changedChar;
            string spacelessInput = input.Replace(" ", "");

            //Break input into a separate char array
            char[] inputCharArray = spacelessInput.ToCharArray();

            //Find 
            for(int i = 0; i < spacelessInput.Length; i++)
            {
                //Find the index of the first character in the inputCharArray
                findChar = inputCharArray[i];

                //fix this check to see if its a number
                if (findChar==0)
                {

                }

                //Another for loop to loop through the charPoolArray with the findChar
                for (int j = 0; j < charPool.Length; j++)
                {
                    if(charPoolArray[j] == findChar)
                    {
                        int k = j+3;

                        if (k > 25)
                        {
                            k = k - 26;
                            changedChar = charPoolArray[k];
                        }
                        else
                        {
                            changedChar = charPoolArray[k];
                        }

                        transformedString.Append(changedChar);
                        Console.WriteLine("Added character " + changedChar.ToString() + " to the encrypted result.");
                    }
                }
            }
            
            //Return the encrypted string
            return transformedString.ToString();
        }

        private static string morseFunc(string input)
        {
            string transformedString = "";

            return transformedString;
        }

        private static string hillFunc(string input)
        {
            string transformedString = "";

            return transformedString;
        }
    }
}
