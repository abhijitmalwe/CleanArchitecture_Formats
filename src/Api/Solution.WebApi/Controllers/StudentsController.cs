using Microsoft.AspNetCore.Mvc;
using PdsCleanAppCore.Platform.Example.Commands.DTOs;
using PdsCleanAppCore.Platform.Example.Commands.PostStudent;
using PdsCleanAppCore.Platform.Example.Commands.PutStudent;
using PdsCleanAppCore.Platform.Example.Queries.DTOs;
using PdsCleanAppCore.Platform.Example.Queries.GetStudentById;
using PdsCleanAppCore.Platform.Example.Queries.GetStudents;

namespace PdsCleanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : AppControllerBase
    {
        // GET: api/<ExampleController>
        [HttpGet]
        public async Task<ActionResult<StudentListDto>> GetStudents()
        {
            try
            {
                var response = await Mediator!.Send(new GetStudentsQuery());
                if (response is not null)
                {
                    return Ok(response);
                }
                else
                {
                    return NoContent();
                }
            }
            catch
            {
                // log exception here
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError));
            }
        }

        // GET api/<ExampleController>/5
        [HttpGet("{id}")]
        public async Task<StudentDto> GetStudent(int id)
        {
            return await Mediator!.Send(new GetStudentByIdQuery { Id = id });           
        }

        // POST api/<ExampleController>
        [HttpPost]
        public async Task<ActionResult<int>> PostStudent([FromBody] PostStudentCmd postStudentCmd)
        {
            var response = await Mediator!.Send(postStudentCmd);
            try
            {
                if (response > 0)
                {
                    return CreatedAtAction(nameof(GetStudent), new { id = response }, response);
                }
            }
            catch (Exception)
            {
                // log exception here
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError));
            }

            return BadRequest();
        }

        // PUT api/<ExampleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PutStudentCmd putStudentCmd)
        {
            if (id != putStudentCmd.Id)
            {
                return BadRequest();
            }
            try
            {
                await Mediator!.Send(putStudentCmd);
            }
            catch (Exception)
            {
                // log exception here
                return BadRequest(StatusCode(StatusCodes.Status500InternalServerError));
            }

            return NoContent();
        }

        // DELETE api/<ExampleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
