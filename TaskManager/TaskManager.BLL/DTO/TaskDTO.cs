using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
             User = new UserDTO(task.User);
        }
        public TaskDTO()
        {

        }

        [Required (ErrorMessage = "Не указано название")]
        public String Title { get; set; }

        public String Descriprion { get; set; }
        public UserDTO User { get; set; }
        public PriorityDTO Priority { get; set; }
    }
}
