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

namespace SQL_test
{
    /// <summary>
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var itemsFromDb = Database.GetItemsAsync().Result;
        }


        private static TodoItemDatabase _database;
        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new TodoItemDatabase(fileHelper.GetLocalFilePath("SQL_test.db3"));
                }
                return _database;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void listViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            object obj = item.Content;
            Page1 Page1 = new Page1();
            this.NavigationService.Navigate(new Page1(obj as TodoItem));
        }

        /*
         
        public void listViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            object obj = item.Content;
            Page1 Page1 = new Page1();
            this.NavigationService.Navigate(new Page1(obj as TodoItem));
        }

        */
    }
}
