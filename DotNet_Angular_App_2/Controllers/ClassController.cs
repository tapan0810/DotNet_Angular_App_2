using DotNet_Angular_App_2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Angular_App_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(IClassRepository _classRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _classRepository.GetAllStudentAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _classRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Models.Class student)
        {
            await _classRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Models.Class student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            await _classRepository.UpdateAsync(student);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _classRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
