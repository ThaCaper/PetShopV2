using System;
using System.Runtime.InteropServices;
using PetShopV2.Core.AppService;

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

            var selection = showMenu(menuItems);

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        listOfPets();
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
            }
        }

        private void Cheapest5Pets()
        {
            throw new NotImplementedException();
        }

        private void ManagePet()
        {
            throw new NotImplementedException();
        }

        private void DeletePet()
        {
            throw new NotImplementedException();
        }

        private void AddPet()
        {
            throw new NotImplementedException();
        }

        private void listOfPets()
        {
            throw new NotImplementedException();
        }

        private int showMenu(string[] menuItems)
        {
            WriteLine("Select what you want to do\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6)
            {
                WriteLine("Please select a number between 1-5");
            }

            return selection;
        }



        private void WriteLine(string txt)
        {
            Console.WriteLine(txt);
        }

    }
}