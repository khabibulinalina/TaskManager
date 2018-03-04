using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.DTO
{
   public class TaskViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Descriprion { get; set; }
        public string UserName { get; set; }
        public PriorityDTO Priority { get; set; }
    }
}
