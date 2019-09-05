using System.Collections.Generic;
using System.Linq;
using DomainService.DomainService;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        public Pet CreatePet(Pet createdPet)
        {
            createdPet.Id = FakeDB.Id++;
            FakeDB.pets.Add(createdPet);
            return createdPet;
        }

        public Pet DeletePet(int id)
        {
            var petFound = GetPetById(id);
            if (petFound == null)
            {
                return null;
            }

            FakeDB.pets.Remove(petFound);
            return petFound;
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            var petFromDB = GetPetById(updatedPet.Id);
            if (petFromDB == null)
            {
                return null;
            }

            petFromDB.Name = updatedPet.Name;
            petFromDB.Price = updatedPet.Price;
            petFromDB.SoldDate = updatedPet.SoldDate;
            return petFromDB;

        }

        public IEnumerable<Pet> GetAllPets()
        {
            return FakeDB.pets;
        }

        public Pet GetPetById(int id)
        {
            return FakeDB.pets.Select(p => new Pet()
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                BirthDate = p.BirthDate,
                Color = p.Color,
                PreviousOwner = p.PreviousOwner,
                Price = p.Price
            }).
                FirstOrDefault(p => p.Id == id);
        }
    }
}