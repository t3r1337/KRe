using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        lereEntities1 context;
        public Window1(lereEntities1 context, Оформление newRegistration)
        {
            InitializeComponent();

            this.context = context;
            cbМебель.ItemsSource = context.Мебель.ToList();
            cbЗаказ.ItemsSource = context.Заказ.ToList();
            this.DataContext = newRegistration;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveImage();
            context.SaveChanges();
            this.Close();
        }
        private void SaveImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png|*.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length !=0)
            {
                string nameFile = openFile.FileName;
                byte[] image = File.ReadAllBytes(nameFile);
                var reg = (Оформление)this.DataContext;
                reg.Фото_мебели = image;
                Фото_мебели.Source = new BitmapImage(new Uri(nameFile));
            }
        }
    }
}
