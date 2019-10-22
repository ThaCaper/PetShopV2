using System;
using System.Collections.Generic;
using System.Drawing;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.Data
{
    public class FakeDB
    {
        public static int PetId;
        public static IEnumerable<Pet> AllPets;

        public static int OwnerId;
        public static IEnumerable<Owner> AllOwners;

        public static void InitData()
        {
            List<Pet> listOfPets = new List<Pet>();

            Pet dog = new Pet()
            {
                Id = 1,
                Type = "Dog",
                Name = "Mollie",
                Color = "Brown",
                Price = 1500,
                SoldDate = DateTime.Today,
                BirthDate = DateTime.Now.AddYears(2018).AddMonths(11).AddDays(11),
            };

            Pet fish = new Pet()
            {
                Id = 2,
                Type = "Fish",
                Name = "Goldie",
                Color = "Yellow",
                
                BirthDate = DateTime.Now.AddYears(2017).AddMonths(7).AddDays(23),
                Price = 500,
                SoldDate = DateTime.Today
            };

            Pet petPig = new Pet()
            {
                Id = 3,
                Type = "PetPig",
                Name = "Snuffle",
                Color = "Pinky",
                
                Price = 3000,
                SoldDate = DateTime.Today,
                BirthDate = DateTime.Now.AddYears(2019).AddMonths(2).AddDays(2),
            };

            Pet Goat = new Pet()
            {
                Id = 4,
                Type = "Goat",
                Name = "Lammie",
                Color = "Hvid",
                Price = 4000,
                SoldDate = DateTime.Today,
                BirthDate = DateTime.Now.AddYears(2016).AddMonths(6).AddDays(4),
            };

            Pet Cow = new Pet()
            {
                Id = 5,
                Type = "Cow",
                Name = "Truffle",
                Color = "Sort",
                Price = 5000,
                SoldDate = DateTime.Today,
                BirthDate = DateTime.Now.AddYears(2016).AddMonths(5).AddDays(17),
            };
            listOfPets.Add(dog);
            listOfPets.Add(fish);
            listOfPets.Add(petPig);
            listOfPets.Add(Goat);
            listOfPets.Add(Cow);
            AllPets = listOfPets;
        }
    }
}