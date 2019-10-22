﻿using System.Collections.Generic;

namespace PetShopV2.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PassW { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Pet> OwnPets { get; set; }
    }
}