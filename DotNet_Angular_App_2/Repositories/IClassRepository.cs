using DotNet_Angular_App_2.Models;

namespace DotNet_Angular_App_2.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllStudentAsync();

        Task<Class?> GetStudentById(int id);
        Task AddAsync(Class student);
        Task UpdateAsync( Class student);
        Task DeleteAsync(int id);
    }
}
