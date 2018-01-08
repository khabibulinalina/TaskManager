using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.Helpers
{
   public static class TaskExtensions
    {
        public static Task Convert( this TaskDTO task)
        {
            return new Task
            {
                Title = task.Title,
                Descriprion = task.Descriprion,
                Priority = (Priority)((int)task.Priority),
                Employee = task.Employee.Convert()
            };
        }
        public static Employee Convert(this EmployeeDTO employee)
        {
            return new Employee
            {
                Name = employee.Name,
                DateOfBirthday = employee.DateOfBirthday,
                Mail = employee.Mail,
                Position = (Positions)((int)employee.Position)
            };
        }
    }
}
