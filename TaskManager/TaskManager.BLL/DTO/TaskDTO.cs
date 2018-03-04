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
             Id = task.Id;
             Descriprion = task.Descriprion;
             Title = task.Title;
             Priority = (PriorityDTO)((int) task.Priority);
             UserID = task.UserId;
        }
        public TaskDTO()
        {

        }

        [Required (ErrorMessage = "Не указано название")]
        public String Title { get; set; }

        public String Descriprion { get; set; }
        public String UserID { get; set; }
        public PriorityDTO Priority { get; set; }
    }
}
