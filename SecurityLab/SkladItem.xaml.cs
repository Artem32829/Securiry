using Microsoft.Win32;
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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace SecurityLab
{
    /// <summary>
    /// Логика взаимодействия для SkladItem.xaml
    /// </summary>
    public partial class SkladItem : Microsoft.Office.Interop.Excel.Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        //public string[] name_items = new string[] { "Коммутатор", "Маршрутизатор", "Межсетевой экран", "Устройство балансировки трафика" };
        //public string[] man = new string[] { "Axoft", "Elko", "ESET","Positive Technologies","MUK", "ASBIS" };
        //public string[] model_arr = new string[] { "3810M", "2100X", "8754A", "E2182", "V8732", "2301S","6598E","L7321","O0643","P9143","2387R","1932F","H5021","L6401","K2387","U3213","K9472","Y7212" };
        //public string[] stb_arr = new string[] { "34.101.1-2014", "34.101.2-2014", "34.101.3-2014", "34.101.73-2017", "34.101.74-2017", "34.101.75-2017", "34.101.8-2014" };        

        public SkladItem()
        {
            InitializeComponent();
            AddIttem();
            Grid();

        }

        public void AddItem()
        {
            
            string text = "";
            if(check1.IsChecked == false)
            {
                SkladBas user_Sec = new SkladBas
                {
                    name_item = name.Text.ToString(),
                    name_manufacture = cmanufacturebox.Text.ToString(),
                    country = countrybox.Text.ToString(),
                    number = number.Text.ToString(),
                    lider_man = "Наумов С.С.",
                    model_item = model.Text.ToString(),
                    name_man = nameman.Text.ToString(),
                    STB = $"СТБ{stb.Text.ToString()}"
                };
                db.GetTable<SkladBas>().InsertOnSubmit(user_Sec);
                db.SubmitChanges();
            }else if(check1.IsChecked == true)
            {
                text = $"СТБ{stb.Text}({punkt.Text})";
                SkladBas user_Sec = new SkladBas
                {
                    name_item = name.Text.ToString(),
                    name_manufacture = cmanufacturebox.Text.ToString(),
                    country = countrybox.Text.ToString(),
                    number = number.Text.ToString(),
                    lider_man = "Наумов С.С.",
                    model_item = model.Text.ToString(),
                    name_man = nameman.Text.ToString(),
                    STB = text.ToString()
                };
                db.GetTable<SkladBas>().InsertOnSubmit(user_Sec);
                db.SubmitChanges();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        public void Grid()
        {
            var jobspec2 = from admles in db.SkladView
                           select new { admles.Заказчик, admles.Ответственный, admles.Тип_оборудования, admles.Модель_оборудования, admles.Серийный_номер, admles.СТБ };
            gridSklad.ItemsSource = jobspec2.ToList();
        }

        public void AddIttem()
        {
            Table<Items> item = db.GetTable<Items>();
            foreach(var i in item)
            {
                name.Items.Add(i.name_items);
            }
            Table<Country> cou = db.GetTable<Country>();
            foreach (var i in cou)
            {
                countrybox.Items.Add(i.country1);
            }
            Table<Manufacture> manuf = db.GetTable<Manufacture>();
            foreach (var i in manuf)
            {
                cmanufacturebox.Items.Add(i.manufacture1);
            }
            Table<Model> model1 = db.GetTable<Model>();
            foreach (var i in model1)
            {
                model.Items.Add(i.model1);
            }
            Table<STB> stb1 = db.GetTable<STB>();
            foreach (var i in stb1)
            {
                stb.Items.Add(i.stb1);
            }

        }

        private void AddButton(object sender, MouseButtonEventArgs e)
        {
            nameItemAdd nameItem = new nameItemAdd();
            nameItem.Show();
        }

        private void AddCountry(object sender, MouseButtonEventArgs e)
        {
            AddCountryForm addCountryForm = new AddCountryForm();
            addCountryForm.Show();
        }

        private void AddCManufacture(object sender, MouseButtonEventArgs e)
        {
            AddManufactureForm addManufactureForm = new AddManufactureForm();
            addManufactureForm.Show();
        }

        private void AddModel(object sender, MouseButtonEventArgs e)
        {
            AddModelForm addModelForm = new AddModelForm();
            addModelForm.Show();
        }
        private void AddSTB(object sender, MouseButtonEventArgs e)
        {
            AddSTBForm addSTBForm = new AddSTBForm();
            addSTBForm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; //www.yazilimkodlama.com
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < gridSklad.Columns.Count; j++) //Başlıklar için
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
         //       sheet1.Cells[1, j + 1].Font.Bold = true; //Başlığın Kalın olması için
         //       sheet1.Columns[j + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                myRange.Value2 = gridSklad.Columns[j].Header;
            }
            for (int i = 0; i < gridSklad.Columns.Count; i++)
            { //www.yazilimkodlama.com
                for (int j = 0; j < gridSklad.Items.Count; j++)
                {
                    TextBlock b = gridSklad.Columns[i].GetCellContent(gridSklad.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        dynamic Excel.Window.Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Excel.Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public Excel.Application Application => throw new NotImplementedException();

        public XlCreator Creator => throw new NotImplementedException();

        dynamic Excel.Window.Parent => throw new NotImplementedException();

        public Range ActiveCell => throw new NotImplementedException();

        public Chart ActiveChart => throw new NotImplementedException();

        public Pane ActivePane => throw new NotImplementedException();

        public dynamic ActiveSheet => throw new NotImplementedException();

        public dynamic Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayFormulas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayGridlines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHeadings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayOutline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayZeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableResize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FreezePanes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridlineColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public string OnWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panes Panes => throw new NotImplementedException();

        public Range RangeSelection => throw new NotImplementedException();

        public int ScrollColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScrollRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sheets SelectedSheets => throw new NotImplementedException();

        public dynamic Selection => throw new NotImplementedException();

        public bool Split { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitHorizontal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitVertical { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TabRatio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public XlWindowType Type => throw new NotImplementedException();

        public double UsableHeight => throw new NotImplementedException();

        public double UsableWidth => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Range VisibleRange => throw new NotImplementedException();

        public int WindowNumber => throw new NotImplementedException();

        XlWindowState Excel.Window.WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlWindowView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SheetViews SheetViews => throw new NotImplementedException();

        public dynamic ActiveSheetView => throw new NotImplementedException();

        public bool DisplayRuler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWhitespace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Hwnd => throw new NotImplementedException();
    }
}
