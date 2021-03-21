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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void ButtonReggClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Password.Trim();
            string secondPassword = textBoxRepPassword.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

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
            else if (secondPassword.Length < 5 )
            {
                textBoxRepPassword.ToolTip = "Длина пароля должна быть больше 5 символов!";
                textBoxRepPassword.Background = Brushes.BlueViolet;
            }
            else if (password != secondPassword)
            {
                textBoxRepPassword.ToolTip = "Неправильно введен пароль!";
                textBoxRepPassword.Background = Brushes.BlueViolet;
            }
            else if (email.Length < 5 || !(email.Contains('@') || email.Contains('.')))
            {
                textBoxEmail.ToolTip = "Поле было введено некорректно!";
                textBoxEmail.Background = Brushes.BlueViolet;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
                textBoxPassword.Background = Brushes.Transparent;
                textBoxRepPassword.ToolTip = "";
                textBoxRepPassword.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxRepPassword.Background = Brushes.Transparent;
                MessageBox.Show("Вы были успешно зарегестрированны!");
                                    
                User user = new User(login, password, email);
               
                db.Users.Add(user);
                db.SaveChanges();
                Authoristaion();
            }
        }

        public  void Authoristaion()
        {
            AuthWindow authwindow = new AuthWindow();
            authwindow.Show();
            Hide();
        }
        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            Authoristaion();
        }

    
    }
}
