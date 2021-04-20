using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
using System.Diagnostics;

namespace SecurityLab
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        MainWindow window = new MainWindow();
        static public string m;
        public string k = m;
        public string path = @"D:\note.doc";
        private readonly string TeamplateFileName = @"C:\Users\Маргарита\Documents\Первый этап.docx";
        public Menu()
        {
            InitializeComponent();
            GridLes();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                   
        }
        

        private void Replace(string stub, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stub, ReplaceWith: text);
        }

        public void Open_File()
        {

            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }
            

            IQueryable<Registrations_user> qerty1 = from lable in db.Registrations_user
                                                    where lable.id_fk_user == Convert.ToInt32(window.id)
                                                    select lable;
            string s = "";
            string jobuser = "";
            foreach (Registrations_user cust in qerty1)
            {
                s += cust.Name_user;
                jobuser += cust.Job;
            }
            Table<Lessons> lessons = db.GetTable<Lessons>();
            switch (jobuser)
            {

                case "Специалист по защите информации":
                    string v2 = text1.Text;                    
                    foreach (var id in lessons)
                    {
                        if (id.Id_lessons == Convert.ToInt32(v2))
                        {
                            id.NameFileLaba = path;
                            db.SubmitChanges();
                        }
                    }                    
                    break;
                case "Ведущий специалист по защите информации":
                    string t = text1.Text;
                    foreach (var id in lessons)
                    {
                        if (id.Id_lessons == Convert.ToInt32(t))
                        {
                            id.NameFileSecurity = path;
                            db.SubmitChanges();
                        }
                    }
                    break;
                case "Главный специалист по защите информации":
                    string g = text1.Text;
                    foreach (var id in lessons)
                    {
                        if (id.Id_lessons == Convert.ToInt32(g))
                        {
                            id.NameFilelessons = path;
                            db.SubmitChanges();
                        }
                    }
                    break;
               
            }            
        }
        public void Load_File()
        {
            Table<Lessons> lessons = db.GetTable<Lessons>();
                IQueryable<Registrations_user> qerty1 = from lable in db.Registrations_user
                                                        where lable.id_fk_user == Convert.ToInt32(window.id)
                                                        select lable;
                string s = "";
                string jobuser = "";
                foreach (Registrations_user cust in qerty1)
                {
                    s += cust.Name_user;
                    jobuser += cust.Job;
                }
               
                {
                    
                    switch (jobuser)
                    {

                        case "Специалист по защите информации":
                            string v = text1.Text;
                            int c = Convert.ToInt32(v);
                            foreach (var idd in lessons)
                            {
                                if (idd.Id_lessons == Convert.ToInt32(c))
                                {
                                Table<Lessons> fails = db.GetTable<Lessons>();
                                foreach (var i in fails)
                                {
                                    if (i.Id_lessons == Convert.ToInt32(text1.Text))
                                    {
                                        FileInfo fileInfo = new FileInfo($@"D:\LabaFail\{s.ToString()} {(c)}.txt");
                                        if (!fileInfo.Exists)
                                        {
                                            StreamWriter file = new StreamWriter($@"D:\LabaFail\{s.ToString()} {(c)}.txt");

                                            file.Close();
                                        }
                                        File.Copy(i.NameFileLaba, $@"D:\LabaFail\{s.ToString()} {(c)}.txt", true);
                                        MessageBox.Show("Скачан");
                                    }
                                }
                            }
                            }                                
                            break;
                        case "Ведущий специалист по защите информации":
                            string v1 = text1.Text;
                            int c1 = Convert.ToInt32(v1);
                            foreach (var idd in lessons)
                            {
                                if (idd.Id_lessons == Convert.ToInt32(c1))
                                {
                                     Table<Lessons> fails = db.GetTable<Lessons>();
                                foreach (var i in fails)
                                {
                                    if (i.Id_lessons == Convert.ToInt32(text1.Text))
                                    {
                                        FileInfo fileInfo = new FileInfo($@"D:\LabaFail\{s.ToString()} {(c1)}.txt");
                                        if (!fileInfo.Exists)
                                        {
                                            StreamWriter file = new StreamWriter($@"D:\LabaFail\{s.ToString()} {(c1)}.txt");

                                            file.Close();
                                        }
                                        File.Copy(i.NameFileLaba, $@"D:\LabaFail\{s.ToString()} {(c1)}.txt", true);
                                        MessageBox.Show("Скачан");
                                    }
                                }
                                }
                            }                           
                            break;
                        case "Главный специалист по защите информации":
                            string v2 = text1.Text;
                            int c2 = Convert.ToInt32(v2);
                            foreach (var idd in lessons)
                            {
                                if (idd.Id_lessons == Convert.ToInt32(c2))
                                {
                                FileInfo fileInfo = new FileInfo($@"D:\LabaFail\{s.ToString()} {(c2)}.txt");
                                if (!fileInfo.Exists)
                                {
                                    StreamWriter file = new StreamWriter($@"D:\LabaFail\{s.ToString()} {(c2)}.txt");

                                    file.Close();
                                }
                                File.Copy(idd.NameFileSecurity, $@"D:\LabaFail\{s.ToString()} {(c2)}.txt", true);
                                MessageBox.Show("Скачан");
                            }
                            }                            
                            break;
                        
                    }                    
                }
        }
          
        public void GridLes()
        {                   
                
                IQueryable<Registrations_user> qerty1 = from lable in db.Registrations_user
                                                       where lable.id_fk_user == Convert.ToInt32(window.id)
                                                       select lable;
                string s = "";
            string jobuser = "";
                foreach (Registrations_user cust in qerty1)
                {
                    s += cust.Name_user;
                    jobuser += cust.Job;
                }
            lablecon.Content = s;

            switch(jobuser)
            {
                case "Специалист по защите информации":
                    var jobspec = from admles in db.ADMLessons
                                where admles.Исполнитель_первого_этапа == s 
                                select new { admles.Номер_за_дания, admles.Исполнитель_первого_этапа, admles.Задание, admles.Первый_этап, admles.Второй_этап, admles.Третий_этап };
                    Grid1.ItemsSource = jobspec.ToList();
                    break;
                case "Ведущий специалист по защите информации":                    
                    var jobspec2 = from admles in db.ADMLessons
                                  where admles.Исполнитель_второго_этапа == s  && admles.Первый_этап == "+"
                                   select new { admles.Номер_за_дания, admles.Исполнитель_второго_этапа, admles.Задание, admles.Первый_этап, admles.Второй_этап, admles.Третий_этап };
                    Grid1.ItemsSource = jobspec2.ToList();
                    break;
                case "Главный специалист по защите информации":                
                    var jobspec3 = from admles in db.ADMLessons
                                   where admles.Исполнитель_третьего_этапа == s  && admles.Первый_этап == "+"
                                   select new { admles.Номер_за_дания, admles.Исполнитель_третьего_этапа,  admles.Задание, admles.Первый_этап, admles.Второй_этап, admles.Третий_этап };
                    Grid1.ItemsSource = jobspec3.ToList();
                    break;
            }            
        }

        public void Searh()  //поиск для админа переести наа форму (не забыть про кнопку в конце)
        {
            if (search.Text != "")
            {
                var jobspec = from admles in db.ADMLessons
                              where admles.Задание == search.Text
                              select new { admles.Номер_за_дания, admles.Исполнитель_первого_этапа, admles.Задание, admles.Первый_этап, admles.Второй_этап, admles.Третий_этап };
                Grid1.ItemsSource = jobspec.ToList();
            }
            else
            {
                var jobspec = from admles in db.ADMLessons
                              select new { admles.Номер_за_дания, admles.Исполнитель_первого_этапа, admles.Задание, admles.Первый_этап, admles.Второй_этап, admles.Третий_этап };
                Grid1.ItemsSource = jobspec.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(check1.IsChecked == true)
            {
                Table<Lessons> lessons = db.GetTable<Lessons>();

                IQueryable<Registrations_user> qerty1 = from lable in db.Registrations_user
                                                        where lable.id_fk_user == Convert.ToInt32(window.id)
                                                        select lable;
                string jobuser = "";
                foreach (Registrations_user cust in qerty1)
                {
                    jobuser += cust.Job;
                }
                switch (jobuser)
                {
                    case "Специалист по защите информации":
                        string r = text1.Text;
                        foreach (var id in lessons)
                        {
                            if (id.Id_lessons == Convert.ToInt32(r))
                            {
                                id.Laba = "+";
                                db.SubmitChanges();
                            }
                        }
                        break;
                    case "Ведущий специалист по защите информации":
                        string a = text1.Text;
                        foreach (var id in lessons)
                        {
                            if (id.Id_lessons == Convert.ToInt32(a))
                            {
                                id.Securit = "+";
                                db.SubmitChanges();
                            }
                        }
                        break;
                    case "Главный специалист по защите информации":
                        string x = text1.Text;
                        foreach (var id in lessons)
                        {
                            if (id.Id_lessons == Convert.ToInt32(x))
                            {
                                id.Check_lessons = "+";
                                db.SubmitChanges();
                                Ticket ticket = new Ticket();
                                ticket.Show();
                            }
                        }
                        break;
                }
                GridLes();
            }
            if(check2.IsChecked == true)
            {
                m = text1.Text;
                InforamtionLessons inforamtionLessons = new InforamtionLessons();
                inforamtionLessons.Show();
            }
            if(check3.IsChecked == true)
            {
                Open_File();
            }
            if(check4.IsChecked == true)
            {
                Load_File();
            }
            if(check5.IsChecked == true)
            {
                IQueryable<Registrations_user> qerty2 = from lable in db.Registrations_user
                                                        where lable.id_fk_user == Convert.ToInt32(window.id)
                                                        select lable;
                string s2 = "";
                string jobuser2 = "";
                foreach (Registrations_user cust in qerty2)
                {
                    s2 += cust.Name_user;
                    jobuser2 += cust.Job;
                }
                string v = "";
                Table<Lessons> skladBas = db.GetTable<Lessons>();
                foreach (var i in skladBas)
                {
                    if (Convert.ToInt32(text1.Text) == i.Id_lessons)
                    {
                        v = i.Lesson;
                    }
                }
                string nameitem = "";
                string namemanuf = "";
                string ncountry = "";
                string num = "";
                Table<SkladBas> sklad = db.GetTable<SkladBas>();
                foreach (var u in sklad)
                {
                    if (u.model_item == v)
                    {
                        nameitem = u.name_item;
                        namemanuf = u.name_manufacture;
                        ncountry = u.model_item;
                        num = u.number;
                    }
                }
                Table<Lessons> lessons = db.GetTable<Lessons>();
                string path = $"Специалист: {s2}\nДолжность: {jobuser2}\nТип оборудования: {nameitem}\nМодель оборудования: {ncountry}\nСерийный номер: {num}\nОтчет выполненных работ: {se.Text}";

                using (FileStream fstream = new FileStream(@"D:\note.doc", FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] input = Encoding.Default.GetBytes(path);
                    // запись массива байтов в файл
                    fstream.Write(input, 0, input.Length);
                    //Console.WriteLine("Текст записан в файл");
                }

            }

            
        }

       

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }       

        private void Restart(object sender, MouseButtonEventArgs e)
        {
            GridLes();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            Open_File();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            Load_File();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Searh();
        }
    }
}
