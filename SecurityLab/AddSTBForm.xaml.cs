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
    /// Логика взаимодействия для AddSTBForm.xaml
    /// </summary>
    public partial class AddSTBForm : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public AddSTBForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            STB user_Sec = new STB
            {
                stb1 = it.Text.ToString(),
            };
            db.GetTable<STB>().InsertOnSubmit(user_Sec);
            db.SubmitChanges();
        }
    }
}
