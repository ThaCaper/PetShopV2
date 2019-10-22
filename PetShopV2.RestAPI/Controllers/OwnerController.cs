using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopV2.Core.AppService;
using PetShopV2.Core.Entity;

namespace PetShopV2.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        //GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/owners/5 --Read by Id
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must never be less than 1");
            }

            return _ownerService.GetOwnerById(id);
        }

        // POST api/pets -- CREATE
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.CreateOwner(owner));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter ID and Owner ID must be the same");
            }

            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var petToDelete = _ownerService.DeleteOwner(id);
            if (petToDelete == null)
            {
                return StatusCode(404, "Did not find the Owner" + id);
            }

            return Ok("Owner is deleted");
        }
    }
}