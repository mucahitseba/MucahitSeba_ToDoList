using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.MODELS.ViewModels
{
    public class ToDoViewModel
    {
        public Guid ToDoId { get; set; } = Guid.NewGuid();
        
        public string BusinessName { get; set; }
        
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime ToDoNotifyDate { get; set; } = DateTime.Now;
        public DateTime ToDoResultDate { get; set; } = DateTime.Now;
    }
}
