using Microsoft.Data.SqlClient;
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
using static Azure.Core.HttpHeader;
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using Timer = System.Threading.Timer;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для hello.xaml
    /// </summary>
    public partial class hello : Window
    {
        private DispatcherTimer timer;
        public hello()
        {

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Интервал времени (5 секунд)
            timer.Tick += Timer_Tick; // Обработчик события истечения времени
            timer.Start(); // Запустить таймер


            InitializeComponent();


            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sharafUsers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string query = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string value = reader.GetString(1);
                                tb.Text = "Hello, " + value;
                            }
                        }
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); // Остановить таймер
            timer.Tick -= Timer_Tick; // Удалить обработчик события, чтобы он больше не вызывался

            stranica newWindow = new stranica();
            newWindow.Show();
            this.Close(); // Закрыть текущее окно
        }
        
    }
  
}
