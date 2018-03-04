using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.DAL.Entities
{
    public class Task : BaseEntity
    {
        [Required]
        public String Title { get; set; }

        public String Descriprion { get; set; }
        public String UserId { get; set; }
        public Priority Priority { get; set; }
    }
}
