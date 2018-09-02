using chama.domain.Entities;
using chama.domain.Interfaces;

namespace chama.domain.Services
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        public CourseService(ChamaContext chamaContext) : base(chamaContext)
        {
        }
    }
}