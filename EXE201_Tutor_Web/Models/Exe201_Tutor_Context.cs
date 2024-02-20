
using EXE201_Tutor_Web_API.Entites;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web_API.Database
{
    public class Exe201_Tutor_Context : DbContext
    {
        public Exe201_Tutor_Context(DbContextOptions options) : base(options) { }
        public DbSet<Coursera> Coursera { get; set; }
        public DbSet<CourseraDetail> CourseraDetail { get; set; }
        public DbSet<Mooc> Mooc { get; set; }
        public DbSet<MoocDetail> MoocDetail { get; set; }
        public DbSet<OnCourseraDetail> OnCourseDetail { get; set; }
        public DbSet<OnMooc> OnMooc { get; set; }
        public DbSet<OnMoocDetail> OnMoocDetail { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<Coursera>().HasKey(c => c.CourseraId); // Primary key for Coursera
            modelBuilder.Entity<CourseraDetail>().HasKey(cd => cd.CourseraDetailId); // Primary key for CourseraDetail
            modelBuilder.Entity<Mooc>().HasKey(m => m.MoocId); // Primary key for Mooc
            modelBuilder.Entity<MoocDetail>().HasKey(md => md.MoocDetailId); // Primary key for MoocDetail
            modelBuilder.Entity<OnCoursera>().HasKey(oc => oc.OnCourseId); // Primary key for OnCourse
            modelBuilder.Entity<OnCourseraDetail>().HasKey(ocd => ocd.OnCourseDetailId); // Primary key for OnCourseDetail
            modelBuilder.Entity<OnMooc>().HasKey(om => om.OnMoocId); // Primary key for OnMooc
            modelBuilder.Entity<OnMoocDetail>().HasKey(omd => omd.OnMoocDetailId); // Primary key for OnMoocDetail
            modelBuilder.Entity<Student>().HasKey(u => u.StudentId); // Primary key for Student
            modelBuilder.Entity<Teacher>().HasKey(u => u.TeacherId); // Primary key for Teacher

            // Define relationships

            // One-to-many relationship between Student and OnCourse
            modelBuilder.Entity<Student>()
                .HasMany(c => c.OnCourseras)
                .WithOne(oc => oc.Student)
                .HasForeignKey(oc => oc.StudentId);

            // One-to-many relationship between Teacher and Course
            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Courseras)
                .WithOne(oc => oc.Teacher)
                .HasForeignKey(oc => oc.TeacherId);

            // One-to-many relationship between Coursera and OnCourse
            modelBuilder.Entity<Coursera>()
                .HasMany(c => c.OnCourses)
                .WithOne(oc => oc.Coursera)
                .HasForeignKey(oc => oc.CourseraId);

            // One-to-many relationship between Coursera and CourseraDetail
            modelBuilder.Entity<Coursera>()
                .HasMany(c => c.CourseraDetails)
                .WithOne(cd => cd.Coursera)
                .HasForeignKey(cd => cd.CourseraId);

            // One-to-many relationship between CourseraDetail and OnCourseDetail
            modelBuilder.Entity<CourseraDetail>()
                .HasMany(cd => cd.OnCourseDetails)
                .WithOne(ocd => ocd.CourseraDetail)
                .HasForeignKey(ocd => ocd.CourseraDetailId);

            // One-to-many relationship between CourseraDetail and Mooc
            modelBuilder.Entity<CourseraDetail>()
                .HasMany(cd => cd.Moocs)
                .WithOne(m => m.CourseraDetail)
                .HasForeignKey(m => m.CourseraDetailId);

            // One-to-many relationship between Mooc and MoocDetail
            modelBuilder.Entity<Mooc>()
                .HasMany(m => m.MoocDetails)
                .WithOne(md => md.Mooc)
                .HasForeignKey(md => md.MoocId);

            // One-to-many relationship between Mooc and OnMooc
            modelBuilder.Entity<Mooc>()
                .HasMany(m => m.OnMoocs)
                .WithOne(om => om.Mooc)
                .HasForeignKey(om => om.MoocId);

            // One-to-many relationship between MoocDetail and OnMoocDetail
            modelBuilder.Entity<MoocDetail>()
                .HasMany(md => md.OnMoocDetails)
                .WithOne(omd => omd.MoocDetail)
                .HasForeignKey(omd => omd.MoocDetailId);

            // One-to-many relationship between OnCourse and OnCourseDetail
            modelBuilder.Entity<OnCoursera>()
                .HasMany(oc => oc.OnCourseDetails)
                .WithOne(ocd => ocd.OnCourse)
                .HasForeignKey(ocd => ocd.OnCourseId);

            // One-to-many relationship between OnCourseDetail and OnMooc
            modelBuilder.Entity<OnCourseraDetail>()
                .HasMany(ocd => ocd.OnMoocs)
                .WithOne(om => om.OnCourseDetail)
                .HasForeignKey(om => om.OnCourseDetailId);

            // One-to-many relationship between OnMooc and OnMoocDetail
            modelBuilder.Entity<OnMooc>()
                .HasMany(om => om.OnMoocDetails)
                .WithOne(omd => omd.OnMooc)
                .HasForeignKey(omd => omd.OnMoocId);
        }

    }

}
