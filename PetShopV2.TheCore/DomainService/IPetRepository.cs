using System.Collections.Generic;
using PetShopV2.Core.Entity;

namespace DomainService.DomainService
{
    public interface IPetRepository
    {
        //Creates a pet
        Pet CreatePet(Pet createdPet);

        //Deletes a pet
        Pet DeletePet(int id);

        //Changes pet values
        Pet UpdatePet(Pet updatedPet);

        //A list with all pets
        IEnumerable<Pet> GetAllPets();

        //Find pet by id
        Pet GetPetById(int id);

        Pet GetPetByIdIncludeOwners(int id);
    }
}