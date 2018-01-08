using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.DTO
{
   
    public class TaskDTO:BaseEntityDTO
    {
        public TaskDTO(Task task)
       {
        Descriprion = task.Descriprion;
        Title = task.Title;
        Priority = (PriorityDTO)((int) task.Priority);
        Employee = new EmployeeDTO(task.Employee);
        }
        public TaskDTO()
        {

        }

        public String Title { get; set; }
        public String Descriprion { get; set; }
        public EmployeeDTO Employee { get; set; }
        public PriorityDTO Priority { get; set; }
    }
}
