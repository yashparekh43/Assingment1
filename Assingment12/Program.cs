using System;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pet Creation
            Console.WriteLine("Welcome to Virtual Pet!");
            Console.WriteLine("Please choose a pet type: ");
            string petType = Console.ReadLine();
            Console.WriteLine("Please enter a name for your pet: ");
            string petName = Console.ReadLine();
            Pet pet = new Pet(petType, petName);

            // Pet Care Actions
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Rest();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                // Pet Status Monitoring
                pet.DisplayStats();

                // Time-Based Changes
                pet.PassTime();

                // Enhanced Interaction Logic
                pet.CheckStatus();

                // User Interface and Experience
                Console.WriteLine();
            }
        }
    }

    class Pet
    {
        private string type;
        private string name;
        private int hunger;
        private int happiness;
        private int health;

        public Pet(string type, string name)
        {
            this.type = type;
            this.name = name;
            this.hunger = 5;
            this.happiness = 5;
            this.health = 5;
        }

        public void Feed()
        {
            Console.WriteLine($"{name} is eating.");
            hunger--;
            health++;
        }

        public void Play()
        {
            Console.WriteLine($"{name} is playing.");
            happiness++;
            hunger++;
        }

        public void Rest()
        {
            Console.WriteLine($"{name} is resting.");
            health++;
            happiness--;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Stats for {name}:");
            Console.WriteLine($"Hunger: {hunger}/10");
            Console.WriteLine($"Happiness: {happiness}/10");
            Console.WriteLine($"Health: {health}/10");
        }

        public void PassTime()
        {
            hunger++;
            happiness--;
        }

        public void CheckStatus()
        {
            if (hunger <= 2)
            {
                Console.WriteLine($"{name} is very hungry. Please feed {name}!");
            }
            else if (hunger >= 8)
            {
                Console.WriteLine($"{name} is too full. {name} doesn't want to eat right now.");
            }

            if (happiness <= 2)
            {
                Console.WriteLine($"{name} is very unhappy. {name} wants to play!");
            }
            else if (happiness >= 8)
            {
                Console.WriteLine($"{name} is very happy. {name} doesn't want to play right now.");
            }
        }
    }
}
