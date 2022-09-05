using Advice.Data.DbContext;
using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.IUnitOfWork.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AdviceDbContext context) : base(context)
        {
        }

        public async Task<Student?> FindByName(string name)
        {
           return await _context.Students.FirstOrDefaultAsync(student=> student.Name == name);   
        }
    }
}
