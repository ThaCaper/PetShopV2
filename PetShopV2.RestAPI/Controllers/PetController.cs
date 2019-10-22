using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        //GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pets/5 --Read by Id
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must never be less than 1");
            }

            return _petService.GetPetById(id);
        }

        // POST api/pets -- CREATE
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] string name, string type, DateTime birthDate, string color, double price)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Must have a name");
            }

            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Must have a type");
            }

            if (birthDate > DateTime.Now)
            {
                return BadRequest("Can't be born in the past");
            }

            if (string.IsNullOrEmpty(color))
            {
                return BadRequest("Must have a color");
            }

            //return StatusCode(500, "Something went wrong.");
            return _petService.CreatePet(new Pet()
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                Color = color,
                Price = price
            });
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter ID and pet ID must be the same");
            }

            return Ok(_petService.UpdatePet(pet));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var petToDelete = _petService.DeletePet(id);
            if (petToDelete == null)
            {
                return StatusCode(404, "Did not find the pet" + id);
            }

            return Ok("Pet is deleted");
        }
    }
}