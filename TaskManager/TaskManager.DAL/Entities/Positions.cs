using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.DAL.Entities
{
    public enum Positions
    {
        [Display(Name = "Директор")]
        Director,
        [Display(Name = "Программист")]
        Programmer,
        [Display(Name = "Менеджер")]
        Manager,
        [Display(Name = "Аналитик")]
        Analitics,
        [Display(Name = "Дизайнер")]
        Designer

    }
}
