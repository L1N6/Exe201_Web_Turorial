﻿using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Database;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.CourseraRepositoryPlace;
using Microsoft.EntityFrameworkCore;

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

       

        //public List<Coursera> SearchCoursera(Exe201_Tutor_Context context, string name)
        //{
        //    return context.Coursera.Include(c => c.Teacher).Where(c => c.Name != null && c.Name.Contains(name)).ToList();    
        //}

    }
}
