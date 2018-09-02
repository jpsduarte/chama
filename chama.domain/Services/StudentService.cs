using chama.domain.Entities;
using chama.domain.Interfaces;

namespace chama.domain.Services
{
public class StudentService : ServiceBase<Student>, IStudentService
    {
        public StudentService(ChamaContext chamaContext) : base(chamaContext)
        {
        }
    }
}