﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Final_Project.SearchTeacherViewModel;

namespace Final_Project
{
    class TeacherContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Teacher_EFCore;MultipleActiveResultSets=true;Trusted_connection=true;Integrated Security=true");
        }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
