using System;
using System.Collections.Generic;
using System.Text;



namespace TaskManager.DAL.Entities
{
    public class Employee : BaseEntity
    {
        public String Name { get; set; }
        public String Mail { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Positions Position { get; set; }

    }
}
