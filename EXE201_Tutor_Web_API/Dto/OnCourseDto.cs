using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class OnCourseDto : OnCourse
    {
        public List<OnCourseDetail>? OnCourseDetails { get; set; }

    }
}
