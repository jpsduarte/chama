using chama.domain.Entities;
using chama.domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chama.domain.Interfaces
{
    public interface ICourseService : IServiceBase<Course>
    {
        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course> GetByIDAsync(int id);

        void SignUp(int courseID, int studentID);
    }
}