﻿using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.CourseraRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.CourseraService
{
    public class CourseraService : BaseService<Coursera, CourseraDto, int>
    {
        private readonly IRepository<Coursera, int> _courseraRepository;
        private readonly IMapper _mapper;
        public CourseraService(IRepository<Coursera, int> courseraRepository, IMapper mapper, CourseraRepository repository) : base(courseraRepository, mapper)
        {
            _courseraRepository = repository;
            _mapper = mapper;
        }


    }
}
