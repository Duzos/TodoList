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

        public void Add(TodoObject obj)
        {
            List.Add(obj);
        }
        public void Remove(TodoObject obj)
        {
            if (!List.Contains(obj)) { return; }

            List.Remove(obj);
        }

        public List<TodoObject>.Enumerator GetEnumerator() {
            return this.List.GetEnumerator();
        }
    }
}
