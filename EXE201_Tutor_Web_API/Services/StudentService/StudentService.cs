using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.OnMoocRepositoryPlace;
using EXE201_Tutor_Web_API.Repositories.StudentRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.StudentService
{
    public class StudentService : BaseService<Student, StudentDto, int>
    {
        private readonly IRepository<Student, int> _repository;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student, int> studentRepository, IMapper mapper, StudentRepository repository) : base(studentRepository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
