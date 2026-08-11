using DotNet_Angular_App_2.Data;
using DotNet_Angular_App_2.Models;
using Microsoft.EntityFrameworkCore;
namespace DotNet_Angular_App_2.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ClassDbContext _context;

        public ClassRepository(ClassDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllStudentAsync()
        {
            return await _context.Classes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Class?> GetStudentById(int id)
        {
            return await _context.Classes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Class student)
        {
            // Ensure SQL Server generates the identity value
            student.Id = 0;

            await _context.Classes.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Class student)
        {
            var existingStudent = await _context.Classes.FindAsync(student.Id);

            if (existingStudent == null)
                return;

            existingStudent.Name = student.Name;
            existingStudent.Grade = student.Grade;
            existingStudent.IsPassed = student.IsPassed;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Classes.FindAsync(id);

            if (student == null)
                return;

            _context.Classes.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}