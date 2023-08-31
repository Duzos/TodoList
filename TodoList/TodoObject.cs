using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TodoObject
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MainList? ParentList { get; private set; }

        public TodoObject(string name, string val)
        {
            Name = name;
            Description = val;
        }

        public void Check() { 
            IsChecked = true;
        }
    }
}
