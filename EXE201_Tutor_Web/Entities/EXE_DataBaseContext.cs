
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web.Entities
{
    public class EXE_DataBaseContext : DbContext
    {
        public EXE_DataBaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Coursera> Courseras { get; set; }
        public DbSet<OnCoursera> OnCoursera { get; set; }
        public DbSet<CourseraDetail> CourseraDetails { get; set; }
        public DbSet<Mooc> Moocs { get; set; }
        public DbSet<MoocDetail> MoocDetails { get; set; }
        public DbSet<OnCourseraDetail> OnCourseDetails { get; set; }
        public DbSet<OnMooc> OnMoocs { get; set; }
        public DbSet<OnMoocDetail> OnMoocDetails { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<OrderCoursera> OrderCourseras { get; set; }


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
            modelBuilder.Entity<OrderCoursera>().HasKey(u => u.OrderCourseraId); // Primary key for Teacher
            modelBuilder.Entity<Feedback>().HasKey(u => u.FeedbackId); // Primary key for Teacher

            // Define relationships

            // One-to-many relationship between Student and Feedback
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Feedback)
                .WithOne(oc => oc.Student)
                .HasForeignKey(oc => oc.StudentId);

            // One-to-many relationship between Coursera and Feedback
            modelBuilder.Entity<Coursera>()
                .HasMany(c => c.Feedbacks)
                .WithOne(oc => oc.Coursera)
                .HasForeignKey(oc => oc.CourseraId);

            // One-to-many relationship between Coursera and OrderCoursera
            modelBuilder.Entity<Coursera>()
                .HasMany(c => c.OrderCourseras)
                .WithOne(oc => oc.Coursera)
                .HasForeignKey(oc => oc.CourseraId);

            // One-to-many relationship between Student and OrderCoursera
            modelBuilder.Entity<Student>()
                .HasMany(c => c.OrderCoursera)
                .WithOne(oc => oc.Student)
                .HasForeignKey(oc => oc.StudentId);

            // One-to-many relationship between Student and OnCourse
            modelBuilder.Entity<Student>()
                .HasMany(c => c.OnCoursera)
                .WithOne(oc => oc.Student)
                .HasForeignKey(oc => oc.StudentId);

            // One-to-many relationship between Teacher and Course
            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Courseras)
                .WithOne(oc => oc.Teacher)
                .HasForeignKey(oc => oc.TeacherId);

            // One-to-many relationship between Coursera and OnCourse
            modelBuilder.Entity<Coursera>()
                .HasMany(c => c.OnCoursera)
                .WithOne(oc => oc.Coursera)
                .HasForeignKey(oc => oc.CourseraId);

            // One-to-many relationship between Coursera and CourseraDetail
            modelBuilder.Entity<Coursera>()
                .HasMany(c => c.CourseraDetails)
                .WithOne(cd => cd.Coursera)
                .HasForeignKey(cd => cd.CourseraId);

            // One-to-many relationship between CourseraDetail and OnCourseDetail
            modelBuilder.Entity<CourseraDetail>()
                .HasMany(cd => cd.OnCourseraDetails)
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
                .WithOne(ocd => ocd.OnCoursera)
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
