﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoApp.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OrderColor> Colors { get; set; }
    }
}