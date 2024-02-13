using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class OnCourseDetailDto : OnCourseDetail
    {
        public List<OnMoocDto>? OnMoocDtos { get; set; }

    }
}
