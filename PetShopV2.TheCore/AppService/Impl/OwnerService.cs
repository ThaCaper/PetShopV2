using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DomainService.DomainService;
using PetShopV2.Core.Entity;

namespace PetShopV2.Core.AppService.Impl
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetRepository _petRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }


        public Owner CreateOwner(Owner createOwner)
        {
            if (string.IsNullOrEmpty(createOwner.FirstName))
            {
                throw new InvalidDataException("Insert first name!");
            }

            if (string.IsNullOrEmpty(createOwner.LastName))
            {
                throw new InvalidDataException("Insert last name!");
            }

            if (string.IsNullOrEmpty(createOwner.Address))
            {
                throw new InvalidDataException("Insert a valid address!");
            }

            if (createOwner.PhoneNumber.Length < 8)
            {
                throw new InvalidDataException("Must have 8 digits. Ex: 12345678");
            }

            if (string.IsNullOrEmpty(createOwner.Username))
            {
                throw new InvalidDataException("Write a damn username for login");
            }

            if (string.IsNullOrEmpty(createOwner.PassW) && createOwner.PassW.Length <= 10)
            {
                throw new InvalidDataException("Must have 10 or more elements");
            }

            return _ownerRepository.CreateOwner(createOwner);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners().ToList();
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var owner = GetOwnerById(ownerToUpdate.Id);
            owner.FirstName = ownerToUpdate.FirstName;
            owner.LastName = ownerToUpdate.LastName;
            owner.Address = ownerToUpdate.Address;
            owner.PhoneNumber = ownerToUpdate.PhoneNumber;
            return owner;
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public Owner GetOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            owner.OwnPets = _petRepository.GetAllPets().Where(pets => 
                pets.PreviousOwner != null && pets.PreviousOwner.Id == owner.Id).ToList();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
    }
}