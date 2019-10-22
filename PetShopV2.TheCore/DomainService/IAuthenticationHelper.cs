using PetShopV2.Core.Entity;

namespace PetShopV2.Core.DomainService
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(Owner owner);
    }
}