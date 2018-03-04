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
                Id = task.Id,
                Title = task.Title,
                Descriprion = task.Descriprion,
                Priority = (Priority)((int)task.Priority),
                UserId = task.UserID
            };
        }
        public static TaskDTO Convert(this Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Descriprion = task.Descriprion,
                Priority = (PriorityDTO)((int)task.Priority),
                UserID = task.UserId
            };
        }
        public static User Convert(this UserDTO user)
        {
            return new User
            {   Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Position = (Positions)((int)user.Position)
            };
        }
        public static UserDTO Convert(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Position = (PositionsDTO)((int)user.Position),

            };
        }
        public static User Convert(this RegisterDTO user)
        {
            return new User
            {
                UserName = user.Name,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Position = user.Position,
                
            };
        }

    }
}
