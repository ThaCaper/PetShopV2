using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainService;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.Data.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner CreateOwner(Owner ownerToCreate)
        {
            ownerToCreate.Id = FakeDB.OwnerId++;
            FakeDB.AllOwners.ToList().Add(ownerToCreate);
            return ownerToCreate;
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FakeDB.AllOwners;
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var ownerFromDB = GetOwnerById(ownerToUpdate.Id);
            if (ownerFromDB == null)
            {
                return null;
            }

            ownerFromDB.FirstName = ownerToUpdate.FirstName;
            ownerFromDB.LastName = ownerToUpdate.LastName;
            ownerFromDB.Address = ownerToUpdate.Address;
            ownerFromDB.PhoneNumber = ownerToUpdate.PhoneNumber;
            return ownerFromDB;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerFoundById = GetOwnerById(id);
            if (ownerFoundById == null)
            {
                return null;
            }

            FakeDB.AllOwners.ToList().Remove(ownerFoundById);
            return ownerFoundById;
        }

        public Owner GetOwnerById(int id)
        {
            FakeDB.

            foreach (var owner in FakeDB.AllOwners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }
    }
}