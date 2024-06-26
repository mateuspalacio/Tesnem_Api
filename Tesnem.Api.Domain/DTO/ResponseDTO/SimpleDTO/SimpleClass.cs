﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models.Enums;

namespace Tesnem.Api.Domain.DTO.ResponseDTO.SimpleDTO
{
    public class SimpleClass
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Days Days { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid CourseId { get; set; }
        public List<SimpleTest> Tests { get; set; }
        public List<SimpleStudent> Students { get; set; }
    }
}
