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
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Ticket()
        {
            InitializeComponent();
            TicketShow();
        }
        public void TicketShow()
        {
            Table<SkladBas> autoid = db.GetTable<SkladBas>();
            foreach (var id in autoid)
            {
                name.Items.Add(id.model_item);
            }
        }

        public void TicketList()
        {
            Table<SkladBas> autoid = db.GetTable<SkladBas>();
            foreach (var id in autoid)
            {
                if (name.Text == id.model_item)
                {
                    name_item.Content = id.name_item;
                    model.Content = id.model_item;
                    manufacture.Content = id.name_manufacture;                    
                    country.Content = id.country;
                    
                }
            }
            Table<Lessons> autoid2 = db.GetTable<Lessons>();
            foreach (var id2 in autoid2)
            {
                if (name.Text == id2.Lesson)
                {
                    date.Content = id2.End_date;

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TicketList();
        }
    }
}
