using System;
using System.Collections;
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
        //public List<TextBlock> TextBlocks { get; private set; }
        public Dictionary<TodoObject, List<TextBlock>> TodoTextBlockDict { get; private set; }
        public MainWindow()
        {
            InitializeComponent();

            List = new MainList();
            TodoTextBlockDict = new Dictionary<TodoObject, List<TextBlock>>();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await MainLoop();
        }

        private async Task MainLoop()
        {
            while (true)
            {
                await Task.Delay(500);
                TitleText.Text = TodoTextBlockDict.Count.ToString();
                if (RequiresUpdatedTextBlocks())
                {
                    UpdateTextBlocks();
                    UpdateAddButton();
                }
            }
        }

        private void CreateTodo_Click(object sender, RoutedEventArgs e)
        {
            CreateTodoWindow createWin = new CreateTodoWindow(List);
            createWin.Show();
        }

        private bool RequiresUpdatedTextBlocks()
        {
            return List.List.Count > TodoTextBlockDict.Count;
        }

        private void RemoveTextBlocks()
        {
            foreach (List<TextBlock> list in TodoTextBlockDict.Values)
            {
                foreach (TextBlock block in list) {
                    MainGrid.Children.Remove(block);
                }
            }
            TodoTextBlockDict.Clear();
        }

        private void UpdateTextBlocks()
        {
            RemoveTextBlocks();
            List<TextBlock> textBlocks = new List<TextBlock>();
            int i = 0;
            foreach (TodoObject todo in List)
            {
                i++;
                textBlocks.Clear();
                foreach (TextBlock text in AddTodoTextBlocks(todo, i))
                {
                    textBlocks.Add(text);   
                }
                TodoTextBlockDict.Add(todo, textBlocks);
            }
        }

        private void UpdateAddButton() {
            // CreateTodoButton.Margin = (TodoTextBlockDict.Count > 0) ? TodoTextBlockDict.Last().Value.Last().Margin : new Thickness(20);
        }

        private List<TextBlock> AddTodoTextBlocks(TodoObject todo, int num)
        {
            TextBlock nameText = new TextBlock();
            nameText.Text = todo.Name;
            //nameText.Margin = new Thickness(20,20 * num,0,0);

            TextBlock descText = new TextBlock();
            descText.Text = todo.Description;
            //descText.Margin = new Thickness(20, (20 * num) + 5, 0, 0);

            MainGrid.Children.Add(nameText);
            MainGrid.Children.Add(descText);

            return new List<TextBlock>() { nameText, descText };
        }
    }
}
