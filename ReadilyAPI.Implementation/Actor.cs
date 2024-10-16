﻿using ReadilyAPI.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation
{
    public class Actor : IApplicationActor
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }

    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 25;

        public string Username => "unauthorized";

        public string Email => "/";

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";

        //public IEnumerable<int> AllowedUseCases => new List<int> { 6, 17, 23, 29, 34, 35, 49, 50, 56, 57, 67 };

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(0, 100);
    }
}
