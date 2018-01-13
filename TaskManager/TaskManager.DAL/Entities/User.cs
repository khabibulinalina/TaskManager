using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Entities
{
    public class User: IdentityUser
    {
        public Positions Position { get; set; }
    }
}
