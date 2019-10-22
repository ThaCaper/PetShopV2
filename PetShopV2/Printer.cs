using System;
using System.Collections.Generic;
using PetShopV2.Core.AppService;
using PetShopV2.Core.Entity;

namespace PetShopV2.ConsoleApp
{
    public class Printer : IPrinter
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;

        public Printer(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;
        }

        public void StartUI()
        {
            string[] menuItems =
            {
                "List All Pets",
                "Add New Pet",
                "Delete Pet",
                "Manage Pet",
                "Check out the 5 cheapest Pets",
                "Search Pet by Type",
                "Check out Owners",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        ListOfPets(pets);
                        break;
                    case 2:
                        AddPet();
                        break;
                    case 3:
                        DeletePet();
                        break;
                    case 4:
                        ManagePet();
                        break;
                    case 5:
                        Cheapest5Pets();
                        break;
                    case 6:
                        SearchPetByType();
                        break;
                    default:
                        break;
                }

                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Byeeeeeee");
        }

        #region Pet related methods

        private void SearchPetByType()
        {
            Console.WriteLine("Write the pet type you want:\n ");
            string type;
            while ((type = Console.ReadLine()).Length == 0)
            {
                Console.WriteLine("Ex: Dog, Cat, Goat...");
            }

            List<Pet> resultOfTypePets = _petService.SearchPetByType(type);
            ShowSearchResults(resultOfTypePets);
        }

        private void Cheapest5Pets()
        {
            _petService.Cheapest5Pets();
        }

        private void ManagePet()
        {
            var petIdForUpdate = PrintFindPetById();
            var petToUpdate = _petService.GetPetById(petIdForUpdate);

            Console.WriteLine("Updating " + petToUpdate.Name + " " + petToUpdate.Type);

            AskQuestion("New name: ");
            string newName;
            while ((newName = Console.ReadLine()).Length == 0)
            {
                Console.WriteLine("A pet must have a name! ");
            }

            AskQuestion("New Price: ");
            double newPrice;
            while (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Please find the right price for the pet!");
            }
            AskQuestion("\nNew Sold Date maybe?");
            AskQuestion("Year: ");
            int years;
            while (!int.TryParse(Console.ReadLine(), out years))
            {
                Console.WriteLine("Please write a year in 4 digits, ex: 1999! ");
            }

            AskQuestion("Month: ");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month))
            {
                Console.WriteLine("Please write a month from 1-12! ");
            }
            AskQuestion("Day: ");
            int day;
            while (!int.TryParse(Console.ReadLine(), out day))
            {
                Console.WriteLine("Please write a year in 4 digits, ex: 1999 ");
            }
            DateTime birthdate = DateTime.Now.AddYears(years).AddMonths(month).AddDays(day);

            _petService.UpdatePet(new Pet()
            {
                Id = petIdForUpdate,
                Name = newName,
                Price = newPrice,
                SoldDate = birthdate
            });

        }

        private void DeletePet()
        {
            var deletePet = PrintFindPetById();
            _petService.DeletePet(deletePet);
        }

        private void AddPet()
        {
            AskQuestion("Pet Type:");
            string type;
            while ((type = Console.ReadLine()).Length == 0)
            {
                Console.WriteLine("A pet must have a name! ");
            }

            AskQuestion("The pets name: ");
            string name;
            while ((name = Console.ReadLine()).Length == 0)
            {
                Console.WriteLine("A pet must have a name! ");
            }

            AskQuestion("What year was it born?: ");
            int years;
            while (!int.TryParse(Console.ReadLine(), out years))
            {
                Console.WriteLine("When was it born?");
            }

            AskQuestion("What Month was it born?: ");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month))
            {
                Console.WriteLine("Please write a month from 1-12! ");
            }

            AskQuestion("What Day was it born?: ");
            int day;
            while (!int.TryParse(Console.ReadLine(), out day))
            {
                Console.WriteLine("Please write a year in 4 digits, ex: 1999 ");
            }
            DateTime birthdate = DateTime.Today.AddYears(years).AddMonths(month).AddDays(day);

            AskQuestion("Color: ");
            string color;
            while ((color = Console.ReadLine()).Length == 0)
            {
                Console.WriteLine("Must have a color");
            }


            AskQuestion("Price: ");
            double priced;
            while (!double.TryParse(Console.ReadLine(), out priced))
            {
                Console.WriteLine("Ex: 1999.99");
            }

            AskQuestion("Who was the previous owner?: ");
            string previousOwner;
            while ((previousOwner = Console.ReadLine()).Length == 0)
            {
                Console.WriteLine("Must have an owner");
            }

            Pet pet = _petService.NewPet(name, type, birthdate, color, priced, previousOwner);
            Console.WriteLine("Pet have been added! ");
            _petService.CreatePet(pet);
        }

        private void ListOfPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets: ");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} Name: {pet.Name}" +
                          $"Type: {pet.Type} Color: {pet.Color}" +
                          $"Birthdate: {pet.BirthDate}");
            }
            Console.WriteLine("\n");
        }

        private int PrintFindPetById()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        #endregion

        #region Owner Related methods

        

        #endregion
        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }


        private string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void ShowSearchResults(List<Pet> searchResults)
        {
            if (searchResults.Count != 0)
            {
                Console.WriteLine("Results:");
                foreach (var pet in searchResults)
                {
                    Console.WriteLine("Name: " + pet.Name + " Type: " + pet.Type);
                }
            }
            else
            {
                Console.WriteLine("No Pets found");
            }
        }

    }
}