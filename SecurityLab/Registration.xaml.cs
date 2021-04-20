using System;
using System.Collections.Generic;
using System.Data.Linq;
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

namespace SecurityLab
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        int idusers;
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pass.Text == pass2.Text)
            {
                User_Sec user_Sec = new User_Sec { Number_phone = phone.Text.ToString(), Pass = pass.Text.ToString(), isenable = true };
                db.GetTable<User_Sec>().InsertOnSubmit(user_Sec);
                db.SubmitChanges();
                Table<User_Sec> autoid = db.GetTable<User_Sec>();
                foreach (var id in autoid)
                {
                    idusers = id.Id_user;   
                }
                Registrations_user registration = new Registrations_user { Name_user = name.Text.ToString(), Job = job.Text.ToString(), id_fk_user = idusers};
                db.GetTable<Registrations_user>().InsertOnSubmit(registration);
                db.SubmitChanges();              
                
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
