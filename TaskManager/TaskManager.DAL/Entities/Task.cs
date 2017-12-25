using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Entities
{
    public class Task : BaseEntity
    {
        public String Title { get; set; }
        public String Descriprion { get; set; }
        public Employee Employee { get; set; }
        public Priority Priority { get; set; }
    }
}
