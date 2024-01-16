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
using static WpfApp6.MainWindow;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = logTB.Text;
            var password = parolTB.Password;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login || x.Email == login && x.Parol == password );
            if (user is null)
            {

               
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт!");
            hello taskWindow = new hello();
            taskWindow.Show();
            this.Close();


            
        }
       
        

        private bool CheckInput(string input)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow taskWindow = new MainWindow();
            taskWindow.Show();
            this.Close();
        }

        //1
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Panel.SetZIndex(passTxt, 0);
            parolTB.Password = passTxt.Text;

            Panel.SetZIndex(off, 0);
        }
        //2
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(passTxt, 1);
            passTxt.Text = parolTB.Password;

            Panel.SetZIndex(off, 1);

        
        }
    }
}
