﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Auth
{
    public class User : IdentityUser
    {
        [JsonIgnore]
        [ForeignKey("Person_Id")]
        public Person Person { get; set; }
        public Guid Person_Id { get; set; }
    }
}
