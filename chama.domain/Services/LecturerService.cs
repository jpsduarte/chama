using chama.domain.Entities;
using chama.domain.Interfaces;

namespace chama.domain.Services
{
    public class LecturerService : ServiceBase<Lecturer>, ILecturerService
    {
        public LecturerService(ChamaContext chamaContext) : base(chamaContext)
        {
        }
    }
}