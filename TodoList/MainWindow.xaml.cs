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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainList List { get; private set; }
        public List<CheckBox> CheckBoxes { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            List = new MainList();
            CheckBoxes = new List<CheckBox>();
        }

        private void CreateTodo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
