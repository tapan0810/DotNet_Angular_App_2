using DotNet_Angular_App_2.Data;
using DotNet_Angular_App_2.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Angular_App_2.Repositories
{
    public class ClassRepository(ClassDbContext _context) : IClassRepository
    {
        public async Task AddAsync(Class student)
        {

            await _context.Classes.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
           var stud = _context.Classes.FirstOrDefault(c => c.Id == id);
            if (stud != null)
            {
                _context.Classes.Remove(stud);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Class>> GetAllStudentAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class?> GetStudentById(int id)
        {
           return await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync( Class student)
        {
            _context.Classes.Update(student);
                        return _context.SaveChangesAsync();
        }
    }
}
