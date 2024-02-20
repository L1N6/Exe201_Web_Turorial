using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Database;
using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Repositories.StudentRepositoryPlace
{
    public class StudentRepository : Repository<Student, int>
    {
        public StudentRepository(Exe201_Tutor_Context context) : base(context)
        {
        }
    }
}
