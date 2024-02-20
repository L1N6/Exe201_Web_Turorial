using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class OnMoocDto : OnMooc
    {
        public List<OnMoocDetailDto>? OnMoocDetailDtos { get; set; }

    }
}
