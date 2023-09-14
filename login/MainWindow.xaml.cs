using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username,password, sql;
        private Connect conn = new Connect();
        private MySqlCommand command;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
       private void login(object sender, RoutedEventArgs e)
        {
            username = user.Text;
            password = pass.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) )
            {
                MessageBox.Show("Töltsd ki a mezőt!");
            }
            else
            {
                sql = "SELECT username, password FROM user WHERE username = '" + username + "' AND password = '" + password + "'";
                if (conn.OpenConnection() == true)
                {
                    try
                    {
                        command = new MySqlCommand(sql, conn.get_connection());
                        object a = command.ExecuteScalar();
                        if (a == null)
                        {
                            MessageBox.Show("Rossz felhasználónév vagy jelszó.");
                        }
                        else
                        {
                            Dashboard dsb = new Dashboard();
                            dsb.Show();
                            this.Close();
                        }
                    }
                    catch (MySqlException x)
                    {

                        MessageBox.Show("" + x);
                    }
                }
            }
            user.Text = "";
            pass.Password = "";
            conn.close_conn();
        }
    }
}
