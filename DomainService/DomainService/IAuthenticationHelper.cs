using PetShopV2.Core.Entity;

namespace DomainService.DomainService
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(Owner owner);
    }
}