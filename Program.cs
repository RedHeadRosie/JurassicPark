using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{

    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; } = DateTime.Now;
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }

        public string Description()
        {
            string newDescript = (Name + " has a diet type of " + DietType + ". It weighs " + Weight + " and it's kept in enclosure number " + EnclosureNumber + ". It was added on " + WhenAcquired + ".");
            return newDescript;
        }
    }
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Ah Ah Ah, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("─────────────────────");
            Console.WriteLine("───────────████████──");
            Console.WriteLine("──────────███▄███████");
            Console.WriteLine("──────────███████████     ----------------------------------");
            Console.WriteLine("──────────███████████         Welcome to Jurassic Park      ");
            Console.WriteLine("──────────██████─────     ----------------------------------");
            Console.WriteLine("──────────█████████──");
            Console.WriteLine("█───────███████──────");
            Console.WriteLine("██────████████████───");
            Console.WriteLine("███──██████████──█───");
            Console.WriteLine("███████████████──────");
            Console.WriteLine("███████████████──────");
            Console.WriteLine("─█████████████───────");
            Console.WriteLine("──███████████────────");
            Console.WriteLine("────████████─────────");
            Console.WriteLine("─────███──██─────────");
            Console.WriteLine("─────██────█─────────");
            Console.WriteLine("─────█─────█─────────");
            Console.WriteLine("─────██────██────────");
            Console.WriteLine("─────────────────────");
            Console.WriteLine();

            var dinosaurs = new List<Dinosaur>();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(V)view, (A)add, (R)remove, (T)transfer, (S)summary or (Q)quit");
            Console.WriteLine();
            string response = Console.ReadLine();
            while (response != "Q" || response != "q")
            {

                if (response == "V" || response == "v")
                {
                    foreach (var output in dinosaurs)
                    {
                        Console.WriteLine(output.Description());
                    }
                }
                else if (response == "A" || response == "a")
                {
                    var dinoToAdd = new Dinosaur();
                    dinoToAdd.Name = PromptForString("What is the name of your dinosaur? ");
                    dinoToAdd.DietType = PromptForString("Is your dinosaur a herbivore or a carnivore? ");
                    dinoToAdd.Weight = PromptForInteger("What is the weight of your dinosaur? ");
                    dinoToAdd.EnclosureNumber = PromptForInteger("Which enclosure number is your dinosaur in? ");
                    dinosaurs.Add(dinoToAdd);
                    //Console.WriteLine($"{dinoToAdd.Description()}");
                    Console.WriteLine();
                    Console.WriteLine("Dino Added!");
                    Console.WriteLine();

                }
                else if (response == "R" || response == "r")
                {

                }
                else if (response == "T" || response == "t")
                {

                }
                else if (response == "S" || response == "s")
                {

                }
                else if (response == "Q" || response == "q")
                {
                    break;
                }
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(V)view, (A)add, (R)remove, (T)transfer, (S)summary or (Q)quit");
                Console.WriteLine();
                response = Console.ReadLine();

            }


        }
    }
}
