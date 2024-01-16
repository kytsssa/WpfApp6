using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPasswordVisible;

        public MainWindow()
        {
            InitializeComponent();
        }

        public class Transport
        {
            public int Id { get; set; }
            // public int OwnerID { get; set; }
            // public User Owner { get; set; }
            public string Identifier { get; set; }
            public List<User> Owner { get; set; } = new List<User>();
        }

        public class User
        {
            public int id { get; set; }
            public string Login { get; set; }
            public string Parol { get; set; }
            public string Email { get; set; }

        }

        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sharafUsers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

        }

        //reg
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            var email = emailTB.Text;
            var login = logTB.Text;
            var pass = parolTB.Password;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пльзователь уже вошел");
                return;
            }
            var user = new User { Login = login, Parol = pass, Email = email };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались");

            Window2 taskWindow = new Window2();
            taskWindow.Show();
            this.Close();


            if (parolTB.Password == parolTB1.Password)
            {
               
                var user1 = new User { Login = login, Parol = pass, Email = email };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались");

                Window2 taskWindow1 = new Window2();
                taskWindow1.Show();
                this.Close();
            }
        }
        //go to autoriz
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 taskWindow = new Window2();
            taskWindow.Show();
            this.Close();
        }
         
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          
             pass.Text = parolTB.Password;
            pass.Visibility = Visibility.Visible; 
            parolTB.Visibility = Visibility.Hidden;        
        }

        private void emailTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }
    }
}
