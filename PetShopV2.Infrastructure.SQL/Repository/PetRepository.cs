using System.Collections.Generic;
using System.Linq;
using DomainService.DomainService;
using Microsoft.EntityFrameworkCore;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.SQL.Repository
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopV2Context _context;

        public PetRepository(PetShopV2Context context)
        {
            _context = context;
        }
        public Pet CreatePet(Pet createdPet)
        {
            _context.Attach(createdPet).State = EntityState.Added;
            _context.SaveChanges();
            return createdPet;
        }

        public Pet DeletePet(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pets;
        }

        public Pet GetPetById(int id)
        {
            return _context.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet GetPetByIdIncludeOwners(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}