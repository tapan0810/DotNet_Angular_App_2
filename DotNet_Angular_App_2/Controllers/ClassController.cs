using DotNet_Angular_App_2.Models;
using DotNet_Angular_App_2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Angular_App_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _repository;

        public ClassController(IClassRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _repository.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _repository.GetStudentById(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Class student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.AddAsync(student);

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id = student.Id },
                student);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Class student)
        {
            if (id != student.Id)
                return BadRequest("Id mismatch.");

            var existing = await _repository.GetStudentById(id);

            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(student);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existing = await _repository.GetStudentById(id);

            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}