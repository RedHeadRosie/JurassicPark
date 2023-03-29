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

    class DinosaurDatabase
    {
        //var dinosaurs = new List<Dinosaur>();
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        //CREATE
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }

        //READ
        public List<Dinosaur> GetAllDinos()
        {
            return Dinosaurs;
        }

        //FIND
        public Dinosaur FindOneDino(string dinoToFind)
        {
            Dinosaur foundDino = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == dinoToFind);
            return foundDino;
        }

        //DELETE
        public void DeleteDino(Dinosaur dinoToDelete)
        {
            Dinosaurs.Remove(dinoToDelete);
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

            //var dinosaurs = new List<Dinosaur>();
            var database = new DinosaurDatabase();

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(V)view, (A)add, (R)remove, (T)transfer, (S)summary or (Q)quit");
            Console.WriteLine();
            string response = Console.ReadLine();
            var dinoList = database.GetAllDinos();
            while (response != "Q" || response != "q")
            {

                if (response == "V" || response == "v")
                {
                    Console.WriteLine("Would you like to see the dinosaurs in (N)name or (E)enclosure number? ");
                    string viewingOptions = Console.ReadLine();
                    if (viewingOptions == "N" || viewingOptions == "n")
                    {
                        //var dinoNames = dinosaurs.OrderBy(dinosaur => dinosaur.Name);
                        Console.WriteLine("The different dinosaurs in your park are:");
                        foreach (var dino in dinoList)
                        {
                            Console.WriteLine(dino.Name);
                        }

                        if (dinoList.Count == 0)
                        {
                            Console.WriteLine("This is a special message to let you know your park is empty and all the dinos have escaped!");
                        }
                    }
                    else if (viewingOptions == "E" || viewingOptions == "e")
                    {
                        Console.WriteLine("The dinosaurs in your park are in the following enclosures:");

                        var dinoEnclosures = dinoList.OrderBy(dinosaur => dinosaur.EnclosureNumber);

                        foreach (var dino in dinoEnclosures)
                        {
                            Console.WriteLine($"dinosaur {dino.Name} is in enclosure number {dino.EnclosureNumber}");
                        }

                        if (dinoList.Count == 0)
                        {
                            Console.WriteLine("This is a special message to let you know your park is empty and all the dinos have escaped!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have not chosen N or E so you will be returned to the main menu");
                        break;
                    }
                }
                else if (response == "A" || response == "a")
                {
                    var dinoToAdd = new Dinosaur();
                    dinoToAdd.Name = PromptForString("What is the name of your dinosaur? ");
                    dinoToAdd.DietType = PromptForString("Is your dinosaur a herbivore or a carnivore? ");
                    dinoToAdd.Weight = PromptForInteger("What is the weight of your dinosaur? ");
                    dinoToAdd.EnclosureNumber = PromptForInteger("Which enclosure number is your dinosaur in? ");
                    dinoList.Add(dinoToAdd);
                    Console.WriteLine();
                    Console.WriteLine("Dino Added!");
                    Console.WriteLine();

                }
                else if (response == "R" || response == "r")
                {
                    var dinoToRemove = PromptForString("What is the name of the dinosaur you want to remove? ");

                    Dinosaur foundDino = database.FindOneDino(dinoToRemove);

                    if (foundDino != null)
                    {
                        Console.WriteLine($"{foundDino.Name} is in enclosure {foundDino.EnclosureNumber}. Their diet type is {foundDino.DietType} and their weight is {foundDino.Weight}. ");
                        var confirm = PromptForString("Are you sure? Y or N : ").ToUpper();
                        if (confirm == "Y")
                        {
                            Console.WriteLine($"{foundDino.Name} has been removed. ");
                            Console.WriteLine();
                            database.DeleteDino(foundDino);

                        }
                        else
                        {
                            Console.WriteLine("Nothing has been changed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No such dino");
                        Console.WriteLine();
                    }

                }
                else if (response == "T" || response == "t")
                {
                    var dinoToTransfer = PromptForString("What is the name of the dinosaur you want to transfer? ");
                    var newEnclosure = PromptForInteger("What is the enclosure number you want to move this dino to? ");

                    Dinosaur foundDino = database.FindOneDino(dinoToTransfer);

                    if (foundDino != null)
                    {
                        Console.WriteLine($"{foundDino.Name} is in enclosure {foundDino.EnclosureNumber}. Their diet type is {foundDino.DietType} and their weight is {foundDino.Weight}. ");
                        var confirm = PromptForString($"Are you sure you want to move them to {newEnclosure}? Y or N : ").ToUpper();
                        if (confirm == "Y")
                        {
                            var tempDinoToAdd = new Dinosaur();
                            tempDinoToAdd.Name = foundDino.Name;
                            tempDinoToAdd.DietType = foundDino.DietType;
                            tempDinoToAdd.Weight = foundDino.Weight;
                            tempDinoToAdd.EnclosureNumber = newEnclosure;
                            database.DeleteDino(foundDino);
                            database.AddDinosaur(tempDinoToAdd);

                            Console.WriteLine($"{tempDinoToAdd.Name} has been moved to {tempDinoToAdd.EnclosureNumber}. ");
                            Console.WriteLine();

                        }
                        else
                        {
                            Console.WriteLine("Nothing has been changed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No such dino");
                        Console.WriteLine();
                    }


                }
                else if (response == "S" || response == "s")
                {

                    var herbivores = dinoList.Where(dino => dino.DietType == "herbivore" || dino.DietType == "Herbivore");
                    Console.WriteLine("The herbivores are: ");
                    foreach (var dino in herbivores)
                    {
                        Console.WriteLine(dino.Name);
                    }

                    var carnivores = dinoList.Where(dino => dino.DietType == "carnivore" || dino.DietType == "Carnivore");
                    Console.WriteLine("The carnivores are: ");
                    foreach (var dino in carnivores)
                    {
                        Console.WriteLine(dino.Name);
                    }

                    Console.WriteLine($"There are {carnivores.Count()} carnivores and {herbivores.Count()} herbivores in the park.");


                    //foreach (var output in dinosaurs)
                    //{
                    //    Console.WriteLine(output.Description());
                    //}
                }
                else if (response == "Q" || response == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose one of the options, V, A, R, T, S or Q");
                }
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(V)view, (A)add, (R)remove, (T)transfer, (S)summary or (Q)quit");
                Console.WriteLine();
                response = Console.ReadLine();

            }

        }
    }
}
