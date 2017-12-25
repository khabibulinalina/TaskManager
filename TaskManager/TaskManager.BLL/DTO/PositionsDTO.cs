using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public enum PositionsDTO
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
