using System.Collections.Generic;
using PetShopV2.Core.Entity;

namespace PetShopV2.Core.AppService
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner createOwner);

        List<Owner> GetAllOwners();

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner GetOwnerById(int id);

        Owner GetOwnerByIdIncludePets(int id);

        Owner DeleteOwner(int id);


    }
}