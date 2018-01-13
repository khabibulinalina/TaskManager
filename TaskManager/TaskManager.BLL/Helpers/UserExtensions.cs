using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.Helpers
{
    public static class UserExtensions
    {
        public static Register Convert(this RegisterDTO register)
        {
            return new Register
            {
                Name = register.Name,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                Position = (Positions)((int)register.Position),
                Password = register.Password,
                PasswordConfirm = register.PasswordConfirm
            };
        }
    }
}
