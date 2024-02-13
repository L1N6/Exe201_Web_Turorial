using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Database;
using EXE201_Tutor_Web_API.Entites;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web_API.Repositories.UserRepositoryPlace
{
    public class UserRepository : Repository<User, int>
    {
        public UserRepository(Exe201_Tutor_Context context) : base(context)
        {
        }

    }
}
