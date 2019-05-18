using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.MODELS.Entities;

namespace ToDoList.DAL
{
    public class MyContext:DbContext
    {
        public DateTime InstanceDate { get; set; }
        public MyContext() : base("name=MyCon")
        {
            this.InstanceDate=DateTime.Now;
        }
        public virtual DbSet<ToDo> ToDoDbSet { get; set; }
    }
    
}
