using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PetShopV2.Core.AppService;
using PetShopV2.Core.Entity;

namespace PetShopV2
{
    public class Printer : IPrinter
    {
        private readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
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
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 6)
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
                    default:
                        break;
                }

                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Byeeeeeee");
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

            var newName = AskQuestion("New name: ");
            AskQuestion("New Price: ");
            double newPrice = double.Parse(Console.ReadLine());

            AskQuestion("\nNew Sold Date maybe?");
            AskQuestion("Year: ");
            int years = int.Parse(Console.ReadLine());

            AskQuestion("Month: ");
            int month = int.Parse(Console.ReadLine());

            AskQuestion("Day: ");
            int day = int.Parse(Console.ReadLine());
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
            var type = AskQuestion("Pet Type:");
            var name = AskQuestion("The pets name: ");
            AskQuestion("Years old: ");
            int years = int.Parse(Console.ReadLine());
            DateTime birthdate = DateTime.Today.AddYears(years);
            var color = AskQuestion("Color: ");
            AskQuestion("Price: ");
            double priced = double.Parse(Console.ReadLine());
            var previousOwner = AskQuestion("Who was the previous owner?: ");
            Pet pet = _petService.newPet(name, type, birthdate, color, priced, previousOwner);

            _petService.createPet(pet);
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
                   || selection > 6)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }


        private string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }


    }
}