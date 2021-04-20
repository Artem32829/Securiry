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
    /// Логика взаимодействия для Les.xaml
    /// </summary>
    /// 

    public partial class Les : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Les()
        {
            InitializeComponent();
            AddNameFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LessonsItems();
        }

        public void AddNameFirst()
        {
            Table<Registrations_user> table = db.GetTable<Registrations_user>();
            foreach(var i in table)
            {
                if(i.Job == "Специалист по защите информации")
                {
                    name.Items.Add(i.Name_user);
                }
                if(i.Job == "Ведущий специалист по защите информации")
                {
                    name_second.Items.Add(i.Name_user);
                }
                if(i.Job == "Главный специалист по защите информации")
                {
                    name_there.Items.Add(i.Name_user);
                }
            }
            Table<Model> table2 = db.GetTable<Model>();
            foreach (var i2 in table2)
            {
                lesson.Items.Add(i2.model1);
            }
        }

        public void LessonsItems()
        {
            int temp = 0;
            int temp2 = 0;
            int temp3 = 0;

            Table<Lessons> table = db.GetTable<Lessons>();
            foreach(var i in table)
            {
                if(i.FIO_first == name.Text && i.Laba != "+")
                {
                    temp++;
                    
                }
                if (i.FIO_second == name_second.Text && i.Securit != "+")
                {
                    temp2++;
                    
                }
                if (i.FIO_there == name_there.Text && i.Lesson != "+")
                {
                    temp3++;
                   
                }

            }
            if (temp < 3)
            {
                if (temp2 < 3)
                {
                    if (temp3 < 3)
                    {
                        Lessons lessons = new Lessons { FIO_first = name.Text.ToString(), id_fk_les = 1, id_fk_les1 = 1, id_fk_les2 = 1, id_fk_les3 = 1, id_fk_les4 = 1, FIO_second = name_second.Text.ToString(), FIO_there = name_there.Text.ToString(), Lesson = lesson.Text.ToString(), End_date = enddate.Text.ToString(), Date_start = startdate.Text.ToString() };
                        db.GetTable<Lessons>().InsertOnSubmit(lessons);
                        db.SubmitChanges();
                        MessageBox.Show("Задание выдано");
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();                       
                    }
                    else if (temp3 >= 3)
                    {
                        t.Content = ($"Выдача задания сотруднику {name_there.Text} невозможна");
                    }
                }
                else if (temp2 >= 3)
                {
                    s.Content = ($"Выдача задания сотруднику {name_second.Text} невозможна");
                }
                if (temp3 >= 3)
                {
                    t.Content = ($"Выдача задания сотруднику {name_there.Text} невозможна");
                }
            }
            else
            {
                if(temp >= 3)
                {
                    f.Content = $"Выдача задания сотруднику {name.Text} невозможна";                      
                }
                if (temp2 >= 3)
                {
                    s.Content = ($"Выдача задания сотруднику {name_second.Text} невозможна");
                }
                if (temp3 >= 3)
                {
                    t.Content = ($"Выдача задания сотруднику {name_there.Text} невозможна");
                }                
            }
            
        }
    }
}
