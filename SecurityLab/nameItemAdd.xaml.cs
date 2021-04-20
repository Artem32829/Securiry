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

namespace SecurityLab
{
    /// <summary>
    /// Логика взаимодействия для nameItemAdd.xaml
    /// </summary>
    public partial class nameItemAdd : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public nameItemAdd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Items user_Sec = new Items
            {
                name_items = it.Text.ToString(),
               
            };
            db.GetTable<Items>().InsertOnSubmit(user_Sec);
            db.SubmitChanges();
        }
    }
}
