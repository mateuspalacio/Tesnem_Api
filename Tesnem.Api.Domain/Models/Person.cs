using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesnem.Api.Domain.Models
{
    public class Person
    {
        [Key]
        public string Id { get
            {
                return Registration;
            } set {
                Registration = DateTime.Now.Date.ToString() + DateTime.Now.Millisecond + new Random().Next(1000000, 9999999) + DateTime.Now.AddMilliseconds(new Random().Next(100));
            } }
        public string Name { get; set; }
        public PersonalData Data { get; set; }

        private string Registration;
    }
}
