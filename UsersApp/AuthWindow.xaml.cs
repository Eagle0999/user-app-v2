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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Password.Trim();
    

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Длина логина должна быть больше 5 символов!";
                textBoxLogin.Background = Brushes.BlueViolet;
            }
            else if (password.Length < 5)
            {
                textBoxPassword.ToolTip = "Длина пароля должна быть больше 5 символов!";
                textBoxPassword.Background = Brushes.BlueViolet;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
                textBoxPassword.Background = Brushes.Transparent;

                User authUser = null;
                using(AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password
                    ).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Все правильно!");
                    UserPageWindow userPage = new UserPageWindow();
                    userPage.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Все неправильно");
               
            }
        }

        private void ButtonRegClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
