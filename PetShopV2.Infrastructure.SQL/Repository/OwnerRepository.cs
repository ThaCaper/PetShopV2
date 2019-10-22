using System.Collections.Generic;
using System.Linq;
using DomainService.DomainService;
using Microsoft.EntityFrameworkCore;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.SQL.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopV2Context _context;

        public OwnerRepository(PetShopV2Context context)
        {
            _context = context;
        }
        public Owner CreateOwner(Owner ownerToCreate)
        {
            _context.Attach(ownerToCreate).State = EntityState.Added;
            _context.SaveChanges();
            return ownerToCreate;
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return _context.Owners;
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Owner DeleteOwner(int id)
        {
            throw new System.NotImplementedException();
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner GetOwnerByIdIncludePets(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfUsernameAlreadyExists()
        {
            return true;
        }
    }
}