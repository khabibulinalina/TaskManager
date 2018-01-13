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
                User = task.User.Convert()
            };
        }
        public static User Convert(this UserDTO user)
        {
            return new User
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Position = (Positions)((int)user.Position),
                                
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
