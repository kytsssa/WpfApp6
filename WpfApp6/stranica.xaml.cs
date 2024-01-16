using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using static WpfApp6.Window2;
using System.Configuration; // для доступа к строкам соединения
using Microsoft.Data.SqlClient;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для stranica.xaml
    /// </summary>
    public partial class stranica : Window
    {
        public stranica()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string name;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)| *.bmp; *.jpg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                Im.Source = new BitmapImage(new Uri(openDialog.FileName));
                name = openDialog.FileName;
            }

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
                                nameTB.Text = value;
                            }
                        }
                    }
                }
            }
        }

 


    }
}
