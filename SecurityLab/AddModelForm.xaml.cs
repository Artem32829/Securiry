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
    /// Логика взаимодействия для AddModelForm.xaml
    /// </summary>
    public partial class AddModelForm : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public AddModelForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model user_Sec = new Model
            {
                model1 = it.Text.ToString(),
            };
            db.GetTable<Model>().InsertOnSubmit(user_Sec);
            db.SubmitChanges();
        }
    }
}
