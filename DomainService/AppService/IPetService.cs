using System;
using System.Collections.Generic;
using System.Drawing;
using PetShopV2.Core.Entity;

namespace PetShopV2.Core.AppService
{
    public interface IPetService
    {
        
        Pet newPet(string name, string type, DateTime birthday, string color, Double price, string previousOwner);

        Pet createPet(Pet createdPet);

        List<Pet> GetAllPets();

        Pet UpdatePet(Pet updatePet);

        List<Pet> SearchPetByType(string type);

        Pet GetPetById(int id);

        Pet DeletePet(int id);

        List<Pet> Cheapest5Pets();
    }
}