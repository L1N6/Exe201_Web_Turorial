using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class CourseraDto : Coursera
    {
        public List<CourseraDetailDto>? CourseraDetailDtos { get; set; }     
    }
}
