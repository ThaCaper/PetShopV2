using System.Collections.Generic;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.Data
{
    public class FakeDB
    {
        public static int Id = 1;
        public static readonly List<Pet> pets = new List<Pet>();
    }
}