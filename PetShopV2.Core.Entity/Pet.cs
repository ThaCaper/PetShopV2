using System;
using System.Collections.Generic;

namespace PetShopV2.Core.Entity
{
    public class Pet
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime SoldDate { get; set; }
            public string Color { get; set; }
            public List<Owner> PreviousOwner { get; set; }
            public double Price { get; set; }


    }
}