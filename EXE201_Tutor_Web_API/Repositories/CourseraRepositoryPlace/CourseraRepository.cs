using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Database;
using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Repositories.CourseraRepositoryPlace
{
    public class CourseraRepository : Repository<Coursera, int>
    {
        //public CourseraRepository(Exe201_Tutor_Context context) : base(context)
        //{
        //    _context = context;
        //}
        public CourseraRepository(Exe201_Tutor_Context context) : base(context)
        {
        }
    }
}
