using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class MoocDto : Mooc
    {
        public List<MoocDetailDto>? MoocDetailDtos { get; set; }

    }
}
