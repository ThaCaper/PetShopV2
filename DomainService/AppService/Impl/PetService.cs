using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DomainService.DomainService;
using PetShopV2.Core.AppService;
using PetShopV2.Core.Entity;

namespace DomainService.Appservice.Impl
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet newPet(string name, string type, DateTime birthday, string color, double price, string previousOwner)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                BirthDate = birthday,
                Color = color,
                Price = price,
                PreviousOwner = previousOwner
            };
            return pet;
        }

        public Pet createPet(Pet createdPet)
        {
            return _petRepository.CreatePet(createdPet);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets().ToList();
        }

        public Pet UpdatePet(Pet updatePet)
        {
            var pet = GetPetById(updatePet.Id);
            pet.Name = updatePet.Name;
            pet.Price = updatePet.Price;
            pet.SoldDate = updatePet.SoldDate;
            return pet;
        }

        public List<Pet> SearchPetByType(string type)
        {
            var list = _petRepository.GetAllPets();
            var queryContinued = list.Where(pet => pet.Type.Equals(type));
            queryContinued.OrderBy(pets => pets.Type);
            return queryContinued.ToList();
        }

        public Pet GetPetById(int id)
        {
            return _petRepository.GetPetById(id);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }

        public List<Pet> Cheapest5Pets()
        {
            throw new NotImplementedException();
        }
    }
}