using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IService<Person> PersonService { get; }

        private IMapper Mapper { get; }

        public PersonsController(IService<Person> personService, IMapper mapper)
        {
            PersonService = personService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await PersonService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await PersonService.GetByIdAsync(id);
            return Ok(Mapper.Map<PersonDto>(person));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var newPerson = await PersonService.AddAsync(Mapper.Map<Person>(personDto));
            return Created(string.Empty, Mapper.Map<PersonDto>(newPerson));
        }

        [HttpPut]
        public IActionResult Update(PersonDto personDto)
        {
            PersonService.Update(Mapper.Map<Person>(personDto));
            return NoContent();
        }

        [HttpPut("async")]
        public async Task<IActionResult> UpdateAsync(PersonDto personDto)
        {
            var newPerson = await PersonService.UpdateAsync(Mapper.Map<Person>(personDto));
            return Created(string.Empty, Mapper.Map<PersonDto>(newPerson));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var person = PersonService.GetByIdAsync(id).Result;
            PersonService.Remove(person);
            return NoContent();
        }
    }
}