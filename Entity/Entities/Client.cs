﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Client
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }  

        public string? Password { get; set; }


        public ICollection<ClientItemRelation>? ClientItemRelations { get; set; }
    }
}
