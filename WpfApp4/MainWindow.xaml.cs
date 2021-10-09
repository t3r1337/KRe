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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        lereEntities1 context;
        public MainWindow()
        {
            InitializeComponent();
            context = new lereEntities1();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridWarehouse.ItemsSource = context.Оформление.ToList();
        }
        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            var newRegistration = new Оформление();
            context.Оформление.Add(newRegistration);
            var win = new Window1(context, newRegistration);
            win.ShowDialog();
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var row = DataGridWarehouse.SelectedItem as Оформление;
            if (row == null)
            {
                MessageBox.Show("Сначала выберите строчку для удаления");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить эту строку?", "Подтверждение удаления", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Оформление.Remove(row);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEdit_click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = sender as Button;
            var currentRegistration = btnEdit.DataContext as Оформление;
            var win1 = new Window1(context, currentRegistration);
            win1.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ShowTable();
        }
    }
}
