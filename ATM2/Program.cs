using System;
using System.Collections.Generic;

namespace ATM2
{
    class Program
    {
        public class PersonAccount
        {
            public int _accountName { get; set; }
            public int _accountPin { get; set; }

            public PersonAccount(int accountName, int accountPin) 
            {
                _accountName = accountName;
                _accountPin = accountPin;
            }
        }
        public const decimal _maxAmountOfMoneyInput = 1000;
        static int pinNumber;


        static void Main(string[] args)
        {
            List<PersonAccount> AccountList = new List<PersonAccount>();
            bool quitChoice = true;
            int option;
            string userEntry;
            while (quitChoice)
            {
                Logotype();             //just a logotype
                getWelcome();           //welcomes the user
                option = MenuChoice();   //First menu, choose between Account creation or log into your account
                switch (option) 
                {
                    case 1:             //Generates an account
                        Console.Clear();
                        Logotype();
                        PersonAccount p1 = (AccountCreation());
                        AccountList.Add(p1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"A card has successfully been generated");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                        break;

                    case 2:             //Log into your account
                        Console.Clear();
                        Logotype();
                        LogIn(AccountList);
                        break;
                };

                Console.Clear();
                Logotype();
                Console.WriteLine("Would you like to quit to continue? \"y / n\""); //asks the user wether to quit or to continue
                userEntry = Console.ReadLine();

                if (userEntry.ToLower() == "y") // yes to continue the program
                {
                    Console.Clear();
                    continue;
                }
                else if (userEntry.ToLower() == "n") // no to exit the program
                {
                    quitChoice = false;
                }
                else //any other input will result in the loop continuing
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine($"\"{userEntry}\" is not a valid input! Try again!");
                    continue;
                }
            }
        }
        public static void LogIn(List<PersonAccount> AccountList) // Log in to your account
        {
            bool quitOption = true;
            while (quitOption)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string userEntry;
                Console.WriteLine("Hello and welcome to the banks login page");
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome user, {AccountList.Count} accounts has been generated");
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (var name in AccountList)
                {
                    Console.WriteLine($"{name._accountName}");
                    Console.WriteLine($"{name._accountPin}");
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("please type your \"username; login\"");
                userEntry = Console.ReadLine();
                string[] parts = userEntry.Split(';');




                Console.ReadKey();
            }
        }
        private static void getWelcome() //welcomes to user!
        {
            Console.WriteLine("Hello, Welcome to Kallhälls ATM!");
            Console.WriteLine("---------------------------------");
        }
        private static void Logotype() //logotype!
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n");
            Console.WriteLine("   █████  ████████ ███    ███");
            Console.WriteLine("  ██   ██    ██    ████  ████");
            Console.WriteLine("  ███████    ██    ██ ████ ██");
            Console.WriteLine("  ██   ██    ██    ██  ██  ██");
            Console.WriteLine("  ██   ██    ██    ██      ██");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private static PersonAccount AccountCreation() //creates a card and returns cardnr and cardpin and created account
        {
            string userEntry;
            
            bool loopQuit = true;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type in a creditcardnumber, it has to be 10 digits!");
                userEntry = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(userEntry, out int cardNr) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, {userEntry.ToString()} is not a valid input! Try again!");  //checks if userinput is correct, store it to variables and returns person with cardNr and PinNumber
                    continue;
                }
                if (userEntry.Length != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, {userEntry.ToString()} is not a valid input! Try again!");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please insert your pin number");
                userEntry = Console.ReadLine();
                Console.WriteLine();

                if (userEntry.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, {userEntry.ToString()} is not a valid input! Try again!");
                    continue;

                }
                if (int.TryParse(userEntry, out pinNumber) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, {userEntry.ToString()} is not a valid input! Try again!");
                    continue;
                }
                else 
                {
                    return (new PersonAccount(cardNr, pinNumber));   
                }
            }

        }
        public static int MenuChoice() //returns an integer with menu choice
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string userEntry;
                int option;
                bool userEntryLegal;
                Console.WriteLine();
                Console.WriteLine("1 - Create a new account");
                Console.WriteLine("2 - Log into your account");

                userEntry = Console.ReadLine();
                userEntryLegal = int.TryParse(userEntry, out option);

                if (!userEntryLegal)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, {userEntry.ToString()} is not a valid input! Try again!");
                    continue;
                }
                if (option < 1 || option > 2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, {userEntry.ToString()} is not a valid input! Try again!");
                    continue;
                }
                else 
                {
                    return option;
                }
            }
        }

    }
}




/*
This simple project will essentially create a simulation of an ATM within a Windows program. Just like an ATM, the program should have at least the following features:

Checking whether an input – such as an ATM card (a debit/credit card number) – is recorded correctly
Verifying the user by asking for a PIN
In case of negative verification, logging out the user
In case of positive verification, showing multiple options, including cash availability, the previous five transactions, and cash withdrawal
Giving the user the ability to withdraw up to $1,000 worth of cash in one transaction, with total transactions limited to ten per day. <--
For a more complicated program, include the ability to register a new PIN and mobile number, a detailed bank statement, and a “fast” cash withdrawal system for quickly withdrawing $20, $50, or $100. */