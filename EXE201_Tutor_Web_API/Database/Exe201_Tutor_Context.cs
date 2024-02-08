using EXE201_Tutor_Web_API.Entites;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web_API.Database
{
    public class Exe201_Tutor_Context: DbContext
    {
        public Exe201_Tutor_Context(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
