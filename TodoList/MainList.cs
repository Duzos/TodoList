using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class MainList
    {
        public List<TodoObject> List { get; private set; }

        public MainList() { 
            List = new List<TodoObject>();
        }

        public void add(TodoObject obj)
        {
            List.Add(obj);
        }
        public void remove(TodoObject obj)
        {
            if (!List.Contains(obj)) { return; }

            List.Remove(obj);
        }
    }
}
