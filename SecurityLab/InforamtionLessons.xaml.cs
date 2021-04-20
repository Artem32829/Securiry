using System;
using System.Data.Linq;
using System.Linq;
using System.Windows;

namespace SecurityLab
{
    /// <summary>
    /// Логика взаимодействия для InforamtionLessons.xaml
    /// </summary>
    public partial class InforamtionLessons : Window
    {
        Menu menu = new Menu();
        MainWindow window = new MainWindow();
        DataClasses1DataContext db = new DataClasses1DataContext();
        public void Info()
        {
            Table<Lessons> lessons = db.GetTable<Lessons>();

            IQueryable<Registrations_user> qerty1 = from lable in db.Registrations_user
                                                    where lable.Id_regis == Convert.ToInt32(window.id)
                                                    select lable;
            foreach (var id in lessons)
            {
                if (id.Id_lessons == Convert.ToInt32(menu.k))
                {
                    dateend.Content = id.End_date;
                    datestart.Content = id.Date_start;
                    lesson.Content = id.Lesson;
                }
            }
        }
        public InforamtionLessons()
        {
            InitializeComponent();
            Info();
        }
    }
}
