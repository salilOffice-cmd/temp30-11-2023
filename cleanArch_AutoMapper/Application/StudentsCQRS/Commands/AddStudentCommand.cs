﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.StudentDTOs;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.StudentsCQRS.Commands
{

    public class AddStudentCommand : IRequest<Student>
    {
        public AddStudentDTO addStudentDTO { get; set; }
    }


    public class AddStudentCommand_Handler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IApplicationDBContext context;
        private readonly IMapper mapper;
        public AddStudentCommand_Handler(IApplicationDBContext _applicationDBContext, IMapper _mapper)
        {
            context = _applicationDBContext;
            mapper = _mapper;   
        }

        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var addStudentDTO = request.addStudentDTO;


            // Automapper changes -->
            //Student newStudent = new Student
            //{
            //    StudentName = addStudentDTO.StudentName,
            //    StudentAge = addStudentDTO.StudentAge,
            //    CourseID = addStudentDTO.CourseID,
            //    CreatedDate = DateTime.Now,
            //    CreatedBy = "Admin",
            //    IsActive = true
            //};

            var newStudent = mapper.Map<Student>(addStudentDTO);
            newStudent.CreatedDate = DateTime.Now;
            newStudent.CreatedBy = "Admin";
            newStudent.IsActive = true;



            context.Students.Add(newStudent);
            await context.SaveChangesAsync(cancellationToken);

            return newStudent;

        }
    }

}
