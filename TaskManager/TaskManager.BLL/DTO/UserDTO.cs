using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.DTO
{
   public class UserDTO: IdentityUser
    {
        public UserDTO(User user)
        {
            UserName = user.UserName;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            Position = (PositionsDTO)((int)user.Position);
           
        }
        public UserDTO()
        {

        }

        public PositionsDTO Position { get; set; }

    }
}