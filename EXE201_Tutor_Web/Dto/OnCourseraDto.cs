using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class OnCourseraDto : OnCoursera
    {
        public List<OnCourseraDetail>? OnCourseDetails { get; set; }

    }
}
