using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class Enrollment
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public string EnrollmentNumber { get; set; } = DateTime.Now.Date.ToString() + DateTime.Now.Millisecond + new Random().Next(1000000, 9999999) + DateTime.Now.AddMilliseconds(new Random().Next(100));

    }
}