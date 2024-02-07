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
            Console.WriteLine($"You have chosen a {pet.Type} named {pet.Name}.");

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
                Console.WriteLine($"Hunger: {pet.Hunger}/10");
                Console.WriteLine($"Happiness: {pet.Happiness}/10");
                Console.WriteLine($"Health: {pet.Health}/10");

                // Time-Based Changes
                pet.IncreaseHunger();
                pet.DecreaseHappiness();

                // Enhanced Interaction Logic
                if (pet.Hunger <= 2)
                {
                    Console.WriteLine("Your pet is very hungry. Please feed it.");
                }
                if (pet.Happiness <= 2)
                {
                    Console.WriteLine("Your pet is very unhappy. It refuses to play.");
                }

                // Exit the application if the pet's health is critically low
                if (pet.Health <= 2)
                {
                    Console.WriteLine("Your pet's health is critically low. Goodbye!");
                    exit = true;
                }
            }
        }
    }

    class Pet
    {
        public string Type { get; }
        public string Name { get; }
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }

        public Pet(string type, string name)
        {
            Type = type;
            Name = name;
            Hunger = 5;
            Happiness = 5;
            Health = 5;
        }

        public void Feed()
        {
            Hunger -= 2;
            Health += 1;
            Console.WriteLine($"{Name} is eating. Hunger decreased and health increased.");
        }

        public void Play()
        {
            Happiness += 1;
            Hunger += 1;
            Console.WriteLine($"{Name} is playing. Happiness increased and hunger slightly increased.");
        }

        public void Rest()
        {
            Health += 1;
            Happiness -= 1;
            Console.WriteLine($"{Name} is resting. Health improved and happiness slightly decreased.");
        }

        public void IncreaseHunger()
        {
            Hunger += 1;
        }

        public void DecreaseHappiness()
        {
            Happiness -= 1;
        }
    }
}
