using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.MODELS.Entities
{
    
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime ToDoNotifyDate { get; set; }=DateTime.Now;
        public DateTime ToDoResultDate { get; set; }



    }
}
