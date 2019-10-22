using System.Collections.Generic;
using PetShopV2.Core.Entity;

namespace DomainService.DomainService
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner ownerToCreate);

        IEnumerable<Owner> GetAllOwners();

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner DeleteOwner(int id);

        Owner GetOwnerById(int id);

        Owner GetOwnerByIdIncludePets(int id);


    }
}