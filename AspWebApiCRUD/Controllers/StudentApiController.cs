using AspWebApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   // ✅ Required for EF Queries & ToListAsync()

namespace AspWebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly AppDbContext _context;  // ✅ Correct type

        public StudentApiController(AppDbContext context)
        {
            _context = context; // ✅ now stored in correct context variable
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync(); // ✅ Works with EF Core
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();

            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await _context.Students.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id,Student std)
        {
          if(id != std.Id)
          {
            return BadRequest();
            }
          _context.Entry(std).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await _context.Students.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
