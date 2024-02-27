using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class OnCourseraDetailDto : OnCourseraDetail
    {
        public List<OnMoocDto>? OnMoocDtos { get; set; }

    }
}
