using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for CreateTodoWindow.xaml
    /// </summary>
    public partial class CreateTodoWindow : Window
    {
        private MainList parentList;
        public CreateTodoWindow(MainList parentList)
        {
            InitializeComponent();
            this.parentList = parentList;
        }

        private String GetName()
        {
            return NameTextBox.Text;
        }
        private String GetDescription() {
            return DescTextBox.Text;
        }
        private TodoObject CreateTodoObject() { 
            return new TodoObject(GetName(),GetDescription());
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.parentList.Add(CreateTodoObject());
            this.Close();
        }
    }
}
