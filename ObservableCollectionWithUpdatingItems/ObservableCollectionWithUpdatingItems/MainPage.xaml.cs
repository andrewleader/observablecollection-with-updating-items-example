using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ObservableCollectionWithUpdatingItems
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<ToDoItem> _toDoItems = new ObservableCollection<ToDoItem>();

        public MainPage()
        {
            this.InitializeComponent();

            listView.ItemsSource = _toDoItems;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _toDoItems.Add(new ToDoItem()
            {
                Name = "Item " + (_toDoItems.Count + 1),
                Date = DateTime.Now
            });
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_toDoItems.Count == 0)
                return;

            int randomIndex = new Random().Next(0, _toDoItems.Count);

            ToDoItem item = _toDoItems[randomIndex];

            item.Name = "Updated " + item.Name;
            item.Date = DateTime.Now;
        }
    }
}
