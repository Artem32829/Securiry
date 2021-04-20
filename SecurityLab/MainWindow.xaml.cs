using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SecurityLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        List<string> nameList;
        static public int temp;
        public int id = temp;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                db = new DataClasses1DataContext();
                var users = db.User_Sec.Where(d => d.isenable == true);
                nameList = new List<string>();
                foreach (var item in users)
                {
                    nameList.Add(item.Number_phone);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             int a = 0;
            try
            {
                var user = db.User_Sec.Where(d => (d.Number_phone.ToLower()).Equals(nphone.Text.ToLower())
                && d.Pass == passjoin.Text && d.isenable == true).FirstOrDefault();
                if (user != null)
                {
                    temp = user.Id_user;
                    if(user.Id_user >= 2)
                    {
                        a = 2;
                    }
                    else if(user.Id_user<=1)
                    {
                        a = 1;
                    }
                    switch(a)
                    {
                        case 1:
                            Admin admin = new Admin();
                            admin.Show();
                            this.Close();                            
                            break;
                        case 2:
                            //User = user.Id_users.ToString();
                            Menu menu = new Menu();
                            menu.Show();
                            this.Close();
                            break;
                    }
                    //this.Close();                    
                }
                else
                {
                    //ErrorPass.Content = "Неверный телефон или пароль.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                Process.Start( @"Справка.pdf");
            
        }
    }
}
