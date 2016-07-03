using System;
using System.Linq;
using System.Net;
using AspnetCoreEF7Example.Models;
using AspnetCoreEF7Example.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreEF7Example.Controllers
{
    [Route("api/[controller]")]
    public class MyModelController : Controller
    {
        private readonly IExampleRepository _exampleRepository;

        public MyModelController(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        // GET: api/mymodel
        [HttpGet("", Name = "GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_exampleRepository.GetAll().Select(x => Mapper.Map<MyModelViewModel>(x)));
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingle")]
        public IActionResult Get(int id)
        {
            try
            {
                MyModel myModel = _exampleRepository.GetSingle(id);

                if (myModel == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<MyModelViewModel>(myModel));
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]MyModelViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MyModel item = Mapper.Map<MyModel>(viewModel);

                _exampleRepository.Add(item);
                int save = _exampleRepository.Save();

                if (save > 0)
                {
                    return CreatedAtRoute("GetSingle", new { controller = "MyModel", id = item.Id }, item);
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MyModelViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MyModel singleById = _exampleRepository.GetSingle(id);

                if (singleById == null)
                {
                    return NotFound();
                }

                singleById.Name = viewModel.Name;

                _exampleRepository.Update(singleById);
                int save = _exampleRepository.Save();

                if (save > 0)
                {
                    return Ok(Mapper.Map<MyModelViewModel>(singleById));
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                MyModel singleById = _exampleRepository.GetSingle(id);

                if (singleById == null)
                {
                    return NotFound();
                }

                _exampleRepository.Delete(singleById);
                int save = _exampleRepository.Save();

                if (save > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
