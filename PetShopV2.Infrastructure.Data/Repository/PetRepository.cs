using System.Collections.Generic;
using System.Linq;
using DomainService.DomainService;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.Data.Repository
{
    public class PetRepository: IPetRepository
    {
        public Pet CreatePet(Pet createdPet)
        {
            createdPet.Id = FakeDB.PetId++;
            FakeDB.AllPets.ToList().Add(createdPet);
            return createdPet;
        }

        public Pet DeletePet(int id)
        {
            var petFound = GetPetById(id);
            if (petFound == null)
            {
                return null;
            }

            FakeDB.AllPets.ToList().Remove(petFound);
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
            return FakeDB.AllPets;
        }

        public Pet GetPetById(int id)
        {
            foreach (var pet in FakeDB.AllPets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }
    }
}