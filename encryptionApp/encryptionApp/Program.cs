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
                //Number var
                int inputNum = 0;

                //Direct and Prompt User
                Console.WriteLine("Enter the name of the cipher/encryption method you would like to use. ");
                Console.WriteLine("Enter 'q' to exit or 'options' to see what forms of encryption/ciphers are available): ");
                runType = Console.ReadLine();
                if (runType.ToLower() == "q")
                {
                    Environment.Exit(0);
                }
                else if (runType.ToLower() == "options")
                {
                    //Show users what kind of options are available
                    Console.WriteLine(" ");
                    Console.WriteLine("Type: ");
                    Console.WriteLine("'caesar' for the Caesar Cipher");
                    Console.WriteLine("'morse' for Morse Code");
                    Console.WriteLine("'hill' for the Hill Cipher");
                    Console.WriteLine("'random' for a random cipher");
                    Console.WriteLine(" ");
                }
                else if (runType.ToLower() == "caesar")
                {
                    //Report type chosen and prompt user for input
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Caesar");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    //Grab input and run given function
                    inputString = Console.ReadLine();
                    Console.WriteLine(" ");
                    //Prompt for shift
                    Console.WriteLine("Please enter a number greater than 0: ");
                    //Grab input and run given function
                    inputNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" ");
                    //Fill End String
                    endString = caesarFunc(inputString.ToLower(), inputNum);
                    Console.WriteLine(" ");
                    //Output string given by function
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
                else if (runType.ToLower() == "morse")
                {
                    //Report type chosen and prompt user for input
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Morse");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    //Grab input and run given function
                    inputString = Console.ReadLine();
                    endString = morseFunc(inputString.ToLower());
                    Console.WriteLine(" ");
                    //Output string given by function
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
                else if (runType.ToLower() == "hill")
                {
                    //Report type chosen and prompt user for input
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Hill");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    //Grab input and run given function
                    inputString = Console.ReadLine();
                    endString = hillFunc(inputString);
                    Console.WriteLine(" ");
                    //Output string given by function
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
                else if (runType.ToLower() == "random")
                {
                    //Add a random number generator to choose which method gets picked.
                    Console.WriteLine(" ");
                    Console.WriteLine("Type chosen: Random");
                    Console.WriteLine("Please enter the string you would like encrypted: ");
                    //Grab input and run given function
                    inputString = Console.ReadLine();
                    endString = hillFunc(inputString);
                    Console.WriteLine(" ");
                    //Output string given by function
                    Console.WriteLine("Your encrypted string is: " + endString);
                    Console.WriteLine(" ");
                }
            }
        }

        private static string caesarFunc(string input, int num)
        {
            //Variables
            StringBuilder transformedString = new StringBuilder();
            string charPool = "abcdefghijklmnopqrstuvwxyz";
            char[] charPoolArray = charPool.ToCharArray();
            char findChar;
            char changedChar;

            //Break input into a separate char array
            char[] inputCharArray = input.ToCharArray();

            //Find 
            for(int i = 0; i < input.Length; i++)
            {
                //Find the index of the first character in the inputCharArray
                findChar = inputCharArray[i];
                
                //Another for loop to loop through the charPoolArray with the findChar
                for (int j = 0; j < charPool.Length; j++)
                {
                    if (charPoolArray[j] == findChar)
                    {
                        int k = j + num;

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
            //Variable
            string almostFinalString = "";
            string finalString = "";

            //Dictionary
            Dictionary<char, string> morseDict = new Dictionary<char, string>()
            {
                {'a', ".-"},
                {'b', "-..."},
                {'c', "-.-." },
                {'d', "-.." },
                {'e', "."},
                {'f', "..-."},
                {'g', "--."},
                {'h', "...."},
                {'i', ".."},
                {'j', ".---"},
                {'k', "-.-"},
                {'l', ".-.."},
                {'m', "--"},
                {'n', "-."},
                {'o', "---"},
                {'p', ".--."},
                {'q', "--.-"},
                {'r', ".-."},
                {'s', "..."},
                {'t', "-"},
                {'u', "..-"},
                {'v', "...-"},
                {'w', ".--"},
                {'x', "-..-"},
                {'y', "-.--"},
                {'z', "--.."},
                {'0', "-----"},
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."},
                {'.', ".-.-.-"},
                {',', "--..--"},
                {'!', "-.-.--"},
                {'?', "..--.."},
                {'(', "-.--."},
                {')', "-.--.-"},
                {'&', ".-..."},
                {':', "---..."},
                {';', "-.-.-."},
                {'=', "-...-"},
                {'_', "..--.-"},
                {'@', ".--.-."},
                {'$', "...-..-"},
                {'-', "-....-"},
                {'/', "-..-."}
            };

            //Stringbuilder for easy char append
            StringBuilder transformedString = new StringBuilder();

            foreach (char character in input)
            {
                if (morseDict.ContainsKey(character))
                {
                    transformedString.Append(morseDict[character] + " ");
                }
                else if (character == ' ')
                {
                    transformedString.Append("/ ");
                }
                else
                {
                    transformedString.Append(character + " ");
                }
            }

            //Almost final string.
            almostFinalString = transformedString.ToString();

            //Check for apostrophes and replace, put into final string.
            finalString = almostFinalString.Replace("'", ".----.");

            //Return final string.
            return finalString;
        }

        private static string hillFunc(string input)
        {
            //Variables
            string transformedString = "";

            return transformedString;
        }
    }
}
