﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class Student : Person
    {
        [Required]
        public List<Course> CoursesCurrent { get; set; }
        [NotMapped]
        public List<Course> CoursesCompleted { get; set; }
        public List<Class> Classes { get; set; }
        public DateOnly ConclusionDate { get; set; }
        public ProgramMajor ProgramMajor { get; set; }
    }
}
