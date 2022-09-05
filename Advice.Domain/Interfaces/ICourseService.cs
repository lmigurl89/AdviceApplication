using Advice.Data.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Advice.Domain.Interfaces
{
    public interface ICourseService : IBaseService<Course>
    {
    }
}