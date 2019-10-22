using System;
using System.Collections.Generic;
using PetShopV2.Core.Entity;

namespace PetShopV2.Core.AppService
{
    public interface IPetService
    {
        
        Pet NewPet(string name, string type, DateTime birthday, string color, Double price, List<Owner> previousOwner);

        Pet CreatePet(Pet createdPet);

        List<Pet> GetAllPets();

        Pet UpdatePet(Pet updatePet);

        List<Pet> SearchPetByType(string type);

        Pet GetPetById(int id);

        Pet GetPetByIdIncludeOwner(int id);

        Pet DeletePet(int id);

        List<Pet> Cheapest5Pets();
    }
}