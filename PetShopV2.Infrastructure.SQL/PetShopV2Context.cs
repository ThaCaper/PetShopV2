using Microsoft.EntityFrameworkCore;
using PetShopV2.Core.Entity;

namespace PetShopV2.Infrastructure.SQL
{
    public class PetShopV2Context : DbContext
    {
        public PetShopV2Context(DbContextOptions<PetShopV2Context> opt) : base(opt)
        {

        }
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

    }
}