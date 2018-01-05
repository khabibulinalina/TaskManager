using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.DAL.Entities
{
    public class TaskContext : DbContext
    {

        public DbSet<Employee> Employeers { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
            
        }
    }
}
